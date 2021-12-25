using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Game
    {
        //Делегаты представляют такие объекты, которые указывают на методы. То есть делегаты - это указатели на методы и с помощью делегатов мы можем вызвать данные методы.

        public delegate void CritAttack(string message);

        //Cобытия объявляются в классе с помощью ключевого слова event, после которого указывается тип делегата, который представляет событие:
        public event CritAttack Notify;

        //События сигнализируют системе о том, что произошло определенное действие.И если нам надо отследить эти действия, то как раз мы можем применять события.

        //групповая адресация — это возможность создать список, или цепочку вызовов, для методов, которые вызываются автоматически при обращении к делегату.

        public string Name { get; set; }
        public int Health { get; set; }

        //благодаря ковариантности делегат может указывать на метод, который возвращает объект производного типа, например, Client.

        public Game(string name, int health)
        {
            Name = name;
            Health = health;
        }
        public void Attack()
        {
            Health--;
            Console.WriteLine("Здоровье " + Name + " уменьшено");
        }
        public void Heal()
        {
            Health++;
            Console.WriteLine("Здоровье " + Name + " увеличено");
        }
        public void Crit()
        {
            //Если делегат принимает параметры, то в метод Invoke передаются значения для этих параметров.
            Health -= 10;
            Notify?.Invoke("Нанесен критический удар"); //? проверяет не равен ли он null;
            Console.WriteLine("Нанесен критический удар");
        }
        public void Display()
        {
            Console.WriteLine($"Name:" + Name + "\tHealth:" + Health);
        }
    }

    

    class Program
    {
        public delegate void AttackPlayer();
        public delegate void HealPlayer();

        delegate int Operation(int x, int y);

        public delegate void Action<T>(T obj);
        public delegate string Func<T>(T obj,string a);

      

        static void Main(string[] args)
        {
            Game human = new Game("human", 100);

            AttackPlayer AttackHuman = human.Attack;
            HealPlayer HealHuman = human.Heal;

            human.Display();
            AttackHuman();
            AttackHuman();
            HealHuman();
            human.Display();

            Console.ReadKey();

            Game elf = new Game("elf", 50);

            AttackPlayer AttackElf = elf.Attack;
            HealPlayer HealElf = elf.Heal;

            elf.Display();
            AttackElf();
            HealElf();
            HealElf();
            elf.Display();

            Console.ReadKey();

            Game dworf = new Game("dworf", 200);

            AttackPlayer AttackDworf = dworf.Attack;
            HealPlayer HealDworf = dworf.Heal;

            dworf.Display();
            AttackDworf();
            AttackDworf();
            dworf.Crit();
            dworf.Display();

            Console.ReadKey();

            Operation operation = (x, y) => x - y; // Лямбда-выражение
            Console.WriteLine(operation(20, 10));
            Console.WriteLine(operation(1000, 7));
            Console.ReadKey();



            string str = "HeLlo";
            Action<String> action;
            action = ToUpCase;
            StringAction(str, action);
            action = ToLowCase;
            StringAction(str, action);
            action = AddMessage;
            StringAction(str, action);
            action = ChangeMessage;
            StringAction(str, action);
            action = CutString;
            StringAction(str, action);
            Console.ReadKey();
        }

        static void StringAction(string str, Action<string> action)
        {
            action(str);
        }

        static void ToUpCase(string str)
        {
            Console.WriteLine(str.ToUpper());
            
        }
        static void ToLowCase(string str)
        {
            Console.WriteLine(str.ToLower());

        }
        static void AddMessage(string str)
        {
            Console.WriteLine(str.Insert(5, " world"));
        }
        static void ChangeMessage(string str)
        {
            Console.WriteLine(str.Replace(str, "Goodbye"));
        }
        static void CutString(string str)
        {
            Console.WriteLine(str.Substring(0,4));
        }
    }
}

//Делегат Func предназначен для инкапсуляции метода, который принимает в качестве параметров от нуля до четырех аргументов и возвращает значение.
//Что же касается делегата Action, то единственное отличие его от Func – это то, что Action возвращает процедуру.