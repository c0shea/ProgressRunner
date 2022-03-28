using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper disable LocalizableElement

namespace ProgressRunner
{
    public partial class ProgressRunnerDialog : Form, IProgressRunner
    {
        private readonly Form _parentForm;
        private readonly List<IRunnableTask> _tasks = new List<IRunnableTask>();
        private CancellationTokenSource _cancellationTokenSource;

        public bool IsRunning { get; private set; }

        public string Title
        {
            get => lblHeader.Text;
            set => lblHeader.Text = value;
        }

        public ProgressRunnerDialog(Form parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
            CenterParent();
        }

        public void AddTask(IRunnableTask task)
        {
            _tasks.Add(task);
            SetOverallMaximumValue();
            UpdateOverallCounter();
        }

        public void AddTasks(IEnumerable<IRunnableTask> tasks)
        {
            _tasks.AddRange(tasks);
            SetOverallMaximumValue();
            UpdateOverallCounter();
        }

        public async Task RunAsync()
        {
            if (IsRunning)
            {
                throw new InvalidOperationException("Progress is already running");
            }

            IsRunning = true;

            Reset();
            Show();
            Refresh();

            var progress = new Progress<IterationStatus>(status =>
            {
                taskProgress.Maximum = status.MaximumValue;
                taskProgress.Value = status.CurrentValue;
                lblTaskCounter.Text = $"{status.CurrentValue:N0} of {status.MaximumValue:N0}";
                lblTaskCounter.Refresh();
            });

            var cancellationToken = _cancellationTokenSource.Token;

            foreach (var task in _tasks)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                lblTaskProgress.Text = task.Name;
                lblTaskProgress.Refresh();
                taskProgress.Value = 0;
                taskProgress.Maximum = 0;

                switch (task)
                {
                    case ContinuousRunnableTask continuousTask:
                        taskProgress.Style = ProgressBarStyle.Marquee;
                        taskProgress.Refresh();
                        lblTaskCounter.Hide();
                        lblTaskCounter.Refresh();
                        await Task.Run(() => continuousTask.Task(), cancellationToken);
                        break;

                    case RunnableTask runnableTask:
                        taskProgress.Style = ProgressBarStyle.Blocks;
                        taskProgress.Refresh();
                        lblTaskCounter.Show();
                        lblTaskCounter.Refresh();
                        await Task.Run(() => runnableTask.Task(progress, cancellationToken), cancellationToken);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(task));
                }

                overallProgress.PerformStep();
                UpdateOverallCounter();
            }

            IsRunning = false;
            Hide();
        }
        
        private void SetOverallMaximumValue() => overallProgress.Maximum = _tasks.Count;

        private void UpdateOverallCounter()
        {
            lblOverallCounter.Text = $"{overallProgress.Value:N0} of {overallProgress.Maximum:N0}";
            lblOverallCounter.Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!IsRunning)
            {
                return;
            }

            btnCancel.Enabled = false;
            btnCancel.Text = "Canceling...";

            _cancellationTokenSource?.Cancel();
        }

        /// <summary>
        /// StartPosition.CenterParent doesn't work when the form isn't opened via ShowDialog(this);
        /// </summary>
        private void CenterParent()
        {
            if (_parentForm == null)
            {
                return;
            }

            Top = _parentForm.Top + (_parentForm.Height - Height) / 2;
            Left = _parentForm.Left + (_parentForm.Width - Width) / 2;
        }

        /// <summary>
        /// Reset the state so the same tasks can be run again.
        /// </summary>
        private void Reset()
        {
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();

            // Make sure the overall progress starts at 0 in case the same instance is run again
            overallProgress.Value = 0;
            UpdateOverallCounter();

            btnCancel.Text = "Cancel";
            btnCancel.Enabled = true;
        }
    }
}
