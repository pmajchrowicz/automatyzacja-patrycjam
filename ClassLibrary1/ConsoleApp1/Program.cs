using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwiczenieKonsola
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calc(10,20);
            Console.WriteLine("Suma wynosi: "+ calculator.Dodawanie());
            /* var result = calculator.Dodawanie;
             Console.WriteLine(result); */
            Console.ReadKey();  // lub Console.ReadLine();
            
        }
    }
}
