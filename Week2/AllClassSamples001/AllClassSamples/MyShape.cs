using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllClassSamples
{
    public abstract class MyShape
    {
        public abstract double GetArea();
    }
    public class MyRectangle : MyShape
    {
        public double Width { get; set;}
        public double Height { get; set;}
        public override double GetArea() // override, MyRectangle 覆寫了 MyShape 的 GetArea 方法
        {
            return Width * Height;
        }
    }
    public class MyCircle : MyShape
    {
        public double Radius{ get; set;}
        public override double GetArea()
        {
            return Math.PI* Math.Pow(Radius, 2);
        }
    }
}
