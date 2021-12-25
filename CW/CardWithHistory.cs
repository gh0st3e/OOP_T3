using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW
{
    class CardWithHistory : Card
    {
        public CardWithHistory(int number, int month, int year, int balance) : base(number, month, year, balance) { }



       

        public void HistoryOfBalance(int number, int balance)
        {
            string[] Operations = {"Имя карты: " + number + "Баланс " + balance};
            foreach(string word in Operations)
            {
                Console.WriteLine(word);

            }
        }
      
    }
}
