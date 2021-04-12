using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace transactionapp
{
    public static class HelperFunctions
    {
        public static SqlConnection conn;
        private static ListView actionLog;
        public enum ActionSeverity { Success, Error, Info, Warning }
        public enum ActionType { Initialise, Connect, Import, Edit, View, Validate }
        public enum ImportType { CSV, QIF, OFX }
        public static string GetConnectionString()
        {
            // Temp vars
            string server = "localhost\\SQLEXPRESS"
                , db = "transactionapp"
                , userid = "tappmaster"
                , pw = "masterpw";
            return $"Server={server};Database={db};User Id='{userid}';Password={pw};";
        }
        public static List<Tuple<bool, string>> Login()
        {
            List<Tuple<bool, string>> itemList = new List<Tuple<bool, string>>();
            string returnText = "";
            bool loggedIn = false;

            conn = new SqlConnection(HelperFunctions.GetConnectionString());
            try
            {
                conn.Open();
                loggedIn = true;
                returnText = "Login successful.";
            }
            catch (Exception ex)
            {
                loggedIn = false;
                returnText = $"Error encountered during login: {ex.Message}.";
            }

            itemList.Add(new Tuple<bool, string>(loggedIn, returnText));

            return itemList;
        }
        public static void CreateLog(ActionType actionType, ActionSeverity actionSeverity, string description)
        {
            if (actionLog != null)
            {
                ListViewItem item = new ListViewItem();
                DateTime actionDate = DateTime.Now;
                item.Text = actionDate.ToString();
                item.SubItems.Add(actionSeverity.ToString());
                item.SubItems.Add(actionType.ToString());
                item.SubItems.Add(description);
                actionLog.Items.Add(item);
                //actionLog.Items.Add($"{DateTime.Now.ToString()}\t{actionSeverity.ToString()}\t{actionType.ToString()}\t{description}");
                
                InsertLogIntoDB(actionDate, actionType, actionSeverity, description, conn);
            }
        }
        public static void InsertLogIntoDB(DateTime actionDate, ActionType actionType, ActionSeverity actionSeverity, string description, SqlConnection conn)
        {
            if (ConnectionIsOpen())
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = 
                    "INSERT INTO log (timestamp, actiontype, actionseverity, description, userid) " +
                    "VALUES (@ActionDate, @ActionType, @ActionSeverity, @Description, @UserID)";

                comm.Parameters.Add("@ActionDate", System.Data.SqlDbType.DateTime);
                comm.Parameters["@ActionDate"].Value = actionDate;

                comm.Parameters.Add("@ActionType", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@ActionType"].Value = actionType;

                comm.Parameters.Add("@ActionSeverity", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@ActionSeverity"].Value = actionSeverity;

                comm.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@Description"].Value = description;

                comm.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                comm.Parameters["@UserID"].Value = 0;   // Potentially adjusted in future if it becomes a multi-user platform

                comm.Connection = conn;

                comm.ExecuteNonQuery();
            }
        }
        public static string GetMD5Checksum(string fullPath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fullPath))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
        public static ListView ActionLog
        {
            get
            {
                return actionLog;
            }
            set
            {
                actionLog = value;
                CreateLog(ActionType.Initialise, ActionSeverity.Success, $"Log form has been initialised.");
            }
        }
        public static bool ConnectionIsOpen()
        {
            if (conn == null) return false;
            return conn.State == System.Data.ConnectionState.Open;
        }
    }
}
