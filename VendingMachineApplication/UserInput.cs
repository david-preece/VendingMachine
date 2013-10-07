using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication
{
    static class UserInput
    {
        static public string GetUserInput(string inputMessage)
        {
            try
            {
                Console.WriteLine(inputMessage);
                return Console.ReadLine();
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
