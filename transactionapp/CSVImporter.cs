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
        public override void InsertDataIntoDB()
        {

        }
        public override bool HasValidData()
        {
            bool validData = false;
            using (StreamReader sr = new StreamReader(fullPath))
            {
                string line;
                int lineCount = 0;
                string[] vals;
                string errorText;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    lineCount++;
                    errorText = $"Error encountered on line {line.ToString()} in file: ";
                    try
                    {
                        vals = line.Split(',');
                    } catch (Exception ex)
                    {
                        HelperFunctions.CreateLog(
                            HelperFunctions.ActionType.Validate
                            , HelperFunctions.ActionSeverity.Error
                            , errorText + "Failed to digest CSV Format. Please check that this is a valid comma-separated values file.");
                    }
                }
            }
            return validData;
        }
    }
}
