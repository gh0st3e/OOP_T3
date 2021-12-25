using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace OOP16
{
    class Program
    {
        static void Main(string[] args)
        {
            //CancellationTokenSource source = new CancellationTokenSource();
            //CancellationToken token = source.Token;
            //Stopwatch stopwatch = new Stopwatch();

            //int[,] matA = { { 2, 2, 2 },
            //                { 2, 2, 2 },
            //                { 2, 2, 2 } };

            //int[,] matb = { { 1, 0, 0 },
            //                { 0, 1, 0 },
            //                { 0, 0, 1 }};
            //int[,] result;
            try
            {

                //    Task<int> pow = new Task<int>(() =>2*3 );
                //    pow.Start();
                //    Task mulmat = new Task(() =>
                //    {
                //        for (; ; )
                //        {
                //            if(token.IsCancellationRequested)
                //            { Console.WriteLine("EXIT FROM STREAM"); break; }
                //            Thread.Sleep(200);
                //            result = Multiplication(matA, matb);
                //            Print(result);
                //            Console.WriteLine("Thread id: " + Thread.CurrentThread.ManagedThreadId);
                //            Thread.Sleep(2000);
                //        }
                //    });
                //    mulmat.Start();

                //    Console.WriteLine("Input Y for canceling stream");
                //    string s = Console.ReadLine();
                //    if (s == "Y")
                //        source.Cancel();
                //    else Console.WriteLine("ENDLESS CYCLE");

                //    mulmat.Wait();
                //    for (int i = 0; i < 20; i++)
                //    {
                //        Console.WriteLine("Thread id: " + Thread.CurrentThread.ManagedThreadId);
                //        Thread.Sleep(100);
                //    }

                //    Task<int> sumTask = Task<int>.Factory.StartNew((object a) =>
                //    {
                //    stopwatch.Start();
                //    Console.WriteLine("Thread id: " + Thread.CurrentThread.ManagedThreadId);
                //        //Thread.Sleep(2000);
                //        int num = (int)a;
                //        int sum = 0;
                //        for (int i = 0; i <= num; ++i)
                //            sum += i;
                //        return sum;
                //    }
                //    , 10);

                //    Task<int> powTask = Task<int>.Factory.StartNew((object prop) =>
                //    {
                //        Console.WriteLine("Thread id: " + Thread.CurrentThread.ManagedThreadId);
                //        var obj = (dynamic)prop;
                //        int res= 1;
                //        for (int i = 0; i <  obj.pow; ++i)
                //            res *=obj.baseNum;
                //        return res ;
                //    }
                //    , new { baseNum = 2, pow = 10});

                //    Task<double> potEnergyTask = Task<double>.Factory.StartNew((object prop) =>
                //    {
                //        Console.WriteLine("Thread id: " + Thread.CurrentThread.ManagedThreadId);
                //        var obj = (dynamic)prop;
                //        return obj.mass*9.8*obj.height;
                //    }
                //    , new { mass = 56.24, height = 10.25 });


                //    Console.WriteLine(new String('-', 50));
                //    var t2 = sumTask.ContinueWith((i, k) => { return i.Result * 10/(int)k; }, 2).GetAwaiter().GetResult();
                //    //sumTask.Wait();
                //    stopwatch.Stop();
                //    Console.WriteLine($"Result1 sumtask(10) {sumTask.Result}");
                //    Console.WriteLine($"Result2 sumtask( ) {t2}");
                //    Console.WriteLine($"Stopwatch: {stopwatch.Elapsed}");

                //    Console.WriteLine(new String('-', 50));
                //    Console.WriteLine($"Result powtask(2,10) {powTask.Result}");

                //    Console.WriteLine(new String('-', 50));
                //    Console.WriteLine($"Result potential energy task (mass = 56.25,height = 10.25) {potEnergyTask.Result}");

                //    Parallel.Invoke(
                //        () => 
                //        {
                //            for (int i = 0; i < 1000; i++)
                //                Console.WriteLine("--> lambda1 Count=" + i);
                //        }, 
                //        () => 
                //        {
                //            for (int i = 1000; i > 0; i--)
                //                Console.WriteLine("--> lambda2 Count=" + i);
                //        }
                //        );

                //    int[] data2 = new int[10000/*100000000*/];
                //    stopwatch.Restart();
                //    Parallel.For(0, data2.Length, (int i) => { data2[i] = i; });
                //    stopwatch.Stop();
                //    Console.WriteLine($"Array initialization time in parallel: {stopwatch.Elapsed}");

                //    int[] data = new int[10000/*100000000*/];
                //    stopwatch.Restart();
                //    for (int i = 0; i < data.Length; i++)
                //        data[i] = i;
                //    stopwatch.Stop();
                //    Console.WriteLine($"Array initialization time sequentially: {stopwatch.Elapsed}");

                //    Console.WriteLine("-------Parallel--------");
                //    stopwatch.Restart();
                //    Parallel.For(0, data2.Length, (i) => 
                //    {
                //        if(i % 25 == 0)
                //        {
                //            data2[i] = 25;
                //        }

                //        if (i % 547 == 0)
                //        {
                //            data2[i] = 547;
                //        }

                //        if (i % 135 == 0)
                //        {
                //            data2[i] = 135;
                //        }
                //    });
                //    stopwatch.Stop();
                //    Console.WriteLine($"Time branching : {stopwatch.Elapsed}");

                //    Console.WriteLine("-------Sequentially--------");
                //    stopwatch.Restart();
                //    for(int i = 0; i< data.Length; ++i)
                //    {
                //        if (i % 25 == 0)
                //        {
                //            data[i] = 25;
                //        }

                //        if (i % 547 == 0)
                //        {
                //            data[i] = 547;
                //        }

                //        if (i % 135 == 0)
                //        {
                //            data[i] = 135;
                //        }
                //    };
                //    stopwatch.Stop();
                //    Console.WriteLine($"Time branching : {stopwatch.Elapsed}");

                //    Console.WriteLine("-------Parallel--------");
                //    stopwatch.Restart();
                //    Parallel.For(0, data2.Length, (i) =>
                //    {
                //        Console.Write(data2[i]+" ");
                //    });
                //    stopwatch.Stop();
                //    Console.WriteLine();
                //    Console.WriteLine($"Time to show: {stopwatch.Elapsed}");


                //    Console.WriteLine("-------Sequentially--------");
                //    stopwatch.Restart();
                //    foreach(int i in data)
                //    {
                //        Console.Write(i + " ");
                //    }
                //    stopwatch.Stop();
                //    Console.WriteLine();
                //    Console.WriteLine($"Time to show: {stopwatch.Elapsed}");

                //    Parallel.Invoke(() => {
                //        for(int i = 0; i < 100; i+=2)
                //        {
                //            Console.WriteLine(i);
                //        }
                //    },
                //    () => {
                //        Console.WriteLine("Running task {0}", Task.CurrentId);
                //        Thread.Sleep(3000);
                //    },
                //    () => {
                //        for (int i = 1; i < 100; i += 2)
                //        {
                //            Console.WriteLine(i);
                //        }
                //    });
                //task 8
                AsyncMet();


                // task 7 
                //BlockingCollection
                /*есть 5 поставщиков быт. техники, они завозят уник. товары на склад (каждый по одному)
                и 10 покупателей - покупают все подряд, если товара нет - уходят
                спрос превышает предложение. Изначально склад пустой. У каждого поставщика своя скорость заказа товара.
                Каждый раз при изменении состояния склада выводите наименование товаров на складе.
                */
                Store topshop = new Store();
                Provider provider1 = new Provider(1000);
                Provider provider2 = new Provider(1500);
                Provider provider3 = new Provider(200);
                Customer customer1 = new Customer();
                Customer customer2 = new Customer();
                Customer customer3 = new Customer();

                Task Pr = new Task(() => {
                    for (int i = 0; i < 1; i++)
                    {
                        provider1.toStockUp(topshop, new Appliances($"appliances{(new Random().Next(1, 10))}", (new Random().Next(500, 1500))));
                        provider2.toStockUp(topshop, new Appliances($"appliances{(new Random().Next(10, 15))}", (new Random().Next(500, 1500))));
                        provider3.toStockUp(topshop, new Appliances($"appliances{(new Random().Next(15, 20))}", (new Random().Next(500, 1500))));
                    }
                    topshop.Appliances.CompleteAdding();
                });
                Task Cn = new Task(() => {
                    while (!topshop.Appliances.IsCompleted)
                    {
                        customer1.pickupFromStock(topshop);
                        customer2.pickupFromStock(topshop);
                        customer3.pickupFromStock(topshop);
                    }
                });

                Pr.Start();
                Cn.Start();
                Task.WaitAll(Cn, Pr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
            }
            Console.ReadLine();
        }


        class Appliances
        {
            public Appliances(string name, int price)
            {
                _name = name;
                _price = price;
            }
            private string _name;
            private int _price;
            public string Name
            {
                get;
            }
            public string Price
            {
                get;
            }
            public override string ToString()
            {
                return _name + " (price" + _price + ')';
            }
        }

        class Store
        {
            public delegate void ChangeStateOfStore();
            public event ChangeStateOfStore EventStore;
            BlockingCollection<Appliances> listappliances = new BlockingCollection<Appliances>();
            public void getStore()
            {
                foreach (var i in listappliances)
                {
                    Console.WriteLine($"Appliances - {i.Name} | Price - {i.Price}");
                }
            }
            public BlockingCollection<Appliances> Appliances
            {
                get
                {
                    EventStore?.Invoke();
                    return listappliances;
                }
            }
        }

        class Provider
        {
            public Provider(int DeliverySpeed)
            {
                _deliverySpeed = DeliverySpeed;
            }
            int _deliverySpeed;
            public void toStockUp(Store store, Appliances appliance)
            {
                //   Thread.Sleep(_deliverySpeed);
                store.EventStore += () => Console.WriteLine($"TO STOCK UP IN STORE| {appliance}");
                store.Appliances.Add(appliance);
                store.EventStore -= () => { };
            }

        }

        class Customer
        {
            public void pickupFromStock(Store store)
            {
                if (!store.Appliances.IsCompleted)
                {
                    Appliances pickupingApp;
                    store.Appliances.TryTake(out pickupingApp);
                    store.EventStore += () => Console.WriteLine($"TO PICK UP FROM STORE| {pickupingApp}");
                    store.EventStore -= () => { };
                }
                else Console.WriteLine($"store is empty");
            }
        }




        //TASK 8
        /*исп. async и await организ. асинхр. вып-ние любого метода*/

        public static async void AsyncMet()
        {
            Task<int> taskValue = Task<int>.Factory.StartNew(() => {
                int i = 0;
                for (; i < 1000; i++)
                {
                    Thread.Sleep(1);
                }
                Console.WriteLine("In task");
                return i;
            });
            Console.WriteLine("Before await");
            int value = await taskValue;
            Console.WriteLine("After await: res = " + value);
        }


        static int[,] Multiplication(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }

        static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}