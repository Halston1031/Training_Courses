using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumSamples01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyWeekDays day = MyWeekDays.Sun;
            Console.WriteLine($"Today is {day}");
            if (day == MyWeekDays.Mon)
            {
                Console.WriteLine("Today is Monday");
            }
            else
            {
                Console.WriteLine("Today isn't Monday");
            }
            // 強制轉換回int
            int i = (int)day;
            Console.WriteLine($"The value of {day} is {i}"); 
            Console.ReadLine();
        }
    }
}
