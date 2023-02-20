using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind_Player_Ai
{
    class Program
    {
        // 判斷數字是否正確
        static bool checkInt(int value)
        {
            int i, k;
            string str = String.Format("{0:0000}", value);
            if (str.Length != 4)
                return false;
            for (i = 0; i < 4; ++i) // 一組數字中，一個數字只能出現一次，若重複出現就不能被使用
                for (k = i + 1; k < 4; ++k)
                    if (str[i] == str[k])
                        return false;

            return true;
        }

        // 判斷數字是否正確
        static bool checkAB(int value, int ans, int A, int B)
        {
            try
            {

                int a, b, i;
                string strValue = String.Format("{0:0000}", value);
                string strAns = String.Format("{0:0000}", ans);

                a = b = 0;
                // 交集
                var intersect = strValue.Intersect(strAns);
                b = intersect.Count();
                if (b > 0)
                {
                    for (i = 0; i < 4; ++i)
                        if (strValue[i] == strAns[i])
                        {
                            a++;
                            b--;
                        }
                }

                /*
				for (i = 0; i < 4; ++i)
				for (k = 0; k < 4; ++k)
				{
					if (strValue[i] == strAns[k]) // 相同
					{
						if (i == k) // 相同位置
							a++;
						else
							b++;
					}
				}*/
                // 相同，完成
                if ((A == a) && (B == b))
                    return true; ;
            }
            catch (Exception)
            {
            }

            return false;
        }

        static void print(object obj)
        {
            Console.WriteLine(obj.ToString());

        }

        static void pause()
        {
            Console.Write("\r\nPress any key to continue....");
            Console.Read();
        }

        static void Main(string[] args)
        {
            int i, ans, A, B, guess, mode;
            string strAns;
            Random random = new Random();
            List<int> buf = new List<int>();

            print("1. PC guess");
            print("2. Play guess");

            Console.Write("select game mode(1or2): ");
            while (true)
            {
                try
                {
                    mode = int.Parse(Console.ReadLine());
                    if ((mode == 1) || (mode == 2))
                        break;

                }
                catch (Exception)
                {
                }

                print("enter int error");
            }

            // 初始資料
            for (i = 0; i < 10000; ++i)
                buf.Add(i);
            // 取得可用答案
            var ansBuf = (from d in buf
                          where checkInt(d)
                          select d).ToList();

            if (mode == 1)
            {
                // 開始
                print("buf size: " + ansBuf.Count);

                while (true)
                {
                    // 輸入答案
                    ans = ansBuf[random.Next(ansBuf.Count)];
                    strAns = String.Format("{0:0000}", ans);
                    print("\nai guess " + strAns);
                    
                    Console.Write("enter A,B(ex: 0A2B ): ");

                    while (true)
                    {
                        try
                        {
                            string enter = Console.ReadLine();
                            if (enter[1] == 'A')
                                if (enter[3] == 'B')
                                {
                                    A = int.Parse("" + enter[0]);
                                    B = int.Parse("" + enter[2]);
                                    if ((A + B) <= 4)
                                        break;
                                }

                        }
                        catch (Exception)
                        {
                        }

                        print("enter int error");
                    }
                    
                    if (A == 4)
                    {
                        print("Yahoo !!!");
                        break;
                    }

                    // 判斷A,B
                    ansBuf = (from d in ansBuf
                              where checkAB(d, ans, A, B)
                              select d).ToList();
                    // 都沒有了
                    if (ansBuf.Count == 0)
                    {
                        print("error: ansBuf.Equals");
                        break;
                    }
                    // 只剩一個
                    
                    print("ansBuf size: " + ansBuf.Count);
                    if (ansBuf.Count < 100)
                    {
                        Console.Write("ansBuf data:");
                        foreach (var d in ansBuf)
                            Console.Write(" " + d);
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                // 輸入答案
                ans = ansBuf[random.Next(ansBuf.Count)];
                strAns = String.Format("{0:0000}", ans);
                print("ai ans: " + strAns);
                while (true)
                {
                    Console.Write("Enter your guess: ");
                    
                    while (true)
                    {
                        try
                        {
                            guess = int.Parse(Console.ReadLine());
                            if (checkInt(guess)) // 判斷是否正確
                            {
                                break;
                            }
                        }
                        catch (Exception)
                        {
                        }

                        print("Enter int error");
                    }

                    // check a , b 
                    string strValue = String.Format("{0:0000}", guess);

                    A = B = 0;
                    // 交集
                    var intersect = strValue.Intersect(strAns);
                    B = intersect.Count();
                    if (B > 0)
                    {
                        for (i = 0; i < 4; ++i)
                            if (strValue[i] == strAns[i])
                            {
                                A++;
                                B--;
                            }
                    }

                    print("" + A + "A" + B + "B");
                    if (A == 4)
                    {
                        print("You win !!!");
                        break;
                    }
                }
            }

            print("Bye Bye ~~ See You ^^");

            pause();
        }
    }
}
