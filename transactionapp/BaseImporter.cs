using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transactionapp
{
    abstract public class BaseImporter
    {
        public bool IsValidAndAcccessibleFile(string fullPath)
        {
            return true;
        }
    }
}
