using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public partial class Morrowind //partial class может объединяться с классом с таким же название из другого файла, при наличии ключ. слова partial
    {
        public void func_1()
        {
            Console.Write("Nictozestvo, ");
        }
    }

    public class Books
    {

        private string name;
        public string Name
        {
            set //Устанавливаем значение поля
            {
                if (name == "") 
                {
                    Console.WriteLine("Имя книги не задано");
                }
                else
                {
                    name = value;
                }
            }
            get //Возваращем значения поля
            {
                return name;
            }
        }

        private string author;
        public string Author
        {
            set
            {
                if (author == "")
                {
                    Console.WriteLine("Имя автора не задано");
                }
                else
                {
                    author = value;
                }
            }
            get
            {
                return author;
            }
        }

        private string pubhouse;
        public string Pubhouse
        {
            set
            {
                if (pubhouse == "")
                {
                    Console.WriteLine("Издательство не задано");
                }
                else
                {
                    pubhouse = value;
                }
            }
            get
            {
                return pubhouse;
            }
        }
        public int year { get; set; }
        public int pages { get; set; }
        public int price { get; set; }
        public string typebind { get; set; }

        public static int count = 0;

        public Random rnd = new Random();

        public readonly int ID;

        static Books() // Вызывается один раз при создании класса
        {
            Console.WriteLine("Начинаем");
        }
        public Books(string name, string author, string pubhouse, int year, int pages, int price, string typebind,int ID)
        {
            this.name = name;
            this.author = author;
            this.pubhouse = pubhouse;
            this.year = year;
            this.pages = pages;
            this.price = price;
            this.typebind = typebind;
            this.ID = rnd.Next();
            count++;
            Print();
        }
        string a;
        private Books(string a) //private class
        {
             this.a = a;
        }
        

        public void Print()
        {
            Console.WriteLine("name: " + name);
            Console.WriteLine("author: " + author);
            Console.WriteLine("pubhouse: " + pubhouse);
            Console.WriteLine("year: " + year);
            Console.WriteLine("pages: " + pages);
            Console.WriteLine("price: " + price);
            Console.WriteLine("typebind: " + typebind);
            var testpri = new Books("private is work"); //Создаем экземпляр private класса
            Console.WriteLine(testpri.a);
            Console.WriteLine();
            Console.WriteLine("Количество хранящихся объектов: " + count);
        }

        public static void Stat(ref int count) // ref - передача по ссылке. При передаче по ссылку изменяется сама перменная 
        {
            
        }
        //out работает для выходных параметров можно не использовать return
    }

    class Program
    {
        static void Create(Books[] books)
        {
            Console.WriteLine("Введите навзание книги: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите автора книги: ");
            string author = Console.ReadLine();
            Console.WriteLine("Введите название издателя: ");
            string pubhouse = Console.ReadLine();
            Console.WriteLine("Введите год выпуска: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите кол-во страниц: ");
            int pages = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите цену: ");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите тип переплета: ");
            string typebind = Console.ReadLine();
            int ID = 0;
            
            
            Books Book0 = new Books(name, author, pubhouse, year, pages, price, typebind,ID);
            books[0] = Book0;
           
            if (name == "") Book0.Name = "";
            if (author == "") Book0.Author = "";
            if (pubhouse == "") Book0.Pubhouse = "";
        }
        static void Main(string[] args)
        {
            Books Book1 = new Books("451 градус по фаренгейту", "Рэй Бредбери", "Эксмо", 1953, 256, 5, "Мягкий",0);
            Books Book2 = new Books("Жизнь Лениса Деонова", "Денис Леонов", "Женя Асадчий", 2103, 500, 0, "Твердый",0);
            
           

            Books[] books = new Books[3];
            Create(books);
            books[1] = Book1;
            books[2] = Book2;
            Console.ReadKey();

            Console.WriteLine("Введите имя автора: ");
            string author = Console.ReadLine();
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Author == author)
                {
                    Console.WriteLine("name: " + books[i].Name);
                    Console.WriteLine("author: " + books[i].Author);
                    Console.WriteLine("pubhouse: " + books[i].Pubhouse);
                    Console.WriteLine("year: " + books[i].year);
                    Console.WriteLine("pages: " + books[i].pages);
                    Console.WriteLine("price: " + books[i].price);
                    Console.WriteLine("typebind: " + books[i].typebind);
                    Console.WriteLine();
                }
            }
            Console.ReadKey();

            Console.WriteLine("Введите год выпуска: ");
            int year = int.Parse(Console.ReadLine());
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].year > year)
                {
                    Console.WriteLine("name: " + books[i].Name);
                    Console.WriteLine("author: " + books[i].Author);
                    Console.WriteLine("pubhouse: " + books[i].Pubhouse);
                    Console.WriteLine("year: " + books[i].year);
                    Console.WriteLine("pages: " + books[i].pages);
                    Console.WriteLine("price: " + books[i].price);
                    Console.WriteLine("typebind: " + books[i].typebind);
                    Console.WriteLine();
                }
            }
            Console.ReadKey();

            Morrowind nerevar = new Morrowind();
            nerevar.func_1();
            nerevar.func_2();
            Console.ReadKey();

            Books.Stat(ref Books.count);
            Console.ReadKey();
      
        }
    }
}
