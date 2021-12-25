using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Buffers;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

//1. Что такое сериализация, десериализация?
//Сериализация — это процесс преобразования объекта в поток байтов для сохранения или передачи в память, базу данных или файл. 
//Эта операция предназначена для того, чтобы сохранить состояния объекта для последующего воссоздания при необходимости. Обратный процесс называется десериализацией.

//2. Какие существуют форматы сериализации? Поясните структуру для каждого формата.Какие классы для работы с ними существуют в .NET?
// Binary, Soap, JSON, XML.
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization.Formatters.Soap;
//using System.Text.Json;
//using System.Xml.Serialization;

//3. Какие классы существуют в пространстве имен System.Xml?
//XMLNode - ухел xml
//XMLElement - элемент xml
//XMLDocument - весь документ
//xmlAttribute - аттрибуты
//XMLText - текст

//4. Какие атрибуты используются для настройки XML сериализации?
//xmlArrayAttribute, xmlenumAttribute, xmlAttribute
// Поля или свойства буду десиарилизоваться как как атрибуты

//5. В чем отличие BinaryFormatter или SoapFormatter?
//binary - бинарный формат, 
//При SOAP сериализации данные упакуются в конверт SOAP, данные в котором имеют вид xml-подобного документа.

//6. Что такое сериализация контрактов данных, контракт данных?
// Контракт данных – это тип (класс или структура), объект которого описывает информационный фрагмент. Подразумевается, что этот фрагмент может быть сохранён, а затем восстановлен.

//7. Где и для чего используются атрибуты [OnSerializing], [OnSerialized], [OnDeserializing], [OnDeserialized]?
// Позволяет указывать на методы которые будут вызвано до/после сериализации/десирализации

//8. Что такое XPath? Приведите пример
//XPath представляет язык запросов в XML. Он позволяет выбирать элементы, соответствующие определенному селектору.

//9. Какие возможности дает LINQ to Xml. Приведите примеры
// Язык запросов для данный формата XML

namespace Lab14
{
    //атрибут Serializable автоматически не наследуется
    [Serializable]
    class Person
    {
        public string Name { get; set; }
        public int Year { get; set; }
        [NonSerialized]
        public string LastName;

        public Person(string name, int year, string lastname)
        {
            Name = name;
            Year = year;
            LastName = lastname;
        }

    }
    [Serializable]
    class Car
    { 
        public string Name { get; set; }
        public int Year { get; set; }
    }
    [Serializable]
    public class Game
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public Game()
        {

        }

        public Game(string name, int year)
        {
            Name = name;
            Year = year;
        }
}

    static class BinarySerialization
    { 
        public static void Do()
        {
            Person Denis = new Person("Denis", 2003, "Leonov");
            Person Vlad = new Person("Vlad", 1996, "Myshkovets");
            Person[] people = new Person[] { Denis, Vlad };
            Console.WriteLine("Created");
            BinaryFormatter formatter = new BinaryFormatter();

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);
                Console.WriteLine("Serialized BINARY");
                Console.WriteLine("Denis Eblan Leonow");
            }


            // десериализация из файла people.dat
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                Person[] deserilizePeople = (Person[])formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");

                foreach (Person p in deserilizePeople)
                {
                    Console.WriteLine($"Имя: {p.Name} --- Год рождения: {p.Year}");
                }
            }

            Console.ReadLine();
        }
    }

    static class SoapSerialization
    {
        public static void Do()
        {
            Person Denis = new Person("Denis", 2003, "Leonov");
            Person Vlad = new Person("Vlad", 1996, "Myshkovets");
            Person[] people = new Person[] { Denis, Vlad };
            Console.WriteLine("Created");
            SoapFormatter formatter = new SoapFormatter();
            

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);
                Console.WriteLine("Serialized SOAP");
            }

            // десериализация из файла people.dat
            using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
            {
                Person[] deserilizePeople = (Person[])formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");

                foreach (Person p in deserilizePeople)
                {
                    Console.WriteLine($"Имя: {p.Name} --- Год рождения: {p.Year}");
                }
            }

            Console.ReadLine();
        }
    }

    static class JSONSerialization
    {
        public static void Do()
        {
            Car Renault = new Car { Name = "Renault", Year = 2011 };
            
            Console.WriteLine("Created");

            string json = JsonSerializer.Serialize<Car>(Renault);
            Console.WriteLine(json);
            Car restoredPerson = JsonSerializer.Deserialize<Car>(json);
            Console.WriteLine(restoredPerson.Name +" "+ restoredPerson.Year);
            Console.ReadLine();
        }
    }

    static class XMLSerialization
    {
        public static void Do()
        {
            Game WoW = new Game("World of Warcraft", 2004);

            Console.WriteLine("Created");
            XmlSerializer formatter = new XmlSerializer(typeof(Game));


            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, WoW);
                Console.WriteLine("Serialized XML");
            }

            // десериализация из файла people.dat
            using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                Game deserilizePeople = (Game)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");

                
                    Console.WriteLine($"Имя: {deserilizePeople.Name} --- Год рождения: {deserilizePeople.Year}");
                
            }

            Console.ReadLine();
        }
    }

    static class XmlSelectors
    {
        public static void Do()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("C:/Study/forlab14/wowxml.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("user"); // Выбираем все узлы user
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.SelectSingleNode("@name").Value); // Выводим значение name у user

            Console.ReadLine();
        }
        
    }

    static class LINQtoXML
    {
        public static void Do()
        {
            
            XDocument xdoc = XDocument.Load("C:/Study/forlab14/wowxml.xml");
            var items = from item in xdoc.Element("users").Elements("user")
                        where item.Element("age").Value == "18"
                        select item;

            foreach(string item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //BinarySerialization.Do();
            //SoapSerialization.Do();
            //JSONSerialization.Do();
            //XMLSerialization.Do();

            //XmlSelectors.Do();
            //LINQtoXML.Do();
        }   
    }
}
