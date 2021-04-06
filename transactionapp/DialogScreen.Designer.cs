
namespace transactionapp
{
    partial class DialogScreen
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
            this.s = new System.Windows.Forms.Button();
            this.textBoxDlg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // s
            // 
            this.s.Location = new System.Drawing.Point(155, 164);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(75, 23);
            this.s.TabIndex = 1;
            this.s.Text = "OK";
            this.s.UseVisualStyleBackColor = true;
            this.s.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // textBoxDlg
            // 
            this.textBoxDlg.Location = new System.Drawing.Point(45, 31);
            this.textBoxDlg.Name = "textBoxDlg";
            this.textBoxDlg.Size = new System.Drawing.Size(305, 20);
            this.textBoxDlg.TabIndex = 2;
            // 
            // DialogScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 216);
            this.Controls.Add(this.textBoxDlg);
            this.Controls.Add(this.s);
            this.Name = "DialogScreen";
            this.Text = "DialogScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button s;
        private System.Windows.Forms.TextBox textBoxDlg;
    }
}