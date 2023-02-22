using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllClassSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyShape rect  = new MyRectangle() { Width = 10, Height = 10}; // MyRectangle() 呼叫了自己的覆寫後的 GetArea
            Console.WriteLine($"長方形的面積是{rect.GetArea()}");
            MyShape circle = new MyCircle() { Radius = 3 }; // MyCircle() 呼叫了自己的覆寫後的 GetArea
            Console.WriteLine($"圓形的面積是{circle.GetArea()}");
            Console.ReadLine();
        }
    }
}
