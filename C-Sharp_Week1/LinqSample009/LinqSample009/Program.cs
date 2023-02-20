using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSample009
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<MyClass> list = CreateList();
            /*
            //Query Expression
            IEnumerable<MyClass> people = 
               from data in list
               where data.Name == "Bill"
               select data;
            */
            //Method Expression
            var people = list.Where((x)=>x.Name=="Bill");
            // var people = list.Where(list, (x) => x.Name == "Bill"); //IEnumerable 為「資料結構中的資料，是否可被列舉」
            foreach (MyClass person in people)
            {
                 Console.WriteLine($"{person.Name} is {person.Age} yrs old.");
            }
            Console.ReadKey();
        }
        static List<MyClass> CreateList()
        {
            return new List<MyClass>()
            {
                new MyClass { Name = "Bill", Age = 47 },
                new MyClass { Name = "John", Age = 37 },
                new MyClass { Name = "Tom", Age = 48 },
                new MyClass { Name = "David", Age = 36 },
                new MyClass { Name = "Bill", Age = 35 },
            };
        }
        
    }
}
