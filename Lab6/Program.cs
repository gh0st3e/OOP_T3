using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class EnumandStruct
    {
        public enum Months // Перечисления представляют набор логически связанных констант. Могут иметь тип, указывается через :. По умолчанию int. 
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

        // Может хранить перменные и методы, может определять конструктор(не обязательно его вызывать, но нужно проинициализировать все поля структуры.
        // Если определяем конструктор, то должны проинициализировать все поля структуры
        // Класс - ссылочный тип, структура - значимый тип
        // Структуры передаются по значению(создается копия) классы по ссылке
        
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
    public abstract class publication : Apublication, Ipublication
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
    
    // Класс-контейнер по сути является объединением экземпляров других классов.
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

    // Класс-контроллер содержит методы, которые позволяют управлять классом-контейнером
    public static class Library_Controller
    {
        public static void TutorsCount(this Library library)
        {
            Console.WriteLine("Кол-во учебников: " + library.tutorscount);
        }
        public static void PublicationPrices(this Library library)
        {
            Console.WriteLine("Цена всех изданий: " + library.sum);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            EnumandStruct.Months April = EnumandStruct.Months.April;
            Console.WriteLine(April);
            Console.WriteLine((int)April);
            Console.ReadKey();

            EnumandStruct.User user1 = new EnumandStruct.User( "Denis", 18 );
            user1.DisplayInfo();
            Console.ReadKey();

            part1.output();
            part1.output2();
            Console.ReadKey();

            Book book = new Book("Плаха","Книга",1976,150,300);
            Tutor tutor = new Tutor("C# и NET", "Учебник", 2011, 300,1);
            Magazine magazine = new Magazine("Cosmopolitan", "Журнал", 1980, 50,"Глянцевая");

            Library library = new Library();
            library.Push(book);
            library.Push(tutor);
            library.Push(magazine);
            library.DisplayAll();
            Console.ReadKey();
            library.TutorsCount();
            library.PublicationPrices();
            Console.ReadKey();
        }
    }
}
