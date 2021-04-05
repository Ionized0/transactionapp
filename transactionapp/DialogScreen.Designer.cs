
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
            this.lblDialogText = new System.Windows.Forms.Label();
            this.s = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDialogText
            // 
            this.lblDialogText.AutoSize = true;
            this.lblDialogText.Location = new System.Drawing.Point(151, 47);
            this.lblDialogText.Name = "lblDialogText";
            this.lblDialogText.Size = new System.Drawing.Size(35, 13);
            this.lblDialogText.TabIndex = 0;
            this.lblDialogText.Text = "label1";
            // 
            // s
            // 
            this.s.Location = new System.Drawing.Point(143, 120);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(75, 23);
            this.s.TabIndex = 1;
            this.s.Text = "OK";
            this.s.UseVisualStyleBackColor = true;
            this.s.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // DialogScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 216);
            this.Controls.Add(this.s);
            this.Controls.Add(this.lblDialogText);
            this.Name = "DialogScreen";
            this.Text = "DialogScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDialogText;
        private System.Windows.Forms.Button s;
    }
}