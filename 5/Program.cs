using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{

    interface ISale
    {
        string Name { get; set; }
        double Price { get; set; }
    }

    public class Toy : ISale
    {
        private string name;
        private double price;

        public Toy(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }

        public void Print()
        {
            Console.WriteLine("Имя: " + this.name + "\nЦена: " + this.price);
        }
    }

    public class Product : Toy
    {
        private string Date;

        public Product(string name, double price, string date)
           : base(name, price)
        {
            this.Date = date;
        }

        public void PrintDate()
        {
            Console.WriteLine("Срок годности: " + Date);
        }
    }

    public class Groods : Product
    {
        private string Code;

        public Groods(string name, double price, string date, string code)
           : base(name, price, date)
        {
            this.Code = code;
        }

        public void PrintCode()
        {
            Console.WriteLine("Код : " + Code);
        }
    }

    public class MilkProduct : Groods
    {
        private string SafeT;

        public MilkProduct(string name, double price, string date, string code, string safeT)
           : base(name, price, date, code)
        {
            this.SafeT = safeT;
        }

        public void PrintSafe()
        {
            Console.WriteLine("Температура хранения: до " + SafeT + "C");
        }
    }

    class Program
    {
        delegate void MyDelegate();
        static void Main(string[] args)
        {
            int choise;
            Console.OutputEncoding = System.Text.Encoding.Default;

            Toy toy = new Toy("Space", 36.99);
            Product product = new Product("Гречнева каша", 25.50, "11.06.2020");
            Groods groods = new Groods("Акварель", 35, "12.07.2020", "1&34b48X");
            MilkProduct milk = new MilkProduct("Йогурт 'Дольче'", 45.95, "24.11.2019", "008&3X0Z", "+6");
            Console.WriteLine(">>>" + "\n\t1 - Игрушка" + "\n\t2 - Продукт" + "\n\t3 - Товар" + "\n\t4 - Молочный продукт");
            MyDelegate output;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(">>>" + "\n\t1 - Игрушка" + "\n\t2 - Продукт" + "\n\t3 - Товар" + "\n\t4 - Молочный продукт");
                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        {
                            output = toy.Print;
                            output();
                            Console.ReadKey();
                            break;
                        }

                    case 2:
                        {
                            output = product.Print;
                            output += product.PrintDate;
                            output();
                            Console.ReadKey();
                            break;
                        }

                    case 3:
                        {
                            output = groods.Print;
                            output += groods.PrintCode;
                            output += groods.PrintDate;
                            output();
                            Console.ReadKey();
                            break;
                        }

                    case 4:
                        {
                            output = milk.Print;
                            output += milk.PrintCode;
                            output += milk.PrintDate;
                            output += milk.PrintSafe;
                            output();
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }


    }
}
