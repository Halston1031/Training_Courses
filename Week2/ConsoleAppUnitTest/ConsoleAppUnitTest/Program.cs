using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppUnitTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class MyRectangle
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double GetArea()
        {
            return Height * Width;
        }
    }
}
