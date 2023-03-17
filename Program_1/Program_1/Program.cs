using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello there welcome to the world of C# and Dot Net Framework");
            Car obj1 = new Car();
            obj1.start();
            obj1.Nitro();
            obj1.display_features();
            Console.ReadLine();
        }
    }

    class Vehical
    {
        public string color = "White";
        public int milage = 0;
        public string fuel = "petrol";
        public int seats = 4;
        public Vehical()
        {
            Console.WriteLine("This is a base class!!!!");
        }
        public void start()
        {
            Console.WriteLine("Engine starts");
        }

        public void honk()
        {
            Console.WriteLine("Honk Honk!! Get out of my way");
        }

        public void display_features()
        {
            Console.WriteLine("Color : "+color);
            Console.WriteLine("Milage(km) : " + milage);
            Console.WriteLine("Fuel Type : "+fuel);
            Console.WriteLine("No of seats : " + seats);
        }
    }

    class Car : Vehical
    {
        public void Nitro()
        {
            Console.WriteLine("I have nitros !!!Let race!!!");
        }
    }


}
