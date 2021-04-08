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
        public bool IsValidAndAcccessibleFile(string fullPath)
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
            return accessible;
        }

        abstract public void InsertDataIntoDB(string fullPath);
    }
}
