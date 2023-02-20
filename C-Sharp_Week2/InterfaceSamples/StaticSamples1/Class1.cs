using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSamples1
{
    internal class Class1
    {
        private static int x = 100;
        public static void Execute() 
        { 
            Console.WriteLine($"This is {x}"); 
        }
    }

}

