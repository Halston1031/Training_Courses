using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("（序列反轉）翰人一串带有逗號的數宇序列：");
            string[] input = Console.ReadLine().Split(',');
            var result = input.Reverse();
            Console.WriteLine(string.Join("", result));
            Console.Write("\n");
        }
    }
}
