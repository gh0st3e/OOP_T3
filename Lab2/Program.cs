using System;
using System.Text;

namespace Lab_2
{
    class Program
    {
        static void Ex1a()
        {
            for (int i = 1; i != 0; i++)
            {
                Console.Clear();
                Console.WriteLine("Выберите тип данных: \n");
                Console.WriteLine("1 - bool");
                Console.WriteLine("2 - byte");
                Console.WriteLine("3 - sbyte");
                Console.WriteLine("4 - char");
                Console.WriteLine("5 - decimal");
                Console.WriteLine("6 - double");
                Console.WriteLine("7 - float");
                Console.WriteLine("8 - int");
                Console.WriteLine("9 - uint");
                Console.WriteLine("10 - long");
                Console.WriteLine("11 - ulong");
                Console.WriteLine("12 - short");
                Console.WriteLine("13 - ushort");
                Console.WriteLine("0 - Exit");

                int selection = int.Parse(Console.ReadLine());
                if (selection == 0)
                {
                    i = 0;
                    break;
                }
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите значение: ");
                        bool abool = bool.Parse(Console.ReadLine());
                        Console.WriteLine(abool);
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Введите значение: ");
                        byte abyte = byte.Parse(Console.ReadLine());
                        Console.WriteLine(abyte);
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Введите значение: ");
                        sbyte asbyte = sbyte.Parse(Console.ReadLine());
                        Console.WriteLine(asbyte);
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Введите значение: ");
                        char achar = char.Parse(Console.ReadLine());
                        Console.WriteLine(achar);
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Введите значение: ");
                        decimal adecimal = decimal.Parse(Console.ReadLine());
                        Console.WriteLine(adecimal);
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Введите значение: ");
                        double adobule = double.Parse(Console.ReadLine());
                        Console.WriteLine(adobule);
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Введите значение: ");
                        float afloat = float.Parse(Console.ReadLine());
                        Console.WriteLine(afloat);
                        Console.ReadLine();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("Введите значение: ");
                        int aint = int.Parse(Console.ReadLine());
                        Console.WriteLine(aint);
                        Console.ReadLine();
                        break;
                    case 9:
                        Console.Clear();
                        Console.WriteLine("Введите значение: ");
                        uint auint = uint.Parse(Console.ReadLine());
                        Console.WriteLine(auint);
                        Console.ReadLine();
                        break;
                    case 10:
                        Console.Clear();
                        Console.WriteLine("Введите значение: ");
                        long along = long.Parse(Console.ReadLine());
                        Console.WriteLine(along);
                        Console.ReadLine();
                        break;
                    case 11:
                        Console.Clear();
                        Console.WriteLine("Введите значение: ");
                        ulong aulong = ulong.Parse(Console.ReadLine());
                        Console.WriteLine(aulong);
                        Console.ReadLine();
                        break;
                    case 12:
                        Console.Clear();
                        Console.WriteLine("Введите значение: ");
                        short ashort = short.Parse(Console.ReadLine());
                        Console.WriteLine(ashort);
                        Console.ReadLine();
                        break;
                    case 13:
                        Console.Clear();
                        Console.WriteLine("Введите значение: ");
                        ushort aushort = ushort.Parse(Console.ReadLine());
                        Console.WriteLine(aushort);
                        Console.ReadLine();
                        break;
                    default:
                        continue;
                }
            }
        }
        static void Ex1b()
        {
            byte a = 1;
            byte b = 2;
            int c = a + b;
            byte c1 = (byte)c;
            Console.WriteLine(c.GetType());
            Console.WriteLine(c1.GetType());
            Console.ReadKey();
        }
        static void Ex1c()
        {
            int i = 1516;
            object o = i;
            Console.WriteLine(o);
            Console.ReadKey();
            o = 124;
            i = (int)o;
            Console.WriteLine(o);
            Console.ReadKey();
        }
        static void Ex1d()
        {
            int age = 18;
            var name = "Denis Leonov";
            var sname = 'g';
            Console.WriteLine("Имя: " + name + "\nВозраст: " + age + "\nShortname: " + sname);
            Console.WriteLine(name.GetType());
            Console.WriteLine(sname.GetType());
            Console.ReadKey();
        }
        static void Ex1e()
        {
            int? x = null;
            if (x.HasValue)
                Console.WriteLine(x.Value);
            else
                Console.WriteLine("x is equal to null");
            x = 10;
            if (x.HasValue)
                Console.WriteLine(x.Value);
            else
                Console.WriteLine("x is equal to null");
            Console.ReadKey();
        }
        static void Ex2ab()
        {
            string string1 = "Exal Egor Rudman na bazar ";
            string string2 = "zaxotelos emu spat i on zevnul ";
            string string3 = "i upal on s telegi i umer";
            Console.WriteLine(string1 + string2 + string3);
            Console.ReadKey();

            string[] subs = string1.Split(' ');
            foreach (var sub in subs)
            {
                Console.WriteLine($"Substring: {sub}");
            }
            Console.ReadKey();

            string s1 = "hello world";
            string s2 = "beaty ";
            int indexofchar = 6;
            s1 = s1.Insert(indexofchar, s2);
            Console.WriteLine(s1);
            Console.ReadKey();

            string s3 = "dead inside";
            Console.WriteLine(s3);
            int ind = s3.Length - 1;
            s3 = s3.Remove(ind - 5, 6);
            Console.WriteLine(s3);
            Console.ReadKey();

            int x = 8;
            int y = 7;
            string result = $"{x} + {y} = {x + y}";
            Console.WriteLine(result); // 8 + 7 = 15
            Console.ReadKey();
        }
        static void Ex2c()
        {
            string string1 = null;
            string string2 = "";
            if (String.IsNullOrEmpty(string1))
                Console.WriteLine("Строка null или пустая");
            if (String.IsNullOrEmpty(string2))
                Console.WriteLine("Строка null или пустая");
            Console.ReadKey();
        }
        static void Ex2d()
        {
            StringBuilder sb = new StringBuilder("Hello world"); // Выделяет больше памяти для динамической работы
            Console.WriteLine($"Длина строки: {sb.Length}");
            Console.WriteLine($"Емкость строки: {sb.Capacity}");
            Console.ReadKey();
            sb.Remove(6, 5);
            Console.WriteLine(sb);
            Console.ReadKey();
            StringBuilder sbadd = new StringBuilder("universe");
            sb.Insert(6, sbadd);
            Console.WriteLine(sb);
            Console.ReadKey();
        }
        static void Ex3a()
        {
            int[,] nums = { { 0, 1, 2 }, { 3, 4, 5 }, { 5, 6, 7 }, { 8, 9, 10 } };
            int rows = nums.GetUpperBound(0) + 1;
            int columns = nums.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{nums[i, j]} \t");

                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void Ex3b()
        {
            string[] arrayofstring = { "Hello", "My", "Name", "Is", "Denis" };
            Console.WriteLine("Длина массива: " + arrayofstring.Length);
            for (int i = 0; i < arrayofstring.Length; i++)
            {
                Console.Write(arrayofstring[i] + ' ');
            }
            Console.ReadKey();
            Console.WriteLine("Выберите элемент который хотите заменить: ");
            int change = int.Parse(Console.ReadLine());
            change--;
            Console.WriteLine("Введите строку");
            string schange = Console.ReadLine();
            arrayofstring[change] = schange;
            for (int i = 0; i < arrayofstring.Length; i++)
            {
                Console.Write(arrayofstring[i] + ' ');
            }
            Console.ReadKey();
        }
        static void Ex3c()
        {

            int count = 9;
            int[] nums = new int[count];
            Console.WriteLine("Введите значения массива: ");
            for (int i = 0; i < count; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < count; i++)
            {
                Console.Write(nums[i]+"\t");
                if (i == 2) Console.WriteLine();
                if (i == 5) Console.WriteLine();
                if (i == 5) Console.Write("\t");
                if (i == 7) Console.WriteLine();
                if (i == 7) Console.Write("\t\t");
                
            }
            Console.ReadKey();
        }
        static void Ex3calt()
        {

            int i = 0;
            // Объявляем ступенчатый массив
            int[][] myArr = new int[4][];
            myArr[0] = new int[4];
            myArr[1] = new int[6];
            myArr[2] = new int[3];
            myArr[3] = new int[4];

            // Инициализируем ступенчатый массив
            for (; i < 4; i++)
            {
                myArr[0][i] = i;
                Console.Write("{0}\t", myArr[0][i]);
            }

            Console.WriteLine();
            for (i = 0; i < 3; i++)
            {
                myArr[1][i] = i;
                Console.Write("{0}\t", myArr[1][i]);
            }

            Console.WriteLine();
            for (i = 0; i < 2; i++)
            {
                myArr[2][i] = i;
                Console.Write("{0}\t", myArr[2][i]);
            }

            Console.ReadLine();

        }
        static void Ex3d()
        {
            var string1 = "Hello world";
            var arr = new[]{ 1, 2, 3 };
            Console.WriteLine(string1);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.ReadKey();
        }
        static void Ex4a()
        {
            var person=(18,"Denis",'g',"Leonov",400000000000000);
            Console.WriteLine("Возраст: "+person.Item1);
            Console.WriteLine("Имя: " + person.Item2);
            Console.WriteLine("Ник: " + person.Item3);
            Console.WriteLine("Фамилия: " + person.Item4);
            Console.WriteLine("Деньги: " + person.Item5);
            Console.ReadKey();
            Console.WriteLine("Что вывести1-5");
            int a = int.Parse(Console.ReadLine());
            if (a == 1) Console.WriteLine("Возраст: " + person.Item1);
            if (a == 2) Console.WriteLine("Имя: " + person.Item2);
            if (a == 3) Console.WriteLine("Ник: " + person.Item3);
            if (a == 4) Console.WriteLine("Фамилия: " + person.Item4);
            if (a == 5) Console.WriteLine("Деньги: " + person.Item5);
            Console.ReadKey();
            int age = person.Item1;
            string name = person.Item2;
            char sname = person.Item3;
            string surname = person.Item4;
            ulong money = (ulong)person.Item5;

            var equal1 = ValueTuple.Create(9, 3);
            var equal2 = ValueTuple.Create(3, 9);
            Console.WriteLine(equal1.CompareTo(equal2));
            Console.ReadKey();
        }
        static void Main(string[] args)
        {

            Tuple<int,int,int,string> ex5(int[] arr, int count, string str1)
            {
                int min=999999999;
                int max=0;
                int sum = 0;
                for (int i = 0; i < count; i++)
                {
                    if (arr[i] > max) max = arr[i];
                    if (arr[i] < min) min = arr[i];
                    sum += arr[i];
                }
                string symbol = str1.Substring(0, 1);
                var exersice = Tuple.Create(min, max, sum, symbol);
                return exersice;
            }

            int[] nums = { 1, 2, 3, 4, 5 };
            //ex5(nums, nums.Length, "hello");
            

            int ex6a(int a)
            {
                checked
                {
                    a = a+2;
                }
                return a;
            }
            //ex6a(int.MaxValue);
            

            int ex6b(int a)
            {
                unchecked
                {
                    a = a + 2;
                }
                
                return a;
            }
            //ex6b(int.MaxValue);
            

            for (int i = 1; i != 0; i++)
            {
                Console.Clear();
                Console.WriteLine("Выберите задание: ");
                Console.WriteLine("1 - 1a");
                Console.WriteLine("2 - 1b");
                Console.WriteLine("3 - 1c");
                Console.WriteLine("4 - 1d");
                Console.WriteLine("5 - 1e");
                Console.WriteLine("6 - 2ab");
                Console.WriteLine("7 - 2c");
                Console.WriteLine("8 - 2d");
                Console.WriteLine("9 - 3a");
                Console.WriteLine("10- 3b");
                Console.WriteLine("11 - 3c");
                Console.WriteLine("12 - 3d");
                Console.WriteLine("13 - 4a");
                Console.WriteLine("14 - 5");
                Console.WriteLine("15 - 6a");
                Console.WriteLine("16 - 6b");
                Console.WriteLine("0 - exit");

                int selection = int.Parse(Console.ReadLine());
                if (selection == 0)
                {
                    i = 0;
                    break;
                }
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        Ex1a();
                        break;
                    case 2:
                        Console.Clear();
                        Ex1b();
                        break;
                    case 3:
                        Console.Clear();
                        Ex1c();
                        break;
                    case 4:
                        Console.Clear();
                        Ex1d();
                        break;
                    case 5:
                        Console.Clear();
                        Ex1e();
                        break;
                    case 6:
                        Console.Clear();
                        Ex2ab();
                        break;
                    case 7:
                        Console.Clear();
                        Ex2c();
                        break;
                    case 8:
                        Console.Clear();
                        Ex2d();
                        break;
                    case 9:
                        Console.Clear();
                        Ex3a();
                        break;
                    case 10:
                        Console.Clear();
                        Ex3b();
                        break;
                    case 11:
                        Console.Clear();
                        Ex3c();
                        break;
                    case 12:
                        Console.Clear();
                        Ex3d();
                        break;
                    case 13:
                        Console.Clear();
                        Ex4a();
                        break;
                    case 14:
                        Console.Clear();
                        ex5(nums, nums.Length, "hello");
                        Console.WriteLine(ex5(nums, nums.Length, "hello").Item1);
                        Console.WriteLine(ex5(nums, nums.Length, "hello").Item2);
                        Console.WriteLine(ex5(nums, nums.Length, "hello").Item3);
                        Console.WriteLine(ex5(nums, nums.Length, "hello").Item4);
                        Console.ReadKey();
                        break;
                    case 15:
                        Console.Clear();
                        ex6a(int.MaxValue);
                        break;
                    case 16:
                        Console.Clear();
                        ex6b(int.MaxValue);
                        break;
                    case 0:
                        break;
                    default:
                        continue;

                }
            }
        }
    }
}