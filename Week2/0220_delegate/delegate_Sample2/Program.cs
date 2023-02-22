using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_Sample2 //委派的傳遞
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //建立來源資料
            List<string> source
                = new List<string> {"Bill", "John", "David", "Tom", "David"};
            MyClass obj = new MyClass();
            MyPredicate predicate = SearchDavid; // SearchDavid放進predicate, 靠 predicate 告訴它怎麼判斷
            var result = obj.DoWhere(source, predicate);
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
