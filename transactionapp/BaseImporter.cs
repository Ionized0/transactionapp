using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace transactionapp
{
    abstract public class BaseImporter
    {
        public static readonly int waitTime = 6000; // ms
        public static readonly int maxAttempts = 5;
        protected string fullPath;
        public BaseImporter(string fileToImport)
        {
            fullPath = fileToImport;
        }
        public bool IsAcccessibleFile()
        {
            int attemptNum = 0;
            bool accessible = false;
            while (attemptNum < maxAttempts && !accessible)
            {
                try
                {
                    using (FileStream fs = File.Open(fullPath, FileMode.Open))
                    {
                        fs.Close();
                        accessible = true;
                    }
                }
                catch (Exception ex)
                {
                    Thread.Sleep(waitTime);
                }
                attemptNum++;
            }
            HelperFunctions.CreateLog(HelperFunctions.ActionType.Validate, accessible ? HelperFunctions.ActionSeverity.Success : HelperFunctions.ActionSeverity.Error, $"File is {(accessible ? "" : "not ")}accessible");
            return accessible;
        }
        abstract public bool HasValidData();

        abstract public string InsertDataIntoDB();
    }
}
