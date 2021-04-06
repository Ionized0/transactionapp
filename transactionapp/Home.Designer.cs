
namespace transactionapp
{
    partial class Home
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.btnImportCSV = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listViewActionLog = new System.Windows.Forms.ListView();
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.severity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.action = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(56, 30);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(138, 31);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect to SQL Server";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(284, 39);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(37, 13);
            this.lblConnectionStatus.TabIndex = 1;
            this.lblConnectionStatus.Text = "Status";
            // 
            // btnImportCSV
            // 
            this.btnImportCSV.Location = new System.Drawing.Point(56, 90);
            this.btnImportCSV.Name = "btnImportCSV";
            this.btnImportCSV.Size = new System.Drawing.Size(138, 31);
            this.btnImportCSV.TabIndex = 2;
            this.btnImportCSV.Text = "Import CSV";
            this.btnImportCSV.UseVisualStyleBackColor = true;
            this.btnImportCSV.Click += new System.EventHandler(this.btnImportCSV_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // listViewActionLog
            // 
            this.listViewActionLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.time,
            this.severity,
            this.action,
            this.description});
            this.listViewActionLog.HideSelection = false;
            this.listViewActionLog.Location = new System.Drawing.Point(56, 257);
            this.listViewActionLog.Name = "listViewActionLog";
            this.listViewActionLog.Size = new System.Drawing.Size(692, 164);
            this.listViewActionLog.TabIndex = 3;
            this.listViewActionLog.UseCompatibleStateImageBehavior = false;
            this.listViewActionLog.View = System.Windows.Forms.View.Details;
            // 
            // time
            // 
            this.time.Text = "Time";
            this.time.Width = 140;
            // 
            // severity
            // 
            this.severity.Text = "Severity";
            this.severity.Width = 81;
            // 
            // action
            // 
            this.action.Text = "Action";
            this.action.Width = 82;
            // 
            // description
            // 
            this.description.Text = "Description";
            this.description.Width = 283;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listViewActionLog);
            this.Controls.Add(this.btnImportCSV);
            this.Controls.Add(this.lblConnectionStatus);
            this.Controls.Add(this.btnConnect);
            this.Name = "Home";
            this.Text = "TransactionApp";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Button btnImportCSV;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListView listViewActionLog;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.ColumnHeader severity;
        private System.Windows.Forms.ColumnHeader action;
        private System.Windows.Forms.ColumnHeader description;
    }
}

