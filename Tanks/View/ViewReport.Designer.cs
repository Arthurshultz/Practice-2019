namespace View
{
    partial class ViewReport
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.DGVReport = new System.Windows.Forms.DataGridView();
            this.timerViewReport = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGVReport)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVReport
            // 
            this.DGVReport.AllowUserToAddRows = false;
            this.DGVReport.AllowUserToDeleteRows = false;
            this.DGVReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVReport.Location = new System.Drawing.Point(0, 0);
            this.DGVReport.Name = "DGVReport";
            this.DGVReport.ReadOnly = true;
            this.DGVReport.Size = new System.Drawing.Size(624, 602);
            this.DGVReport.TabIndex = 0;
            // 
            // timerViewReport
            // 
            this.timerViewReport.Enabled = true;
            this.timerViewReport.Interval = 500;
            this.timerViewReport.Tick += new System.EventHandler(this.timerViewReport_Tick);
            // 
            // ViewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 602);
            this.Controls.Add(this.DGVReport);
            this.DoubleBuffered = true;
            this.Name = "ViewReport";
            this.Text = "ViewReport";
            this.Load += new System.EventHandler(this.ViewReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DGVReport;
        private System.Windows.Forms.Timer timerViewReport;
    }
}