using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllClassSample002
{
    public class BaseClass
    {
        public virtual void Execute() 
        { 
            Console.WriteLine("BaseClass Execute Method"); 
        }
        public virtual void Begin()
        { 
            Console.WriteLine("BaseClass Begin Method"); 
        }
    }
    public class Class1 : BaseClass
    {
        public override void Execute() //覆寫
        {
            Console.WriteLine("Class1 Execute Method");
        }
    }
    public class Class2 : Class1 //建立Class2 class(繼承Class1), 這表示父類別(Class1)的方法(Exectue())若為override，子類別(Class2) 一樣可以覆寫它
    {
        public override sealed void Execute() //override (覆寫) Execute()且宣告為sealed (密封), 若祖父類別(BaseClass)的方法(Begin())若為virtual/override，而父類別(Class1)雖然沒有覆寫，但子類別(Class2)一樣可以覆寫
        { 
            Console.WriteLine("Class2 Execute Method");
        }
        public override void Begin() //覆寫
        { 
            Console.WriteLine("Class2 Begin Method"); 
        }
    }
    /*
    public class Class3 : Class2
    {
        public override void Execute() // 無法複寫繼承成員Class2.Execute() 因為它被密封(sealed)
        {
            Console.WriteLine("Class3 Execute Method");
        }
    }
    */
}
