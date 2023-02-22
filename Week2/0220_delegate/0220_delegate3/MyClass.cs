using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0220_delegate3
{
    public delegate bool MyPredicate(string value);

    public class MyClass
    {
        public List<string> DoWhere(List<string> source, Func<string, bool> predicate)
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
