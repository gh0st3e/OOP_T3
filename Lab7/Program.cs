using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab6
{
    // Exception является базовым классом для всех исключений
    class AddException : Exception
    { 
        public AddException(string message)
            :base(message)
        { }
    }

    // NullReferenceException - это тип исключения вызывается, елси значение какой-то перменной равно null
    class BookException : NullReferenceException
    {
        public BookException(string message)
            :base(message)
        { }
    }

    public class exersice1
    {
        public enum Months
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        public struct User
        {
            public string name;
            public int age;
            public User(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
            public void DisplayInfo()
            {
                Console.WriteLine($"Name: {name}  Age: {age}");
            }

        }
    }

    public static partial class part1
    {
        public static void output()
        {
            Console.WriteLine("Ничего себе это partial class ");
        }
    }

    interface Ipublication
    {
        string Name { get; set; }
        string Type { get; set; }
        int Year { get; set; }
        int Price { get; set; }

    }

    public abstract class Apublication
    {
        public string Description { get; set; }

        public virtual string Display()
        {
            return Description;
        }

    }
    public class publication : Apublication, Ipublication
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }

        public publication(string name, string type, int year, int price)
        {
            Name = name;
            Type = type;
            Year = year;
            Price = price;
        }
        public override string Display()
        {
            return $"Название: {Name}, Тип: {Type}, Год издания: {Year}, Цена: {Price}";
        }
    }

    class Book : publication
    {
        public string emptystring;
        public int Countpages { get; set; }
        public Book(string Name, string Type, int Year, int Price, int countpages) : base(Name, Type, Year, Price)
        {
            Countpages = countpages;
        }
        public override string Display()
        {
            return $"Название: {Name}, Тип: {Type}, Год издания: {Year}, Цена: {Price}, Кол-во страниц: {Countpages}";
        }
    }
    class Tutor : publication
    {
        public int Countoftutors;
        public Tutor(string Name, string Type, int Year, int Price, int countoftutors) : base(Name, Type, Year, Price)
        {
            Countoftutors = countoftutors;
        }
        public override string Display()
        {
            return $"Название: {Name}, Тип: {Type}, Год издания: {Year}, Цена: {Price}, Кол-во издателей: {Countoftutors}";
        }
    }
    class Magazine : publication
    {
        public string Cover { get; set; }
        public Magazine(string Name, string Type, int Year, int Price, string cover) : base(Name, Type, Year, Price)
        {
            Cover = cover;
        }
        public override string Display()
        {
            return $"Название: {Name}, Тип: {Type}, Год издания: {Year}, Цена: {Price}, Обложка: {Cover}";
        }
    }
    class Add
    {
        private int countofpages;

        public int Countofpages
        {
            get
            {
                return countofpages;
            }
            set
            {
                if(value > 5)
                {
                    throw new AddException("Слишком большое кол-во страниц в рекламе");
                }
                else
                {
                    countofpages = value;
                }
            }
        }

        public Add(int Countofpages)
        {
            this.Countofpages = Countofpages;
        }
    } 
    public class Library
    {
        List<publication> Libraries = new List<publication>();
        public int tutorscount = 0;
        public int sum = 0;
        public void Push(publication item)
        {
            Libraries.Add(item);
            if (item.Type == "Учебник") tutorscount++;
            sum += item.Price;
        }

        public void Pop(int number)
        {
            Libraries.RemoveAt(number);
        }

        public void DisplayAll()
        {
            foreach (var item in Libraries)
            {
                Console.WriteLine(item.Display());
            }
        }
    }
    public static class Library_Controller
    {
        public static int TutorsCount(this Library library)
        {
            Console.WriteLine("Кол-во учебников: " + library.tutorscount);
            return library.tutorscount;
        }
        public static int PublicationPrices(this Library library)
        {
            Console.WriteLine("Цена всех изданий: " + library.sum);
            return library.sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Book book = new Book("Плаха", "Книга", 1976, 150, 300);
            Tutor tutor = new Tutor("C# и NET", "Учебник", 2011, 300, 1);
            Magazine magazine = new Magazine("Cosmopolitan", "Журнал", 1980, 50, "Глянцевая");

            Library library = new Library();
            library.Push(book);
            library.Push(tutor);
            library.Push(magazine);
            library.DisplayAll();
            Console.ReadKey();
            library.TutorsCount();
            library.PublicationPrices();
            Console.ReadKey();

            try
            {
                int zero = 0;
                Console.WriteLine(2 / zero);
            }
            catch (DivideByZeroException Exception)
            {
                Console.WriteLine(Exception.Message);
                Console.WriteLine(Exception.TargetSite);
                Console.WriteLine(Exception.Source);
            }
            Console.ReadKey();


            try
            {
                int[] array = { 1, 2, 3 };
                Console.WriteLine(array[3]);
            }
            catch (IndexOutOfRangeException Exception)
            {
                Console.WriteLine(Exception.Message);
                Console.WriteLine(Exception.TargetSite);
                Console.WriteLine(Exception.Source);
            }
            Console.ReadKey();

            try
            {
                Add add = new Add(6);
            }
            catch(AddException Exception)
            {
                Console.WriteLine(Exception.Message);
                Console.WriteLine(Exception.TargetSite);
                Console.WriteLine(Exception.Source);
            }
            Console.ReadKey();

            try
            {
                if (book.emptystring == null) 
                    throw new BookException("Обращаешься к объекту который равен null, беды с башкой");
                //Обычно система сама генерирует исключения, но они могут генерироваться с помощью оператора throw
            }
            catch(BookException Exception)
            {
                Console.WriteLine(Exception.Message);
                Console.WriteLine(Exception.TargetSite);
                Console.WriteLine(Exception.Source);
            }
            Console.ReadKey();

            try
            {
                int[] array = { 's', 'd', 'a', 'm', 'l', 'a', 'b', 'u' };
                for (int i = 0; i < array.Length; i++)
                {

                }
            }
            catch // Фильтры исключений позволяют обрабатывать исключения в зависимости от определенных условий. when(условие)
            {

            }
            finally
            {
                Console.WriteLine("Ошибок нет, ура");
            }
            Console.ReadKey();

            Console.WriteLine("Введите число");
            int number = int.Parse(Console.ReadLine());

            
            void findsqrt(int Number)
            {
                Debug.Assert(Number > 0,"Ты че, корня из отрицательных чисел нет");

                Console.WriteLine(Math.Sqrt(Number));
            }
            findsqrt(number);
            Console.ReadKey();
            //Для повторной генерации исключения нужно в блок catch вставить оператор throw
        }
    }
}
