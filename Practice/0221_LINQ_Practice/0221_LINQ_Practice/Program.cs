using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _0221_LINQ_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("（奇偶判斷）論人一串帶有逗號的數宇序列: ");
            string[] input2 = Console.ReadLine().Split(',');
            var odd = input2.Where(x => int.Parse(x) % 2 != 0);
            var even = input2.Where(x => int.Parse(x) % 2 == 0);
            Console.WriteLine($"奇數：{string.Join(",", odd)}");
            Console.WriteLine($"偶數：{string.Join(",", even)}");
        }
    }
}
