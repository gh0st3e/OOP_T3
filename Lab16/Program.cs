using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Net;
using System.Collections.Concurrent;

//1.Что такое TPL? Как и для чего исп. тип Task?
//Task Parallel Library – позв. распараллелить задачи и вып. их сразу на неск. процессорах, если на пк неск. ядер
//класс Task – опис. отд. задачу, кот. запуск. асинхронно в одном из потоков из пула потоков
//(м. запуск. синхронно в тек. потоке)
//везде в кач. параметра делегат Action
//2. Почему эффект от распараллеливания наблюдается на большом кол-ве элементов?
//3. В чем осн. достоинства работы с задачами по сравнению с потоками?
//в Thread:
//1) нет механизма продолжений
//2) затруднено получение значения результата из потока
//3) повыш.расход памяти и замедление работы приложения
//4. Приведите три способа создания и/или запуска Task?
//1) Task task = new Task(() = > Console.WriteLine(“Hello!”));			//3
//task.Start()
//2) Task task = Task.Factory.StartNew(() => Console.WriteLine(“Hello!”);		//1
//3) Task task = Task.Run(() => Console.WriteLine(“Hello!”);			//2
//5.Как и для чего исп. методы Wait(), WaitAll(), WaitAny() ?
//Wait() – приостан.тек.поток до завершения задачи
//WaitAll() – стат., приост.тек.поток до завершения всех указ. задач
//WaitAny() – стат., приост.тек поток до завершения любой из указ. задач
//6. Приведите пример синхронного запуска Task?
//Action <object> method = x => Console.WriteLine(“yo”);
//var task4 = new Task(method, TaskCreationOptions.LongRunnig);
//task4.RunSynchronously();
//7.Как создать задачу с возвратом результата?
//Task<TResult> - опис. задачу, возвр. значение типа TResult
//приним. аргументы типа:
//Func<TResult>
//Func<object, TResult>
//8. Как обработать исключение, если оно произошло при выполнении Task?
//Task task5 = Task.Run(() => { throw new Exception() });
//try
//{
//    task5.Wait();
//}
//catch (AggregateException ex)
//{
//    var message = ex.InnerException.Message;
//    Console.WriteLine(message);
//}
//9.Что такое CancellationToken и как с его пом. отменить выполнение задач?
//CancellationTokenSource tokenSource = new CancellationTokenSource();
////исп. токен в двух задачах
//new Task(method, tokenSource.Token).Start();
//new Task(method, tokenSource.Token).Start();
////отменяем задачи
//tokenSource.Cancel()
//10.Как организовать задачу продолжения (continuation task)?
//сообщ.задаче, что после ее завершения она д. продолжить делать что-то другое
//1) Task task6 = Task.Run(() => Console.Write(“Doing..”));
//Task task7 = task6.ContinueWith(t => Console.Write(“Continuation”);
//2) Task task8 = Task.Run(() => Console.Write(“One…”);
//Task task9 = Task.Run(() => Console.Write(“Two…”);
//Task continuation = Task.WhenAll(task8, task9).
//                                          ContinueWith(t => Console.WriteLine(“Three..”);
//11.Как и для чего исп. объект ожидания при создании задач продолжения?
//Объект ожидания – любой объект, имеющий методы
//OnCompleted() +GetResult() + св - во IsCompleted
// Task<int> what = Task.Run(() => Enumerable.Range(1, 100000)
//                                                     .Count(n => (n % 2 == 0)));
////получаем объект продолжения
//var awaiter = what.GetAwaiter();
////что делать после оконч. предшественника
//awaiter.OnCompleted(() => {
//    //получаем рез. вычислений предшественника
//    int res = awaiter.GetResult();
//    Console.WriteLine(res);
//    12.Поясните назначение класса System.Threading.Tasks.Parallel?
//позв.распараллеливать циклы и посл-ст блоков кода
//For(), ForEach()		//паралл. аналоги циклов for, foreach
//..Invoke()  – шаблоны(на задачах, поддерж.искл.и токен отмены)
//13.Приведите пример задачи с Parallel.For(int, int, Action<int>)
//Parallel.For(1, 10, z =>                    //1,10 – нач,кон знач счетчика,
//{
//    int r = 1;              //z – тело цикла в виде объекта делегата
//    for (int y = 1; y <= 10; y++)       // 3 4 6 8 9 2 5 1 7
//        r *= z;
//}
//Paralle.For(1, 10, (int z, ParallelLoopState pd) => {
//Console.WriteLine(z);
//int r = 1;
//for (int y = 1; y <= 10; y++)           // 3 4 6 8 9 1 2 7 5
//    r *= z;
//Поддерж.императивность – оп - р, след.за вызовом метода вызван после заверш. всех задач
//14.Приведите пример задачи с Parallel.ForEach
//ParallelLoopResult listFact = Parallel.ForEach<int>
//              (new List<int>() { 1, 3, 5, 8 },  //коллекция
//              Factorial);			//делегат, вып. раз за итерацию
//.								//перебир. эл-та коллекции
//15.Приведите пример с Parallel.Invoke()
//позв.распараллелить исп. блоков оп-ров – набор задач, кот. вып.в одном потоке
//их м.запуск одновременно
//Parallel.Invoke(() => new WebClient().DownloadFile(“http…”),
//       () => new WebClient().DownloadFile(“http…”));
//16.Как с использованием CancellationToken отменить парал.операции?
//CancellationTokenSource ctks = new CancellationTokenSource();
//CancellationToken token = ctks.Token;
//Parallel.ForEach<int>(
//    new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 },
//    new ParallelOptions { CancellationToken = token },
//                Factorial);

