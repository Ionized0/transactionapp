using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
