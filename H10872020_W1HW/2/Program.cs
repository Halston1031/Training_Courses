using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
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
            for (i = 0; i < 4; ++i)
                for (k = i + 1; k < 4; ++k)
                    if (str[i] == str[k])
                        return false;

            return true;
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
            bool isRun = true;
            print("歡迎來到 1A2B 猜數字的遊戲~");

            while (isRun)
            {
                int i, ans, A, B, guess;
                string strAns;
                Random random = new Random();
                List<int> buf = new List<int>();
                
                // 初始資料
                for (i = 0; i < 10000; ++i)
                    buf.Add(i);
                // 取得可用答案
                var ansBuf = (from d in buf
                              where checkInt(d)
                              select d).ToList();
                
                // 輸入答案
                ans = ansBuf[random.Next(ansBuf.Count)];
                strAns = String.Format("{0:0000}", ans);

                print("Ai ans: " + strAns);
                while (true)
                {
                    print("------");
                    Console.Write("請輸入 4 個數字: ");
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

                    // check a, b 
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

                    print("判定結果是" + A + "A" + B + "B");
                    if (A == 4)
                    {
                        print("恭喜你!猜對了!!");
                        break;
                    }
                }
                
                print("------");
                Console.Write("你要繼續玩嗎 ? (y / n) : ");
                while (true)
                {
                    try
                    {
                        string input = Console.ReadLine();
                        if ((input[0] == 'n') || (input[0] == 'N'))
                        {
                            isRun = false;
                            break;
                        }
                        else if ((input[0] == 'y') || (input[0] == 'Y'))
                        {
                            break;
                        }
                    }
                    catch (Exception)
                    {
                    }
                    print("Enter error");

                }
            }
            print("遊戲結束,下次再來玩喔~");
            pause();
        }
    }
}