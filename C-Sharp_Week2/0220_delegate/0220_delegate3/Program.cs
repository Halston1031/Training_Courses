using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0220_delegate3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //建立來源資料
            List<string> source
                = new List<string> { "Bill", "John", "David", "Tom", "David" };
            MyClass obj = new MyClass();
            var result = obj.DoWhere(source, (x) => x == "David");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static bool SearchDavid(string value)
        {
            return (value == "David"); // 如果是“David” 則回傳true
        }
    }
}