//17 Коллекция, которая осуществляет блокировку и ожидает, пока не появится возможность выполнить действие по добавлению или извлечению элемента. 
//18. Как используя async и await организовать асинхронное вып. метода?
//При асинхр.вызове поток вып-ния раздел. на 2 части:
//в одной – вып.метод
//в другой – процесс программы
//async – указ., что д-й метод м.содерж. 1/неск выражений await
////асинхр. метод
//static async void FactorialAsync()
//{
//    Console.Write(“Начало”);        //вып. синхронно
//    await Task.Run(() => Factorial_Six());  //вып. асинхронно
//    Console.Write(“Конец”)		//вып синхронно
//main()

//    FactorialAsync();
//    Console.Write(“Квадрат 3” +9);
//    Асинхр.задача, кот.может выполнятся долго, не блокирует метод Main,
//  и мы можем продолжать работу с ним
//когда асинхр. задача заверш. (await)Fact_Six,
//продолж.асинхр.метод FactAsync
//ост.часть этого метода после await вып.синхронно


namespace Lab16
{
    class TPL_Task
    {
        public void Do()
        {
            var task = Task.Factory.StartNew(() =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                
                TimeSpan ts = stopwatch.Elapsed;

                Console.Write("Введите число: ");
                int n = int.Parse(Console.ReadLine());
                for (int i = 4; i <= n; i++)
                {
                    if (i % 2 != 0 && i % 3 != 0 && i % 5 != 0 && i % 7 != 0)
                    {
                        Console.WriteLine(i);
                        //Thread.Sleep(500);
                        Console.WriteLine(Task.CurrentId);
                        Console.WriteLine(Task.CompletedTask.Status);
                       

                    }
                }
                stopwatch.Stop();
                Console.WriteLine(ts);
            });
            Console.ReadLine();

        }


        public void Do_4task()
        {
            int a = 6;
            int b = 17;
            int c = 12;
            Task<int> task1 = new Task<int>(() => b * b);
            task1.Start();
            Task<int> task2 = new Task<int>(() => 4 * a * c);
            task2.Start();
            Task<int> task3 = new Task<int>(() => task1.Result - task2.Result);
            task3.Start();
            Console.WriteLine(task3.Result);
        }

