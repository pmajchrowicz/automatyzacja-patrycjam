using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Calc
    {
        private int liczba1;
        private int liczba2;

        public Calc(int zmienna1, int zmienna2)
        {
            liczba1 = zmienna1;
            liczba2 = zmienna2;
        }

        public int Dodawanie()
        {
            return (liczba1 + liczba2);
        }

        public int Odejmowanie()
        {
            return (liczba1 - liczba2);
        }

        public int Mnozenie()
        {
            return (liczba1 * liczba2);
        }

        public double Dzielenie()
        {
            return (liczba1 / liczba2);
        }
        
        
        // var c = new Calc(10,20);
        // var suma = c.Add();
    }
}
