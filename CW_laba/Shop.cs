using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_laba
{
    class Shop : IComparer<Shop>
    {
        public string[] Names { get; set; }
        public int[] Prices { get; set; }

        public Shop(string[] names, int[] prices)
        {
            Names = names;
            Prices = prices;
        }

        public string this[int index]
        {
            set
            {
                Names[index] = value;
            }

            get
            {
                return Names[index];
            }
        }

        public int Compare(Shop p1, Shop p2)
        {
            if (p1.Names.Length > p2.Names.Length)
            {
                Console.WriteLine("В магазине 1 больше товаров чем в магазине 2");
                return 1;
                
            }
                
            else if (p1.Names.Length < p2.Names.Length)
            {
                Console.WriteLine("В магазине 2 больше товаров чем в магазине 1");
                return -1;
            }
                
            else
                return 0;
        }

    }
}