        public void ContinueTask_1()
        {
            //Задачи продолжения или continuation task позволяют определить задачи, которые выполняются после завершения других задач.
            Task task1 = new Task(() => {
                Console.WriteLine("Опы, мы выполняем первую задачу");
            });
            Task task2 = task1.ContinueWith(Display);
            task1.Start();
            task2.Wait();
            
            Console.ReadLine();
        }

        public void ContinueTask_2()
        {
            Task<int> what = Task.Run(() => Enumerable.Range(1, 100000).Count(n => (n % 2 == 0)));
            var awaiter = what.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine(awaiter.GetResult());
            });



            Console.ReadLine();
            
        }

        public static void Display(Task t)
        {
            Console.WriteLine($"Id задачи: {Task.CurrentId}");
            Console.WriteLine($"Id предыдущей задачи: {t.Id}");
            Thread.Sleep(3000);
            
        }
    }

    class Paralell_task
    {
        public void par_for()
        {
            //int count = 0;
            //int[] arr = new int[10000];
            //Parallel.For(1, 10000, z =>
            //  { 
            //      count++;
            //      arr[count] = count;
            //      Console.WriteLine(arr[count]);
            //  });
            //Console.ReadLine();

            Stopwatch stopwatch = new Stopwatch();

            int[] data2 = new int[10000000/*100000000*/];
            stopwatch.Restart();
            Parallel.For(0, data2.Length, (int i) => { data2[i] = i; });
            stopwatch.Stop();
            Console.WriteLine($"Array initialization time in parallel: {stopwatch.Elapsed}");

            int[] data = new int[100000000/*100000000*/];
            stopwatch.Restart();
            for (int i = 0; i < data.Length; i++)
                data[i] = i;
            stopwatch.Stop();
            Console.WriteLine($"Array initialization time sequentially: {stopwatch.Elapsed}");
        }

        public void par_invoke()
        {
            //Одним из методов, позволяющих параллельное выполнение задач
            Parallel.Invoke(
                            () => new
                            WebClient().DownloadFile("http://www.belstu.by", "start.html"),
                            () => new
                            WebClient().DownloadFile("http://www.go.by", "go.html"));
        }

        public void blockingcol()
        {
            Random random = new Random();
            
            int x = 0;
            int thr = 100;
            BlockingCollection<int> blockcoll = new BlockingCollection<int>();
            for (int producer = 0; producer < 5; producer++)
            {
                x++;
                Task.Factory.StartNew(() =>
                {
                    x++;
                    
                        Thread.Sleep(thr);
                        int id = random.Next();
                        blockcoll.Add(id);
                        Console.WriteLine("Добавлен товар " + id);
                    
                });
            }
            for(int i=0;i<10;i++)
            {
                Task consumer = Task.Factory.StartNew(
            () =>
            {


                if (!blockcoll.IsCompleted)
                {
                    Console.WriteLine("Покупатель забрал товар + " + blockcoll.Take().ToString());
                }
                else
                {
                    Console.WriteLine("loose");
                }


            });
                consumer.Wait();
            }
            






        }

        public async void ReadFromWeb()
        {
            var web = new WebClient();
            var text =
            await
            web.DownloadStringTaskAsync("https://vk.com");
            Console.WriteLine("\t"+text.Length);
            Console.WriteLine("That work");
            Console.WriteLine("That work");
            Console.WriteLine("That work");
            Console.WriteLine("That work");
        }
        public void cicleforasync()
        {
            for(int i=0;i<5000;i++)
            {
                Console.WriteLine(i);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            TPL_Task ex1 = new TPL_Task();
            //ex1.Do();
            //ex1.Do_4task();
            //ex1.ContinueTask_1();
            //ex1.ContinueTask_2();
            Paralell_task ex2 = new Paralell_task();
            ex2.par_for();
            //ex2.par_invoke();
            //ex2.blockingcol();
            //ex2.ReadFromWeb();
            //ex2.cicleforasync();
            Console.ReadLine();
        }
    }
}
