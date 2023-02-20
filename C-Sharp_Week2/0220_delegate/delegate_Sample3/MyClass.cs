using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_Sample3
{
    public delegate bool MyPredicate(string value);

    public class MyClass
    {
        // DoWhere本身不知道該怎麼判斷，完全靠 predicate 告訴它該怎麼判斷所以我們會從外部傳進判斷式
        public List<string> DoWhere(List<string> source, MyPredicate predicate)
        {
            List<string> result = new List<string>();
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

    }
}
