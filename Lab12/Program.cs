using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Lab12
{
    //Рефлексия представляет собой процесс выявления типов во время выполнения приложения.

    //с помощью ключевого слова typeof, с помощью метода GetType() класса Object и применяя статический метод Type. GetType()

    //Класс System.Type представляет изучаемый тип, инкапсулируя всю информацию о нем. 

    //раннее связывание означает, что объект и вызов функции связываются между собой на этапе компиляции. 
    //Позднее связывание означает, что объект связывается с вызовом функции только во время исполнения программы, а не раньше.

    //Чтобы динамически загрузить сборку в приложение, надо использовать статические методы Assembly. LoadFrom() или Assembly. Load(). 
    //Метод LoadFrom() принимает в качестве параметра путь к сборке

    //Перечисление BindingFlags может принимать различные значения: 
    //BindingFlags(NonPublic)
    static class Reflector
    {
        public static void CollectInf()
        {
            string info = AssemblyName.GetAssemblyName("Lab12.exe").Name;
            Console.WriteLine(info);

            Type myType = Type.GetType("Lab12.ForException");

            //foreach (MemberInfo mi in myType.GetMembers())
            //{
            //    Console.WriteLine($"{mi.DeclaringType} {mi.MemberType} {mi.Name}");
            //}

            




            Console.WriteLine("Информация о конструкторах");
            foreach (ConstructorInfo ctor in myType.GetConstructors())
            {
                Console.WriteLine(ctor.Name + " " + ctor.GetParameters()[0].ParameterType.Name + " " + ctor.GetParameters()[0].Name);
            }

            Console.WriteLine("Реализованные интерфейсы:");
            foreach (Type i in myType.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }
            

            Console.WriteLine("Поля");
            foreach (FieldInfo field in myType.GetFields())
            {
                Console.WriteLine($"{field.FieldType} {field.Name}"); 
            }

            Console.WriteLine("Свойства:");
            foreach (PropertyInfo prop in myType.GetProperties())
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name}");
            }
            Console.ReadKey();

            Console.WriteLine("Введите тип параметра: ");
            string type = Console.ReadLine();

            foreach (MethodInfo method in myType.GetMethods())
            {
                Console.WriteLine(method.Name);
                //получаем все параметры
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {

                    if (parameters[i].ParameterType.Name == type)
                    {
                        Console.WriteLine(method.ReturnType.Name + " " + method.Name + " " + parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    }
                    else
                    { 
                        Console.WriteLine(" Нет");
                    }
                }
            }

        }
        public static void Invoke(string NameOfClass,string NameOfMethod, string Message)
        {


            Type myType = Type.GetType("Lab12.ForException", false, true);
            Type RightClass;
            var Classes = Assembly.GetExecutingAssembly().GetTypes();
            foreach(Type clas in Classes)
            {
                Console.WriteLine(clas.Name);
                if (clas.Name == NameOfClass)
                {
                    RightClass = clas;
                    object obj = Activator.CreateInstance(RightClass);
                    MethodInfo method = RightClass.GetMethod(NameOfMethod);
                    object result = method.Invoke(obj, new object[] { Message });
                }
            }

        }
        public static void Create()
        {
            string NameOfClass = "ForException";
            string NameOfMethod = "Display";


            Type myType = Type.GetType("Lab12.ForException", false, true);
            Type RightClass;
            var Classes = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type clas in Classes)
            {
                
                if (clas.Name == NameOfClass)
                {
                    RightClass = clas;
                    object obj = Activator.CreateInstance(RightClass,5);
                    MethodInfo method = RightClass.GetMethod(NameOfMethod);
                    object result = method.Invoke(obj, new object[] {  });
                    Console.WriteLine(obj.ToString());
                }
            }
        }
    }

    interface IForException
    {
        void Display();
    }

    public class ForException : IForException
    {
        public int X { get; set; }
        public ForException(int x)
        {
            X = x;
        }
        
        
        public void Display()
        {
            Console.WriteLine(X);
        }

        public void TestForParametres(string x)
        {

        }

        public override string ToString()
        {
            return "That work " + X;
        }



    }

    public class ForTestInvoke
    {
        public string CallFromMethod(string mes)
        {
            Console.WriteLine("О мы передали класс и метод в функцию а вызвали другую функцию, я не знаю зачем мне это, но я не хочу, чтобы меня отчислили " + mes);
            return mes;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Reflector.CollectInf();

            string NameOfClass;
            string NameOfMethod;
            string Message;
            String line;
            StreamReader sr = new StreamReader("C:\\Study\\forlab12\\Test.txt");
            line = sr.ReadLine();
            NameOfClass = line;
            line = sr.ReadLine();
            NameOfMethod = line;
            line = sr.ReadLine();
            Message = line;
            sr.Close();
            Reflector.Invoke(NameOfClass,NameOfMethod,Message);
            Reflector.Create();
            Console.ReadKey();
        }
    }
}
