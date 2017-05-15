using System;

namespace Zadanie4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("y = a * (x * x) + b  * y + c");
            Console.Write("podaj wartośc a = ");
            var a = Convert.ToDouble(Console.ReadLine());

            Console.Write("podaj wartośc b = ");
            var b = Convert.ToDouble(Console.ReadLine());

            Console.Write("podaj wartośc c = ");
            var c = Convert.ToDouble(Console.ReadLine());

            Calculate(a, b, c);

        }

        private static void Calculate(double a, double b, double c)
        {
            double x1 = 0;
            double x2 = 0;

            double delta;
            delta = b*b - 4 * a * c;
            if (delta > 0)
            {
                x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine("Dwa miejsca zerowe równe: ");
                Console.WriteLine(x1);
                Console.WriteLine(x2);
            }
            else if (delta == 0)
            {
                x1 = -b / (2 * a);
                Console.WriteLine("Jedno miejsce zerowe równe: ");
                Console.WriteLine(x1);
            }
            else // delta < 0
            {
                Console.WriteLine("Brak miejsc zerowych.");
            }
            
            
            //Console.WriteLine(x1);
            //Console.WriteLine(x2);
            Console.ReadKey();
        }
    }
}