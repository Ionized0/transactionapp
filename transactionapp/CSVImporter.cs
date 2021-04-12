using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace transactionapp
{
    public class CSVImporter : BaseImporter
    {
        public CSVImporter(string fileToImport): base(fileToImport)
        {
        }
        public override string InsertDataIntoDB()
        {
            string response = "";

            using (SqlConnection conn = HelperFunctions.conn)
            {
                // Set up command object
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;

                // Create import table insertion
                comm.CommandText = "";
                comm.CommandText +=
                    "INSERT INTO Import (FilePath, ImportDate, UserID, MD5Checksum) " + Environment.NewLine +
                    "VALUES (@FilePath, @ImportDate, @UserID, @MD5Checksum) " + Environment.NewLine +
                    "SELECT TOP 1 ID FROM Import WHERE FilePath = @FilePath AND " + Environment.NewLine + 
                    "UserID = @UserID AND MD5Checksum = @MD5Checksum AND ImportDate = @ImportDate ";

                comm.Parameters.Add("@FilePath", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@FilePath"].Value = fullPath;

                comm.Parameters.Add("@ImportDate", System.Data.SqlDbType.DateTime);
                comm.Parameters["@ImportDate"].Value = DateTime.Now;

                comm.Parameters.Add("@UserID", System.Data.SqlDbType.BigInt);
                comm.Parameters["@UserID"].Value = 0;

                comm.Parameters.Add("@MD5Checksum", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@MD5Checksum"].Value = HelperFunctions.GetMD5Checksum(fullPath);

                using (SqlDataReader reader = comm.ExecuteReader())
                {

                }

                using (StreamReader sr = new StreamReader(fullPath))
                {
                    string line;
                    int lineCount = 0;
                    string[] vals = { };

                    string dateString;
                    string tranDesc;
                    string credits;
                    string debits;
                    string bankBalance;

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        lineCount++;
                        vals = line.Split(',');
                        // Variable assignment
                        dateString = vals[0];
                        tranDesc = vals[1];
                        credits = vals[2];
                        debits = vals[3];
                        bankBalance = vals[4];

                        comm.CommandText +=
                            "INSERT INTO Transaction () " + Environment.NewLine +
                            " " + Environment.NewLine;
                    }
                }
            }

            return response;
        }
        public override bool HasValidData()
        {
            bool validData = true;
            using (StreamReader sr = new StreamReader(fullPath))
            {
                string line;
                int lineCount = 0;
                string[] vals = { };
                string errorText;
                string lineErrorText;

                string dateString;
                string tranDesc;
                string credits;
                string debits;
                string bankBalance;

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    lineCount++;
                    lineErrorText = $"Error encountered on line {line.ToString()} in file: ";
                    // CSV File Check
                    try
                    {
                        vals = line.Split(',');
                    }
                    catch (Exception ex)
                    {
                        errorText = "Failed to digest CSV Format. Please check that this is a valid comma-separated values file.";
                        CreateValidationLog(HelperFunctions.ActionSeverity.Error, lineErrorText + errorText);
                        validData = false;
                    }
                    if (vals.Length != 5)
                    {
                        errorText = $"Found {vals.Length.ToString()} items in the line instead of 5.";
                        CreateValidationLog(HelperFunctions.ActionSeverity.Error, lineErrorText + errorText);
                        validData = false;
                    }
                    // Variable assignment
                    dateString = vals[0];
                    tranDesc = vals[1];
                    credits = vals[2];
                    debits = vals[3];
                    bankBalance = vals[4];

                    // To finish later - additional validation on each field
                }
            }
            return validData;
        }
        private void CreateValidationLog(HelperFunctions.ActionSeverity actionSeverity, string description)
        {
            HelperFunctions.CreateLog(HelperFunctions.ActionType.Validate, actionSeverity, description);
        }
    }
}
