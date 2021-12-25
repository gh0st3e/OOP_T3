using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Car
    {
        private string nameofcar;
        private int year;
        public string NameofCar
        {
            get
            {
                return nameofcar;
            }
            set
            {
                if (value == "")
                {
                    Console.WriteLine("Вы ввели пустое значение");
                }
                else
                {
                    nameofcar = value;
                }
            }
        }
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Вы ввели пустое значение");
                }
                else
                {
                    year = value;
                }
            }
        }

        public Car(string nameofcar, int year)
        {
            this.NameofCar = nameofcar;
            this.Year = year;
        }

        

        public override string ToString()
        {
            return base.ToString() + " Имя Машины " + nameofcar + " Год Выпуска " + year;
        }
    }
}
