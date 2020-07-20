namespace ProgressRunner
{
    partial class ProgressRunnerDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
                _cancellationTokenSource?.Dispose();
            }
            
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressRunnerDialog));
            this.lblTaskProgress = new System.Windows.Forms.Label();
            this.lblOverallProgress = new System.Windows.Forms.Label();
            this.taskProgress = new System.Windows.Forms.ProgressBar();
            this.overallProgress = new System.Windows.Forms.ProgressBar();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblOverallCounter = new System.Windows.Forms.Label();
            this.lblTaskCounter = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTaskProgress
            // 
            this.lblTaskProgress.AutoSize = true;
            this.lblTaskProgress.Location = new System.Drawing.Point(9, 186);
            this.lblTaskProgress.Name = "lblTaskProgress";
            this.lblTaskProgress.Size = new System.Drawing.Size(89, 17);
            this.lblTaskProgress.TabIndex = 17;
            this.lblTaskProgress.Text = "Task Progress";
            this.lblTaskProgress.UseWaitCursor = true;
            // 
            // lblOverallProgress
            // 
            this.lblOverallProgress.AutoSize = true;
            this.lblOverallProgress.Location = new System.Drawing.Point(9, 124);
            this.lblOverallProgress.Name = "lblOverallProgress";
            this.lblOverallProgress.Size = new System.Drawing.Size(105, 17);
            this.lblOverallProgress.TabIndex = 16;
            this.lblOverallProgress.Text = "Overall Progress";
            this.lblOverallProgress.UseWaitCursor = true;
            // 
            // taskProgress
            // 
            this.taskProgress.Location = new System.Drawing.Point(12, 206);
            this.taskProgress.Name = "taskProgress";
            this.taskProgress.Size = new System.Drawing.Size(447, 23);
            this.taskProgress.Step = 1;
            this.taskProgress.TabIndex = 15;
            this.taskProgress.UseWaitCursor = true;
            // 
            // overallProgress
            // 
            this.overallProgress.Location = new System.Drawing.Point(12, 144);
            this.overallProgress.Name = "overallProgress";
            this.overallProgress.Size = new System.Drawing.Size(447, 23);
            this.overallProgress.Step = 1;
            this.overallProgress.TabIndex = 14;
            this.overallProgress.UseWaitCursor = true;
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(477, 113);
            this.lblHeader.TabIndex = 18;
            this.lblHeader.Text = "Processing...";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeader.UseWaitCursor = true;
            // 
            // lblOverallCounter
            // 
            this.lblOverallCounter.Location = new System.Drawing.Point(299, 124);
            this.lblOverallCounter.Name = "lblOverallCounter";
            this.lblOverallCounter.Size = new System.Drawing.Size(160, 17);
            this.lblOverallCounter.TabIndex = 19;
            this.lblOverallCounter.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblOverallCounter.UseWaitCursor = true;
            // 
            // lblTaskCounter
            // 
            this.lblTaskCounter.Location = new System.Drawing.Point(299, 186);
            this.lblTaskCounter.Name = "lblTaskCounter";
            this.lblTaskCounter.Size = new System.Drawing.Size(160, 17);
            this.lblTaskCounter.TabIndex = 20;
            this.lblTaskCounter.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblTaskCounter.UseWaitCursor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(177, 251);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 29);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProgressRunnerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(471, 292);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTaskCounter);
            this.Controls.Add(this.lblOverallCounter);
            this.Controls.Add(this.lblTaskProgress);
            this.Controls.Add(this.lblOverallProgress);
            this.Controls.Add(this.taskProgress);
            this.Controls.Add(this.overallProgress);
            this.Controls.Add(this.lblHeader);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(487, 289);
            this.Name = "ProgressRunnerDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Processing...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTaskProgress;
        private System.Windows.Forms.Label lblOverallProgress;
        private System.Windows.Forms.ProgressBar taskProgress;
        private System.Windows.Forms.ProgressBar overallProgress;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblOverallCounter;
        private System.Windows.Forms.Label lblTaskCounter;
        private System.Windows.Forms.Button btnCancel;
    }
}