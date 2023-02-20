using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0220_delegate
{
    public delegate void SomeAction(string message); //宣告一個委派型別
    internal class Program
    {
        static void Main(string[] args)
        {
            // 標準寫法
            SomeAction action1 = new SomeAction(ShowText);
            action1 += ShowMessage;
            // 也可以這樣寫
            SomeAction action2 = ShowText;
            // 標準寫法
            action1.Invoke("第一個");
            // 也可以這樣寫
            action2("第二個");

            Console.ReadLine();

        }
        static void ShowText(string msg) //只管型別不管參數名稱
        { 
            Console.WriteLine($"ShowText {msg}");
        }
        static void ShowMessage(string str)
        {
            Console.WriteLine($"ShowMessage {str}");
        }
    }
}
