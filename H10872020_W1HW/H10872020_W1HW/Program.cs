using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H10872020_W1HW
{

    class Program
    {
        private static String _title = null;

        static void Main(string[] args)
        {
            Product[] db = loadCSV("Product.csv");
            int i, ii;
            // 1. 計算所有商品的總價格 
            int allPrice =
                (from ord in db
                 select ord._price)
                .Sum();
            print("1. 所有商品的總價格: " + allPrice);

            // 2. 計算所有商品的平均價格
            double avgPrice =
                (from ord in db
                 select ord._price)
                .Average();
            print("2. 所有商品的平均價格: " + avgPrice);

            // 3. 計算商品的總數量
            int allCount =
                (from ord in db
                 select ord._count).Sum();
            print("3. 商品的總數量: " + allCount);

            // 4. 計算商品的平均數量
            double avgCount =
                (from ord in db
                 select ord._count).Average();
            print("4. 商品的平均數量: " + avgCount);

            // 5. 找出哪一項商品最貴
            IEnumerable<Product> maxPrice = (from ord in db
                                             where ord._price == db.Max(x => x._price)
                                             select ord);
            foreach (var item in maxPrice)
                print("5. 商品最貴: " + item._name + " 價格為：" + item._price);

            // 6. 找出哪一項商品最便宜
            IEnumerable<Product> minPrice = (from ord in db
                                             where ord._price == db.Min(x => x._price)
                                             select ord);
            foreach (var item in minPrice)
                print("6. 商品最便宜: " + item._name + " 價格為：" + item._price);


            // 7. 計算產品類別為 3C的商品總價
            int total3CPrice = (from ord in db
                                where ord._product == "3C"
                                select ord._price).Sum();
            print("7. 3C的商品總價: " + total3CPrice);

            // 8. 計算 產品類別為 飲料及食品的 商品總價
            int total8Price = (from ord in db
                               where ord._product == "食品" || ord._product == "飲料"
                               select ord._price).Sum();
            print("8. 飲料及食品的 商品價格: " + total8Price);

            // 9. 找出所有商品類別為食品 ，而且 商品數量大於 100的商品
            var total9Price = (from ord in db
                               where ord._product == "食品" && ord._count > 100
                               select ord);
            print("9. 類別為食品，而且商品數量大於100的商品: ");
            foreach (var item in total9Price)
                print("   " + item._name + " \t數量為：" + item._count);


            // 10. 找出各個商品類別底下 有哪些 商品的價格 是大於 1000的商品
            print("10. 各個商品類別底下 有哪些 商品的價格 是大於 1000的商品 ");
            var total10Price = (from ord in db
                                where ord._price > 1000
                                select ord).GroupBy(o => o._product);
            foreach (var d in total10Price)
            {
                print("\t" + d.Key + ":");

                foreach (var dd in d)
                    print("\t\t" + dd._name + " 價格為: " + dd._price);
            }

            // 11. 呈上題，請計算該類別底下所有商品的平均價格
            print("11. 呈上題，請計算該類別底下所有商品的平均價格 ");
            var group = db.GroupBy(o => o._product);
            foreach (var d in group)
            {
                var d2 = (from ord in d
                              // 	where ord._price > 1000
                          select ord._price).Average();
                print("\t" + d.Key + " 的平均價格:" + d2);

            }

            // 12. 依照商品 價格 由高到低排序
            print("12. 依照商品 價格 由高到低排序 ");
            var sort12 = from e in db
                         orderby e._price descending
                         select e;
            foreach (var d in sort12)
            {
                print("\t" + d._name + " 的價格:" + d._price);
            }

            // 13. 依照商品 數量 由低到高排序
            print("13. 依照商品 數量 由低到高排序 ");
            var sort13 = from e in db
                         orderby e._count
                         select e;
            foreach (var d in sort13)
            {
                print("\t" + d._name + " 的數量:" + d._count);
            }

            // 14. 找出各商品類別底下，最貴的商品
            print("14. 各商品類別底下，最貴的商品 ");
            foreach (var d in group)
            {
                var d2 = (from ord in d
                          where ord._price == d.Max(x => x._price)
                          select ord);
                print("\t" + d.Key + " 最貴的是:");
                foreach (var d3 in d2)
                {
                    print("\t\t" + d3._name + " 價格：" + d3._price);

                }
            }

            // 15. 找出各商品類別底下，最便宜的商品
            print("15. 各商品類別底下，最便宜的商品 ");
            foreach (var d in group)
            {
                var d2 = (from ord in d
                          where ord._price == d.Min(x => x._price)
                          select ord);
                print("\t" + d.Key + " 最便宜的是:");
                foreach (var d3 in d2)
                {
                    print("\t\t" + d3._name + " 價格：" + d3._price);

                }
            }

            // 16. 找出價格小於等於 10000 的商品
            var q16 = (from ord in db
                       where ord._price <= 10000
                       select ord);
            print("16. 價格小於等於 10000的商品: ");
            foreach (var item in q16)
                print("   " + item._name + " \t價格為：" + item._price);

            // 17. 製作一頁 4 筆總共 5 頁的
            print("17. 製作一頁 4 筆，總共 5 頁的: ");
            for (ii = 0, i = 1; ii < db.Length; ii += 4, i++)
            {
                var q17 = db.Skip(ii).Take(4).ToList();
                print("\t第" + i + "頁的商品有：");

                foreach (var dd in q17)
                {
                    print("\t\t" + dd._name + " \t價格為：" + dd._price);
                }
            }

            Console.Write("\r\nPress any key to continue....");
            Console.Read();
        }

        // 輸出
        static public void print(Object obj)
        {
            Console.WriteLine(obj.ToString());
        }
        
        static public Product[] loadCSV(String fileName)
        {
            String line;
            try
            {
                // 建立 list
                ArrayList list = new ArrayList();
                // 開檔
                StreamReader sr = new StreamReader(fileName);

                while (true)
                {
                    // 讀一行
                    line = sr.ReadLine();
                    // 如果是空行，就結束
                    if (line == null)
                        break;
                    // 第一行，標題。只保留欄位，不做處理
                    if (_title == null)
                    {
                        _title = line;
                        continue;
                    }
                    // 建立並加到 list 
                    list.Add(new Product(line));
                }
                // 關檔
                sr.Close();

                //	Console.ReadLine();
                // 轉成陣列，並回傳
                return list.ToArray(typeof(Product)) as Product[];

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            // 回傳空的
            return new Product[0];
        }
    }


}
