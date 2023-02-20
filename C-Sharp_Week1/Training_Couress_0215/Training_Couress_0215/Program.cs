using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Couress_0215
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var enumerator = GetStrings().GetEnumerator();
            try 
            {
                while (enumerator.MoveNext())
                    Console.WriteLine(enumerator.Current);
            }
            finally 
            { 
                enumerator.Dispose(); 
            }
            Console.ReadLine();
        }

        static IEnumerable<string> GetStrings() 
        {
            /* yield return "A";
             yield return "B";
             yield return "C";*/
            return new EnumerableString();
        }

        internal class EnumerableString : IEnumerable<string>
        {
            public IEnumerator<string> GetEnumerator() 
            {
                return new Enumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            { 
                return GetEnumerator();
            }
        }
        private class Enumerator : IEnumerator<string>
        { 
            public string Current { get; private set; }
            object IEnumerator.Current { get { return Current; } }
            private int index = 0;
            public bool MoveNext()
            {
                switch (index)
                {
                    case 0:
                        Current = "A";
                        index++;
                        return true;
                    case 1:
                        Current = "B";
                        index++;
                        return true;
                    case 2:
                        Current = "C";
                        index++;
                        return true;
                    default:
                        return false;
                }

            }
        }
    }
}
