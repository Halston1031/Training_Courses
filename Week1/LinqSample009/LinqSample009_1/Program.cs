using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqSample009_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //開始用var了
            var list = CreateList();
            //這裡的person1是單個物件,也就是MyClass person1
            var person1 = list.FirstOrDefault((x)=>x.Age<37);
            Console.WriteLine($"The first person to be found under the age of 37 was: {person1.Name}");
            try
            {
                //因為找不到,就會跳出例外
                var person2 = list.First((x) => x.Age < 30);
                Console.WriteLine($"The first person to be found under the age of 30 was:{person2.Name}");
            }
            catch (Exception) 
            {
                Console.WriteLine($"Not found.");
            }

            //這裡的person_1是單個物件,也就是MyClass person_1
            var person_1  = list.LastOrDefault((x) => x.Age > 35);
            Console.WriteLine($"The last person to be found larger than 35 was: {person_1.Name}");
            try
            {
                //因為找不到,就會跳出例外
                var person_2 = list.Last((x) => x.Age > 50);
                Console.WriteLine($"The last person to be found larger than 50 was: {person_2.Name}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Not found.");
            }

            //這裡的person_11是單個物件,也就是MyClass person_11
            var person_11 = list.SingleOrDefault((x) => x.Name == "Tom");
            Console.WriteLine($"found only {person_11.Name}-{person_11.Age}");
            try
            {
                //因為找不到唯一(裡面有兩個Bill)就會跳出例外
                var person_22 = list.Single((x) => x.Name == "Bill");
                Console.WriteLine($"found only {person_22.Name}-{person_22.Age}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Not found.");
            }


            var person = list.FirstOrDefault((x) => x.Name == "李小龍");
            //判斷回傳結果是否為null
            if(person == null) 
            {
                //如果是null則另行處理
                Console.WriteLine("Not Found.");}
            else
            {   
                Console.WriteLine($"Found:{person.Name}-{person.Age}");
            }

            int index = 1;
            var person_111 = list.ElementAtOrDefault(index);
            if (person_111 == null)
            {
                Console.WriteLine("Not Found.");
            }
            else 
            {
                Console.WriteLine($"Found index {index} is {person_111.Name}");
            }

            string name = "David"; 
            bool result = list.Any((x) => x.Name == name);
            if (result)
            {
                Console.WriteLine($"Found:{name}");
            }
            else
            {
                Console.WriteLine($"Not Found:{name}");
            }

            bool isAllBill = list.All((x) => x.Name == name); 
            if (isAllBill) 
            { 
                Console.WriteLine($"All are{name}"); 
            } 
            else 
            { 
                Console.WriteLine($"Someone isn't called {name}"); 
            }
            bool isAllOverForty = list.All((x) => x.Age >= 40); 
            if (isAllOverForty) 
            { 
                Console.WriteLine("Everyone over 40 yrs old"); 
            } 
            else 
            { 
                Console.WriteLine("Someone under 40 yrs old"); 
            }

            //計算list中，所有Age的總和
            int total = list.Sum((x) => x.Age);
            Console.WriteLine($"Sum of age:{total}");
            //取得list中,Age最小的值
            var minAge = list.Min((x) => x.Age);
            Console.WriteLine($"Minium age:{minAge}");
            //取得list中,Age最大的值
            var maxAge = list.Max((x) => x.Age);
            Console.WriteLine($"Maxium age:{maxAge}");
            //取得list中的數量
            //請注意Count和Count()是不一樣的
            int count = list.Count();
            Console.WriteLine($"Numbers of list:{count}");
            int countOfBill = list.Count((x) => x.Name == "Bill");
            Console.WriteLine($"Numbers of Bill in list:{countOfBill}");
            //取得所有年齡的平均值
            var average = list.Average((x) => x.Age);
            Console.WriteLine($"Average age:{average}");

            //找出名稱為Bill中的最小age
            var min = list.Where((x) => x.Name == "Bill").Min((x) => x.Age);
            Console.WriteLine($"Minium age in all of Bill: {min}");
            //計算名稱為Bill的年齡總和
            var total1 = list.Where((x) => x.Name == "Bill").Sum((x) => x.Age);
            Console.WriteLine($"Sum age in all of Bill: {total1}");
            var average1 = list.Where((x) => x.Name == "Bill").Average((x) => x.Age);
            Console.WriteLine($"Average age in all of Bill: {average1}");

            var list1 = new List<int> {1,2,3,4,5,6}; 
            var list2 = new List<int> {1,3,4,7,8,9}; 
            var union = list1.Union(list2); // Consider order, here list1 first, so the result should be {1, 2, 3, 4, 5, 6, 7, 8, 9}, otherwise would be {1, 3, 4, 7, 8, 9, 2, 5, 6}
            Console.WriteLine("The result of Union:"); 
            foreach (var item in union) 
            { 
                Console.Write($"{item} "); 
            }
            var intersect = list1.Intersect(list2); 
            Console.WriteLine("\nThe result of intersection:"); 
            foreach (var item in intersect) 
            {
                Console.Write($"{item} ");
            }
            var aEXb = list1.Except(list2); 
            Console.Write("\nA Except B:"); 
            foreach (var item in aEXb) 
            { 
                Console.Write($"{item} "); 
            }
            var bEXa = list2.Except(list1); 
            Console.Write("\nB Except A:"); 
            foreach (var item in bEXa) 
            { 
                Console.Write($"{item} "); 
            }

            var listt = new List<string> { "Taipei", "Taipei", "LA", "NewYork", "NewYork", "Taipei" };
            var resultt = listt.Distinct(); // 重複的資料去除
            Console.WriteLine("");
            foreach (var item in resultt) 
            {
                Console.WriteLine($"{item} "); 
            }

            var list3 = new List<string>{ "A","B","C","D","E","F","F"}; 
            var resultOfSkip = list3.Skip(3); 
            Console.WriteLine("Skip(3): ");  //DEFF
            Display(resultOfSkip); 
            var resultOfTake = list3.Take(3); 
            Console.WriteLine("Take(3): "); //ABC
            Display(resultOfTake); 
            var resultOfSkipTake = list3.Skip(2).Take(2); 
            Console.WriteLine("Skip(2).Take(2): "); //CD
            Display(resultOfSkipTake);
            var resultOfSkipTakeTake = list3.Skip(2).Take(3).Skip(1);
            Console.WriteLine("Skip(2).Take(3).Skip(1): "); //CDE (Because the final result of Skip(2).Take(3) is CDE, So do Skip(1) will be DE). It depense on the final result
            Display(resultOfSkipTakeTake);




            Console.ReadLine();

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
        static void Display(IEnumerable<string> source) 
        { 
            foreach (var item in source) 
            { 
                Console.WriteLine(item); 
            } 
        }

    }
}
