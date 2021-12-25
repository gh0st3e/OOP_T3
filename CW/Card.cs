using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW
{
    interface ICheck
    {
        bool Check();
    }
    public class Card : ICheck
    {
        public int Number { get; set; }
        public int Month { get; set; }

        readonly public int Year;

        private int balance;
        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if (value > 0) balance = value;
            }
        }

        public Card(int number, int month, int year, int balance)
        {
            Number = number;
            Month = month;
            Year = year;
            this.balance = balance;
        }

        public bool Check()
        {
            if (Balance > 0)
            {
                Console.WriteLine("Баланс положительный");
                return true;
            }
            else
            {
                Console.WriteLine("нулевой баланс");
                return false;
            }
        }

        public void Operation()
        {
            string[] operation = { "Название" + "Баланс" };
           
            
        }

        

        public static Card operator +(Card card1, int sum)
        {
            CardWithHistory History1 = new CardWithHistory(1, 0, 0, 0);
            History1.HistoryOfBalance(card1.Number, card1.Balance + sum);
            return new Card(card1.Number, card1.Month, card1.Year, card1.Balance + sum);
        }
        public static Card operator -(Card card1, int sum)
        {
            int newbalance = card1.Balance - sum;
            if (newbalance < 0)
            {
                Console.WriteLine("Недостаточно средств");
                return new Card(card1.Number, card1.Month, card1.Year, card1.Balance);
            }

            else
            {
                CardWithHistory History1 = new CardWithHistory(1, 0, 0, 0);
                History1.HistoryOfBalance(card1.Number, card1.Balance -sum);
                return new Card(card1.Number, card1.Month, card1.Year, card1.Balance - sum);
            }
        }
    }
    

}
