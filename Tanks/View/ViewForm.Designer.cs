namespace View
{
    partial class ViewForm
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
            this.BtnStart = new System.Windows.Forms.Button();
            this.picBoxField = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.ScoreAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxField)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(12, 12);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.TabStop = false;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // picBoxField
            // 
            this.picBoxField.Location = new System.Drawing.Point(12, 41);
            this.picBoxField.Name = "picBoxField";
            this.picBoxField.Size = new System.Drawing.Size(640, 640);
            this.picBoxField.TabIndex = 1;
            this.picBoxField.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ScoreAmount
            // 
            this.ScoreAmount.AutoSize = true;
            this.ScoreAmount.Location = new System.Drawing.Point(617, 9);
            this.ScoreAmount.Name = "ScoreAmount";
            this.ScoreAmount.Size = new System.Drawing.Size(0, 13);
            this.ScoreAmount.TabIndex = 2;
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 692);
            this.Controls.Add(this.ScoreAmount);
            this.Controls.Add(this.picBoxField);
            this.Controls.Add(this.BtnStart);
            this.KeyPreview = true;
            this.Name = "ViewForm";
            this.Text = "Tanks";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ViewForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.PictureBox picBoxField;
        public System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label ScoreAmount;
    }
}

