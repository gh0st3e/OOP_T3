using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// При отложенном выполнении LINQ-выражение не выполняется, пока не будет произведена итерация или перебор по выборке.
namespace Lab11
{
    class Library
    { 
        public string Name { get; set; }
        public int CountOfPages { get; set; } 
        public string Author { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //string[] Months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            //int NumberOfSymbols = int.Parse(Console.ReadLine());

            //IEnumerable<string> CurrentMonths = from n in Months
            //                                    where n.Length < NumberOfSymbols
            //                                    select n;
            //foreach (string Month in CurrentMonths)
            //{
            //    Console.WriteLine(Month);
            //}
            //Console.ReadKey();

            List<Library> libraries = new List<Library>
            {
                new Library{Name = "C# and .Net", CountOfPages = 1500,Author = "Rihter",Year=2009,Price=100 },
                new Library{Name = "Над пропастью во ржи", CountOfPages = 2005,Author = "Сэлинджер",Year=2000,Price=200  },
                new Library{Name = "Хроники Нарнии", CountOfPages = 3020,Author = "не помню",Year=2001,Price=300  },
                new Library{Name = "Психология влияния", CountOfPages = 40,Author = "Чалдини",Year=2002,Price=400  },
                new Library{Name = "451 градус по Фаренгейту", CountOfPages = 500,Author = "Бредберри",Year=2003,Price=500  },
                new Library{Name = "Ведьмак", CountOfPages = 8200,Author = "Сапковский",Year=2004,Price=600  },
                new Library{Name = "Преступление и наказание", CountOfPages = 700,Author = "Достоевский",Year=2005,Price=700  },
                new Library{Name = "Мастер и Маргарита", CountOfPages = 800,Author = "Булгаков",Year=2006,Price=800  },
                new Library{Name = "Плаха", CountOfPages = 900,Author = "Айтматов",Year=2007,Price=900  },
                new Library{Name = "Бегущий из лабиринта", CountOfPages = 1000,Author = "Дэшнер",Year=2008,Price=1000  },
            };

            //Console.WriteLine("Укажите автора и год");
            string Author = Console.ReadLine();
            int Year = int.Parse(Console.ReadLine());

            var CurrentBook = from book in libraries
                                 where book.Author == Author && book.Year == Year
                                 select book;

            //foreach (var book in CurrentBook)
            //{
            //    Console.WriteLine(book.Author + book.Year);
            //}
            //Console.ReadKey();

            int lowprice = 1000;


            var lowPricebooks = libraries
                                .OrderBy(book => book.Price)
                                .Where(book => book.Price < lowprice)
                                .Take(4)
                                .Select(book => book);
                                

            
                                 
            Console.WriteLine("Точечная нотация");
            foreach(var book in lowPricebooks)
            {
                Console.WriteLine(book.Name + " " +book.Year);
            }


            Console.WriteLine("Укажите год");
            Year = int.Parse(Console.ReadLine());
            CurrentBook = from book in libraries
                              where book.Year > Year
                              select book;

            foreach (var book in CurrentBook)
            {
                Console.WriteLine(book.Name + " " + book.Year);
            }
            Console.ReadKey();


            

            int MinLength = (from book in libraries
                            select book.CountOfPages).Min();


            Console.WriteLine(MinLength);
            Console.ReadKey();

            CurrentBook = from book in libraries
                               orderby book.CountOfPages
                               select book;

            foreach(var book in CurrentBook.Take(5))
            {
                Console.WriteLine(book.Name);
            }
            Console.ReadKey();

            CurrentBook = from book in libraries
                          orderby book.Price
                          select book;

            Console.WriteLine();
            foreach (var book in CurrentBook)
            {
                Console.WriteLine(book.Name);
            }
            Console.ReadKey();
        }
    }
}
