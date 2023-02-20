using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        private static int x; // Program.x
        static void Do()
        {
        }
        static void Main(string[] args)
        {
            x = 10; // equals -> Program.x
            Program.Do();
            Program p  = new Program();
            p.Exec();
        }
        void Exec()
        { 
            Program.Do();
        }
    }
}
