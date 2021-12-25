using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_laba
{
    
    class Program
    {
        static void Main(string[] args)
        {
            string str = "абв аед гдж оап нпер";
            string j = "дж";
            str = str.Replace("о", "a");         
            str = str.Replace("д", j);
            Console.WriteLine(str);

            int[,] arrayofinteger = { { 0, 0,0,0,0,0,0,0 }, { 1,1,1,1,1,1,1,1}, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 1, 1, 1, 1, 1, 1, 1, 1 },
                { 0, 0, 0, 0, 0, 0, 0, 0 }, { 1, 1, 1, 1, 1, 1, 1, 1 }, { 0, 0,0,0,0,0,0,0 }, { 1,1,1,1,1,1,1,1}, };

            for(int i=0;i<arrayofinteger.GetLength(0);i++)
            {
                for (int k = 0; k < arrayofinteger.GetLength(1); k++)
                {
                    Console.Write(arrayofinteger[i,k]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

            string[] shop1names = { "a", "b", "c","d" };
            int[] shop1prices = { 1, 2, 3, 4 };

            string[] shop2names = { "e", "f", "g" };
            int[] shop2prices = { 5, 6, 7, 8 };


            Shop shop1 = new Shop(shop1names, shop1prices);
            Shop shop2 = new Shop(shop2names, shop2prices);

            foreach(string word in shop1.Names)
            {
                Console.WriteLine(word);
            }
            Console.ReadKey();

            shop1.Compare(shop1, shop2);

            Electronic electronic1 = new Electronic { Name = "electronic1", Memory = 100 };
            Electronic electronic2 = new Electronic { Name = "electronic2", Memory = 200 };

            Memory memory1 = new Memory { Name = "memory1", Memorycount = 300 };
            Memory memory2 = new Memory { Name = "memory2", Memorycount = 400 };

            Flash flash1 = new Flash { Name = "flash1", Memorycount = 500 };
            Flash flash2 = new Flash { Name = "flash1", Memorycount = 600 };

            List<Electronic> ts = new List<Electronic>();

            ts.Add(electronic1);
            ts.Add(electronic2);
            ts.Add(memory1);
            ts.Add(memory2);
            ts.Add(flash1);
            ts.Add(flash2);

            flash1.Write("str");
            Console.ReadKey();

            bool proverka = electronic2 == electronic1;
            Console.WriteLine(proverka);
            Console.ReadKey();

        }
    }
}
