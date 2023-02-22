using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string> { "dog", "cat", "fly", "donkey" };
            string result = list.Find((x) => x == "cat"); // Lambda
            string result1 = list.FindLast((x) => x.Contains("d")); //Lambda, find List elements which including "d". If found,then stop
            Console.WriteLine(result);
            Console.WriteLine(result1);

            List<string> list1 = list.FindAll((x) => x.Contains("d")); //FindAll using in List<string>
            string display = string.Join("#", list1); //Join-> 指定分隔符號("#")來串連字串陣列
            Console.WriteLine(display);
            Console.ReadKey();
        }
    }
}
