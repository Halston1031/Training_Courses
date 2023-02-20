using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GroupBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList(); 
            var result = 
                from o in list
                group o by o.City into gp
                select gp;
            foreach (var item in result)
            { 
                Console.WriteLine($"Live in:{item.Key}"); 
                foreach (var p in item) 
                { 
                    Console.WriteLine(p.Name); 
                } 
                Console.WriteLine("--------"); 
            }
            Console.ReadLine();
        }

        static List<MyClass> CreateList()
        { 
            return new List<MyClass>() 
            { 
                new MyClass(){ Name = "Bill",City = "Taipei"},
                new MyClass(){ Name = "John",City = "Taipei"},
                new MyClass(){ Name = "Tom",City = "LA"},
                new MyClass(){ Name = "David",City = "Hsinchu"},
                new MyClass(){ Name = "Jeff",City = "Hsinchu"},
            }; 
        }
    }
}
