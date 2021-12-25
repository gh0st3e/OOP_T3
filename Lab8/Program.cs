using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab8
{
    class Program
    {
        interface IActions<T>
        {
            void Add(T nameofcar);
            void Delete(T number);
            void Display();
        }

        class CollectionType<T> : IActions<T> where T : class
        {
            List<T> Mycars = new List<T>();

            public static T number;
            public void Add(T nameofcar)
            {
                Mycars.Add(nameofcar);
            }
            public void Delete(T number)
            {
                Mycars.Remove(number);
            }
            public void Display()
            {
                foreach (T elem in Mycars)
                {
                    Console.WriteLine(elem);
                }
                
            }
            public void WriteToFile()
            {
                StreamWriter sw = new StreamWriter("C:\\Study\\forlab8\\Test.txt");
                foreach (T elem in Mycars)
                {
                    sw.WriteLine(elem);
                }
                sw.Close();
            }
            public void ReadFromFile()
            {
                String line;
                StreamReader sr = new StreamReader("C:\\Study\\forlab8\\Test.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
        }


        static void Main(string[] args)
        {
            Car car1 = new Car("Skoda Rapid",2018);
            Car car2 = new Car("Renault Sandero", 2010);
            Car car3 = new Car("Peugeout 406", 1998);
            Car car4 = new Car("Honda Accord", 2003);
            Car car5 = new Car("Geely Atlas", 2019);
            Car car6 = new Car("Mitsubishi Lancer IX", 2005);



            try
            {
                CollectionType<Car> Cars = new CollectionType<Car>();
                Cars.Add(car1);
                Cars.Add(car2);
                Cars.Add(car3);
                Cars.Add(car4);
                Cars.Add(car5);
                Cars.Add(car6);
                CollectionType<Car> Cars2 = new CollectionType<Car>();
                CollectionType<string> Cars3= new CollectionType<string>();
                CollectionType<Car>.number = new Car("aa", 10);


                Cars.Display();

                Cars.WriteToFile();
                Console.WriteLine("Записали в файл\n\n\n");

                Cars.ReadFromFile();
                Console.WriteLine("Прочитали из файла\n\n\n");
                
               
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("Все либо прошло успешно либо не успешно, но finally сработал");
            }
            Console.ReadKey();
            // Обобщения позволяют указать конкретный тип, который будет использоваться. 

            NumType<int> example1 = new NumType<int> { id = 1, num = 100000 };
            NumType<sbyte> example2 = new NumType<sbyte> { id = -2, num = -100 };

            Console.WriteLine(example1.id + " " + example1.num);
            Console.WriteLine(example2.id + " " + example2.num);
            Console.ReadKey();
        }
    }
}
