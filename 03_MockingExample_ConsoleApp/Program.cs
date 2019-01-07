using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_MockingExample_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new RealConsole();
            ProgramUI program = new ProgramUI(console);
            program.Run();
        }
    }
}
