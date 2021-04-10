using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace transactionapp
{
    public partial class Home : Form
    {
        private DialogScreen ds;
        public Home()
        {
            InitializeComponent();
            ds = new DialogScreen();
            HelperFunctions.ActionLog = listViewActionLog;
        }

        private void UpdateSQLStatus()
        {
            lblConnectionStatus.Text = $"Status: {HelperFunctions.conn.State.ToString()}";
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            List<Tuple<bool, string>> returnVals = HelperFunctions.Login();
            HelperFunctions.ActionSeverity severity;
            if (!returnVals[0].Item1)
            {
                ds.ShowDialogText(returnVals[0].Item2, this);
                severity = HelperFunctions.ActionSeverity.Error;
            }
            else
            {
                severity = HelperFunctions.ActionSeverity.Success;
            }
            HelperFunctions.CreateLog(HelperFunctions.ActionType.Connect, severity, returnVals[0].Item2);
            
            UpdateSQLStatus();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string fullPath = openFileDialog.FileName;
            CSVImporter importer = new CSVImporter(fullPath);
            if (importer.IsAcccessibleFile() && importer.HasValidData())
            {
                importer.InsertDataIntoDB();
            }
        }
        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            HelperFunctions.CreateLog(HelperFunctions.ActionType.Import, HelperFunctions.ActionSeverity.Info, $"{btnImportCSV.Text} button pressed.");
            openFileDialog.ShowDialog();
        }
    }
}
