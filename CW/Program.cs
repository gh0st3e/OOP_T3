using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort maxushort = 65535;
            Console.WriteLine(maxushort);
            string[] Days = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };
            foreach(string day in Days)
            {
                Console.WriteLine(day);
            }
            Console.ReadKey();
            
            Card card1 = new Card(1, 8, 2021, 1000);
            Card card2 = new Card(2, 4, 2003, 5000);
            Card card3 = new Card(3, 5, 5, 0);

            CardWithHistory History1 = new CardWithHistory(1, 0, 0, 0);

            card1 -= 2000;
            card2 += 500;
            card2 += 1000;
            card2 -= 3000;
            card1 += 5000;
            
            
            
            Console.WriteLine(card1.Balance);
            card3.Check();
            
            Console.ReadKey();
        }
    }
}
