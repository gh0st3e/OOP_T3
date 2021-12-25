using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;

//1. Что такое процесс, домен, поток? Как они связаны между собой?
//При запуске приложения операционная система создает для него отдельный процесс, которому выделяется определённое адресное пространство в памяти и который изолирован от других процессов.
//Процесс может иметь несколько потоков. Как минимум, процесс содержит один - главный поток. В приложении на C# точкой входа в программу является метод Main. 
//Вызов этого метода автоматически создает главный поток. А из главного потока могут запускаться вторичные потоки.

//При запуске приложения, написанного на C#, операционная система создает процесс, а среда CLR создает внутри этого процесса логический контейнер, 
//который называется доменом приложения и внутри которого работает запущенное приложение.

//Поток — это основная единица, которой операционная система выделяет время процессора. Каждый поток имеет приоритет планирования

//2. Как получить информацию о процессах?
//Process.GetProcesses()

//3. Как создать и настроить домен?
//Хост-приложение CLR автоматически создает домены приложений в нужный момент. Но можно создать собственные домены приложений
// AppDomain.CreateDomain("Name");

//4. Как создать и настроить поток?
// Thread thread = new Thread(new ThreadStart(SimpleNumbers));
//thread.Name = "SOuth Park";
//thread.Start();

//5. В каких состояниях может быть поток?
//New - создан но не запущен
//Runnable - готов к выполнению
//Running - выполняется
//waiting/bloccked/slepping - приостановлен
//Dead - завершен

//6. Какие методы управления потоками вы знаете, для чего и как их использовать ?
// Start,Join,Sleep

//7. Какие приоритеты потока вы знаете?
// Highest
//AboveNormal
//Normal
//BelowNormal
//Lowest

//8. Что такое пул потоков и для чего он используется?
// Пул потоков позволяет создать набор потоков и вызвать их в нужное время, отправляя соответсвующие запросы.

//9. Что такое критическая секция? Поясните использование.
//Критическая секция — участок исполняемого кода программы, в котором производится доступ к общему ресурсу (данным или устройству), 
//который не должен быть одновременно использован более чем одним потоком выполнения.

//12.Что такое неблокирующие средства синхронизации?
//Разделение доступа между потоками идёт за счёт атомарных операций/
// Атомарная операция либо выполнится полностью либо не выполнится вовсе

//13.Для чего можно использовать класс Timer?
//Данный класс позволяет запускать определенные действия по истечению некоторого периода времени.


namespace Lab15
{
    static class Processes
    {
        public static void ShowProcesses()
        {
            foreach(Process process in Process.GetProcesses())
            {
                try
                {
                    Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName} Prioritet: {process.BasePriority} Time: {process.StartTime}");
                }
                catch
                {
                    continue;
                }
                
            }
        }
    }
    static class DomainInfo
    {
        public static void Info()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
            Console.WriteLine();

            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);

            Console.Read();
        }
        

    }
    static class MyThread
    { 
        public static void MyFirstThread()
        {
            Thread thread = new Thread(new ThreadStart(SimpleNumbers));
            thread.Name = "SOuth Park";
            thread.Start();
            
            

        }

        public static void SimpleNumbers()
        {
            StreamWriter sr = new StreamWriter("C:\\Study\\forlab15\\Numbers.txt");
            Console.WriteLine("Введите n: ");
            int n = int.Parse(Console.ReadLine());
           
            for (int i = 1; i <= n; i++)
            {

                Console.Write("Name: ");
                Console.WriteLine(Thread.CurrentThread.Name);
                Console.WriteLine(Thread.CurrentThread.Priority);
                Console.WriteLine(i);
                sr.WriteLine(i);
                Thread.Sleep(400);
            }
            

            Console.WriteLine("Finish");
            sr.Close();
            Console.ReadKey();
        }
    }
    static class TwoThreads
    {
        private static object locker = new object();
        public static void MyFirstThread()
        {
            
            Thread thread1 = new Thread(new ParameterizedThreadStart(Numbers_odd));
            Thread thread2 = new Thread(new ParameterizedThreadStart(Numbers_not_odd));
            thread1.Name = "Odd";
            thread2.Name = "Not Odd";
            
            thread1.Priority = ThreadPriority.BelowNormal;
            thread2.Priority = ThreadPriority.Normal;
            Console.WriteLine("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            object o = n;
            thread1.Start(o);
            //thread1.Join();
            thread2.Start(o);
            
        }

        public static void Numbers_odd(object n)
        {
            int number = (int)n;
            for (int i = 1; i <= number; i++)
            {
                
                if (i % 2 == 0)
                {
                    Console.Write(Thread.CurrentThread.Name);
                    Console.WriteLine(" "+i);
                }
                Thread.Sleep(500);
            }
            Console.ReadLine();
        }
        public static void Numbers_not_odd(object n)
        {
            
            int number = (int)n;
            lock(locker)
            {
                for (int i = 1; i <= number; i++)
                {

                    if (i % 2 == 1)
                    {
                        Console.Write(Thread.CurrentThread.Name);
                        Console.WriteLine(" " + i);
                    }
                    Thread.Sleep(500);
                }
                Console.ReadLine();
            }
            
           
        }
    }
    static class Timerr
    {
        public static void MyTimer()
        {
            int num = 0;
            TimerCallback tm = new TimerCallback(Count);
            Timer timer = new Timer(tm, num, 0, 2000);
            
            Console.ReadLine();
        }

        public static void Count(object obj)
        {
            int x = (int)obj;
            for (int i = 1; i < 9; i++, x++)
            {
                Console.WriteLine($"{x * i}");
                
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Processes.ShowProcesses();
            DomainInfo.Info();
            MyThread.MyFirstThread();
            TwoThreads.MyFirstThread();
            Timerr.MyTimer();

            Console.ReadLine();
        }
    }
}
