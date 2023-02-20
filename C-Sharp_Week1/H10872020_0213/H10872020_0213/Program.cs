using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> _dictionary = new Dictionary<string, int>
            {
                {"A", 100},
                {"B", 200},
                {"C", 300},
            };

            int result = 0;
            if (_dictionary.ContainsKey("A"))
            {
                result = _dictionary["A"];
                Console.WriteLine($"The value is {result}");
            }
            else
            {
                Console.WriteLine("Key not found....");
            }
            Console.ReadKey();
        }
    }
}
