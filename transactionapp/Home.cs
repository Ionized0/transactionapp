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
        private SqlConnection conn;
        private DialogScreen ds;
        public Home()
        {
            InitializeComponent();
            ds = new DialogScreen();
            HelperFunctions.ActionLog = listViewActionLog;
        }

        private bool Login()
        {
            bool loggedIn = false;

            conn = new SqlConnection(HelperFunctions.GetConnectionString());
            try
            {
                conn.Open();
                loggedIn = true;
                ds.ShowDialogText("Successfully logged in!", this);
                HelperFunctions.CreateLog(HelperFunctions.ActionType.Connect, HelperFunctions.ActionSeverity.Success, "Login successful.");

            } catch (Exception ex)
            {
                ds.ShowDialogText($"Error encountered during login: {ex.Message}.", this);
                HelperFunctions.CreateLog(HelperFunctions.ActionType.Connect, HelperFunctions.ActionSeverity.Error, "Login unsuccessful.");
            }

            return loggedIn;
        }

        private void UpdateSQLStatus()
        {
            lblConnectionStatus.Text = $"Status: {conn.State.ToString()}";
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Login();
            UpdateSQLStatus();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }
        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            
        }
    }
}
