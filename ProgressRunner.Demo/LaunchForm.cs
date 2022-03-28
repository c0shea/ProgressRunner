using System;
using System.Threading;
using System.Windows.Forms;

namespace ProgressRunner.Demo
{
    public partial class LaunchForm : Form
    {
        public LaunchForm()
        {
            InitializeComponent();
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            using (var form = BuildProgressDialog())
            {
                await form.RunAsync();

                Close();
            }
        }

        private static ProgressRunnerDialog BuildProgressDialog()
        {
            var progress = new ProgressRunnerDialog(null);

            progress.AddTask(new ContinuousRunnableTask("Finding data", () => Thread.Sleep(TimeSpan.FromSeconds(3))));

            progress.AddTask(new RunnableTask("Populating details", (status, token) =>
            {
                const int count = 10_000;

                for (var i = 0; i < count; i++)
                {
                    status.Report(new IterationStatus(i, count));
                }
            }));

            progress.AddTask(new RunnableTask("Building models", (status, token) =>
            {
                const int count = 10_000;
                var previousStatus = new IterationStatus(0, count);

                for (var i = 0; i < count; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }

                    var currentStatus = new IterationStatus(i + 1, count);
                    if (currentStatus.ShouldReport(previousStatus))
                    {
                        status.Report(currentStatus);
                    }
                    previousStatus = currentStatus;
                }
            }));

            progress.AddTask(new ContinuousRunnableTask("Saving", () =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }));

            return progress;
        }
    }
}
