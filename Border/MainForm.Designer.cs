
namespace Border
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlControl = new System.Windows.Forms.Panel();
            this.lbStop = new System.Windows.Forms.Label();
            this.lbSharing = new System.Windows.Forms.Label();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pnlControl.Controls.Add(this.lbStop);
            this.pnlControl.Controls.Add(this.lbSharing);
            this.pnlControl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pnlControl.Location = new System.Drawing.Point(241, 14);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(169, 39);
            this.pnlControl.TabIndex = 1;
            this.pnlControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlControl_MouseDown);
            this.pnlControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlControl_MouseMove);
            // 
            // lbStop
            // 
            this.lbStop.AutoSize = true;
            this.lbStop.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbStop.ForeColor = System.Drawing.Color.Red;
            this.lbStop.Location = new System.Drawing.Point(118, 10);
            this.lbStop.Name = "lbStop";
            this.lbStop.Size = new System.Drawing.Size(45, 18);
            this.lbStop.TabIndex = 1;
            this.lbStop.Text = "Stop";
            this.lbStop.Click += new System.EventHandler(this.lbStop_Click);
            // 
            // lbSharing
            // 
            this.lbSharing.AutoSize = true;
            this.lbSharing.ForeColor = System.Drawing.Color.White;
            this.lbSharing.Location = new System.Drawing.Point(3, 12);
            this.lbSharing.Name = "lbSharing";
            this.lbSharing.Size = new System.Drawing.Size(108, 15);
            this.lbSharing.TabIndex = 0;
            this.lbSharing.Text = "Screen Sharing";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 618);
            this.Controls.Add(this.pnlControl);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Label lbStop;
        private System.Windows.Forms.Label lbSharing;
    }
}

