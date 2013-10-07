﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication
{
    public interface IVendingMachineProduct
    {
        string Name { get; set; }
        double Price { get; set; }
        int Quantity { get; set; }
        string Code { get; set; }
    }
}
