using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ClaimRepo claimRepo = new ClaimRepo();
            ProgramUI ui = new ProgramUI(claimRepo);
            ui.Commands();
        }
    }
}
