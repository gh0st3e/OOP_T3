using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_laba
{
    interface IWrite
    {
       void Write(string str);
    }

    class Electronic
    {
        public static bool operator ==(Electronic el1, Electronic el2)
        {
            if (el1.Memory > el2.Memory)
            {
                Console.WriteLine("Память " + el1.Name + " больше " + el2.Name);
                return true;
            }
            else
            {
                Console.WriteLine("Память " + el2.Name + " больше " + el1.Name);
                return false;
            }
        }

        public static bool operator !=(Electronic el1, Electronic el2)
        {
            if (el1.Memory < el2.Memory) return true;
            else return false;

        }

        public string Name { get; set; }
        public int Memory { get; set; }
    }

    class Memory : Electronic,IWrite
    {
        public string Name { get; set; } 
        public int Memorycount { get; set; }
        public void Write(string str)
        {
            Console.WriteLine(Name + " " + Memorycount);
        }
    }

    class Flash : Memory,IWrite
    {
        public string Name { get; set; }
        public int Memorycount { get; set; }
        public void Write(string str)
        {
            Console.WriteLine(Name + " " + Memorycount);
        }
    }
}
