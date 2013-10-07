using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication
{
    public interface IVendingMachinePart
    {
        string Name { get; set; }
        object DoAction(object[] args, VendingMachine obj = null);
    }
}
