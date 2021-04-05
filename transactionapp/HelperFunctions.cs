using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace transactionapp
{
    public static class HelperFunctions
    {
        private static ListView actionLog;
        public enum ActionSeverity { Success, Error, Info, Warning }
        public enum ActionType { Initialise, Connect, Import, Edit, View }
        public static string GetConnectionString()
        {
            // Temp vars
            string server = "localhost\\SQLEXPRESS"
                , db = "transactionapp"
                , userid = "tappmaster"
                , pw = "masterpw";
            return $"Server={server};Database={db};User Id='{userid}';Password={pw};";
        }
        public static void CreateLog(ActionType actionType, ActionSeverity actionSeverity, string description)
        {
            if (actionLog != null)
            {
                ListViewItem item = new ListViewItem();
                item.Text = DateTime.Now.ToString();
                item.SubItems.Add(actionSeverity.ToString());
                item.SubItems.Add(actionType.ToString());
                item.SubItems.Add(description);
                actionLog.Items.Add(item);
                //actionLog.Items.Add($"{DateTime.Now.ToString()}\t{actionSeverity.ToString()}\t{actionType.ToString()}\t{description}");
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
    }
}
