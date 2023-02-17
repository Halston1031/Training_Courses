using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H10872020_W1HW
{
    internal class Product
    {
        public string _id;          // 商品編號
        public string _name;        // 商品名稱
        public int _count;          // 商品數量
        public int _price;          // 價格
        public string _product;     // 商品類別

        public Product(string line)
        {
            string[] strs = line.Split(',');
            _id = strs[0];
            _name = strs[1];
            _count = int.Parse(strs[2]);
            _price = int.Parse(strs[3]);
            _product = strs[4];
        }
    }
}
