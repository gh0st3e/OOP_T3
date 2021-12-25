using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    interface Iprogram // Интерфейс - ссылочный тип определяет функционал например набор методов
    {
        void Name();
    }

    abstract class Tprogram // Для преобразования методов
    {
        public virtual void Description()
        {
            Console.WriteLine("Описание: ");
        }
        
    }
    sealed class Magazine : Tprogram, Iprogram
    {
        public string name { get; set; }
        public string description { get; set; }

        public void Name()
        {
            Console.WriteLine($"Назввание:  { name}");
        }
        public override void Description()
        {
            Console.WriteLine($"Описание:  { description}");
        }
        public override string ToString()
        {
            return $"{name}, {description}";
        }
    }

    sealed class Book : Tprogram, Iprogram
    {
        public string name { get; set; }
        public string description { get; set; }
        

        public void Name()
        {
            Console.WriteLine($"Назввание:  { name}");
        }
        public override void Description()
        {
            Console.WriteLine($"Описание:  { description}");
        }
        public override string ToString()
        {
            return $"{name}, {description}";
        }
    }

    sealed class Person : Tprogram, Iprogram
    {
        public string name { get; set; }
        public string description { get; set; }
        public string film { get; set; }
        public void Name()
        {
            Console.WriteLine($"Назввание:  { name}");
        }
        public override void Description()
        {
            Console.WriteLine($"Описание:  { description} снималась в фильме {film}");
        }
        public override string ToString()
        {
            return $"{name}, {description},{film}";
        }
    }

    
    class Printer
    {
        public void IamPrinting(Tprogram obj)
        {
            Console.WriteLine($"Тип этого объекта: " + obj.GetType());
            Console.WriteLine($"Данные :" + obj.ToString());
        }
    }

    interface Icloneable
    {
        void DoClone();
    }
    abstract class BaseClone
    {
        public abstract void DoClone();
    }
    class IntAbstrClass : BaseClone, Icloneable
    {
        public override void DoClone()
        {
            Console.WriteLine("Хоба, мой отец - абстрактный класс");
        }
        void Icloneable.DoClone()
        {
            Console.WriteLine("Хоба, моя мать - интерфейс");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Magazine magazine = new Magazine { name = "PLayboy", description = "horny magazine" };
            magazine.Name();
            magazine.Description();
            Book book = new Book { name = "Над пропастью во ржи", description = "Книга о жизни подростка" };
            book.Name();
            book.Description();
            Person person = new Person { name = "Марго Робби", description = "BOOBA", film = "Волк с Уолл-Стрит" };
            person.Name();
            person.Description();

            Printer print = new Printer();
            print.IamPrinting(magazine);
            print.IamPrinting(book);
            print.IamPrinting(person);

            object obj1 = new Magazine { name = "test1", description = "test1_1" };
            object obj2 = "hello world";
            //as - С помощью него программа пытается преобразовать выражение к определенному типу, при этом не выбрасывает исключение. 
            //В случае неудачного преобразования выражение будет содержать значение null:
            Magazine mag1 = obj1 as Magazine;
            Magazine mag2 = obj2 as Magazine;
            if (mag1 != null) Console.WriteLine("Оп я преобразовался :)");
            if (mag2 != null)
            {
                Console.WriteLine("Оп я преобразовался :)");
            }
            else
            {
                Console.WriteLine("Оп, я не преобразовался :(");
            }
            //Выражение obj1 is Magazine проверяет, является ли переменная obj1 объектом типа Magazine. Но так как в данном случае явно не является, 
            //то такая проверка вернет значение false, и преобразование не сработает.
            if (obj1 is Magazine) Console.WriteLine("Я объект типа Magazine, честно :)");
            if (obj2 is Magazine)
            {

            }
            else Console.WriteLine("Оп, я шпион :(");
            Console.ReadKey();

            IntAbstrClass IAC = new IntAbstrClass();
            IAC.DoClone();
            ((Icloneable)IAC).DoClone();
            Console.ReadKey();
        }
    }
}
