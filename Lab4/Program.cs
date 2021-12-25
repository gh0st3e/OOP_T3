using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class IntTest
    {
        public int Value { get; set; }
        

        public static IntTest operator +(IntTest c1, IntTest c2)
        {
            return new IntTest { Value = c1.Value + c2.Value };
        }
    }

    public class Cars
    {
        public string Nameofcar { get; set; }

        


        //Перегрузка операторов заключается в определении в классе, для объектов которого мы хотим определить оператор, специального метода:
        //ПОзволяет добавить к уже сущствущим унарным или бинарным оператарам новые методы, но не изменят их приоритетность!
        //public static int operator >>(Cars s1, Cars s2) 
        //{
            
        //}
        //public static int operator +(Cars cars, int s2)
        //{
        //    return cars;
        //}
        // Вложенные классы имеют досутп ко всем полям класса в который вложен, даже к закрытым и нужен для обслуживания класса в который вложен
        public class Owner
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Corp { get; set; }
            public string Date { get; set; }

            public Owner(string id, string name, string corp, string Nameofcar)
            {
                Id = id;
                Name = name;
                Corp = corp;
                Nameofcar = "a";
            }

        }

        Date date;

    }

    public class Date
    {
        public static string getdate()
        {
            DateTime curdate = new DateTime();
            curdate = DateTime.Now;
            return curdate.ToString();
        }
    }
    // Методы расширения позволяют добавить новые методы, если досутпа к классу нет.

    public static class StaticOperation
    {
        public static int Count(this List<Cars> ts)
        {
            return ts.Count;
        }

        public static string findword(this List<Cars> mycars)
        {
            string Biggestword = string.Empty;
            for (int i = 0; i < mycars.Count; i++)
            {
                string[] given = mycars[i].Nameofcar.Split(' ');
                for (int j = 0; j < given.Length; j++)
                {
                    if (given[j].Length > Biggestword.Length) Biggestword = given[j];
                }
            }
            return Biggestword;
        }

        public static List<Cars> deletelastitem(this List<Cars> mycars)
        {
            mycars.Remove(mycars.Last());
            return mycars;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            List <Cars> mycars = new List<Cars>();
            mycars.Add(new Cars() { Nameofcar = "Skoda Rapid" });
            mycars.Add(new Cars() { Nameofcar = "Renault Sandero" });
            mycars.Add(new Cars() { Nameofcar = "Peugeout 406" });
            mycars.Add(new Cars() { Nameofcar = "Geely Atlas" });

            for (int i = 0; i < mycars.Count; i++)
            {
                Console.WriteLine(mycars[i].Nameofcar);
            }
            Console.ReadKey();

            Console.WriteLine(StaticOperation.findword(mycars));
            Console.ReadKey();

            StaticOperation.deletelastitem(mycars);

            for (int i = 0; i < mycars.Count; i++)
            {
                Console.WriteLine(mycars[i].Nameofcar);
            }
            Console.ReadKey();

            Cars.Owner Denis = new Cars.Owner("1", "Denis", "SCAM inc.", "a");
            Denis.Date = Date.getdate();
            Console.WriteLine(Denis.Id);
            Console.WriteLine(Denis.Name);
            Console.WriteLine(Denis.Corp);
            Console.WriteLine(Denis.Date);
            Console.ReadKey();

            Console.WriteLine(StaticOperation.Count(mycars));
            Console.ReadKey();
            int del = 1 >> 0; // Операторы перегрузки
            mycars.RemoveAt(del);
            int add = 0 + 0; // Оператор перегузки
            mycars.Insert(add, new Cars() { Nameofcar = "Honda Accord" });
            for (int i = 0; i < mycars.Count; i++)
            {
                Console.WriteLine(mycars[i].Nameofcar);
            }
            IntTest int1 = new IntTest { Value = 42 };
            IntTest int2 = new IntTest { Value = 24 };
            IntTest int3 = int1 + int2;
            Console.WriteLine(int3.Value);
            Console.ReadKey();
        }

    }
}



        



        

        