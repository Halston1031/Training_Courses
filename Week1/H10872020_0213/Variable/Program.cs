using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass o1 = new MyClass();
            int r = o1.Number; //call get
            o1.Number = 999; //call set
            Console.WriteLine(o1.Number);
            Console.ReadKey();
        }
        public class MyClass
        {
            private int number;

            public int Number
            {
                get // 讀取屬性時會執行存取子的程式碼區塊 get, 沒有 get 存取子的屬性則視為唯寫
                {
                    return number;
                }

                set // 當屬性指派值時，就會執行存取子的程式碼區塊 set, 沒有 set 存取子的屬性會視為唯讀
                {
                    if (value > 100)
                    {
                        value = 100;
                    }
                    number = value;
                }
            }
        }
    }
}
