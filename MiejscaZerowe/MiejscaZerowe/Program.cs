using System;
using System.Linq;

namespace MiejscaZerowe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Write("Podaj wartość współczynnika: a = ");
                string a = Console.ReadLine();

                Console.Write("Podaj wartość współczynnika: b = ");
                string b = Console.ReadLine();

                Console.Write("Podaj wartość współczynnika: c = ");
                string c = Console.ReadLine();

                Console.WriteLine(Calculate(new string[] { a, b, c }));
            }
            else
            {
                Console.WriteLine(Calculate(args));
            }
            Console.WriteLine("Naciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }

        public static string Calculate(string[] args)
        {

            if ((args[0]=="0") && (args[1]=="0") && (args[2]=="0"))
            {
                return "Nieskończenie wiele miejsc zerowych.";
            }

            bool b = args.Contains("");

            if (b == false)
            {
                double A = Convert.ToDouble(args[0]);
                double B = Convert.ToDouble(args[1]);
                double C = Convert.ToDouble(args[2]);
                double delta;
                double x1;
                double x2;

                delta = B * B - 4 * A * C;
                if (delta > 0)
                {
                    x1 = Math.Round((-B + Math.Sqrt(delta)) / (2 * A) , 2);
                    x2 = Math.Round((-B - Math.Sqrt(delta)) / (2 * A) , 2);
                    string X1 = Convert.ToString(x1);
                    string X2 = Convert.ToString(x2);
                    return String.Concat("Dwa miejsca zerowe: x1 = ",X1,", x2 = ",X2);
                }
                else if (delta == 0)
                {
                    x1 = Math.Round(-B / (2 * A) , 2);
                    string X1 = Convert.ToString(x1);
                    return String.Concat("Jedno miejsce zerowe: x0 = ",X1);
                }
                else // delta < 0
                {
                    return "Brak miejsc zerowych.";
                }
            }
            else
            {
                return "Niewłaściwa ilość współczynników.";
            }


            // Napisz implementację metody 'Calculate' obliczającej miejsca zerowe funkcji kwadratowej
            // o podanych współczynnikach a, b oraz c.
            //
            // Metoda ta przyjmuje jako argumenty jednowymiarowy string array 'args'
            // gdzie poszczególne elementy tego string array 'args' to współczynnyki a, b oraz c funkcji kwadratowej.
            //
            // Metoda ma zwracć informację o wyliczonych miejscach zerowych jako string, przy czym:
            // - pierwszy element string array 'args' to współczynnik a, drugi to współczynnik b, trzeci to współczynnik c
            // - wymagane jest podanie dokładnie trzech współczynników a. b oraz c
            // - jeśli string array 'args' zawiera mniej lub więcej niż trzy elementy, metoda zwrócić ma informację o błędzie
            // - jeśli wartość któregoś ze współczynników (elementy string array 'args') nie może zostać zapisana jako zmienna
            //   typu double, metoda zwrócić ma informację o błędnej wartości współczynnika
            // - dokładność wyliczenia miejsc zerowych to dwa miejsca po przecinku
            // - wartości ułamkowe współczynników mogą być podane wyłącznie z kropką jako separatorem części dziesiętnych,
            //   np. 1.3 lub 7.985 (wartość 1,3 lub 7,985 powinny być uznane za błędne)
            // - wartości ujemne współczynników oznaczane są poprzez - przed liczbą, np. -1.7 (wartość - 1.7 będzie zatem błędna)
            //
            // Aby ułatwić wykonanie tego zadania, w ramach solution dodany został drugi projekt 'TestMejscZerowych',
            // w którym zdefiniowane zostały testy sprawdzające poprawnośc implementacji metody 'Calculate'. Aby wykonać te testy,
            // otwóz Test Explorer (wybierz menu 'Test' -> 'Windows' -> 'Test Explorer') i kliknij 'Run All'.
            //
            // Metoda 'Main' pozwala na uruchomienie aplikacji 'MejscaZerowe' i zweryfikowania (manualnego) jakie rezultaty zwraca
            // metoda 'Calculate' (na początku próba dokonania obliczeń skończy się wyjątkiem, ponieważ metoda 'Calculate' nie
            // jest jeszcze zaimplementowana. Aby uruchomić 'MiejscaZerowe' po prostu klikniej 'Start' na pasku narzędzi.
            //
            // Zalecamy nie zmieniać implementacji metody 'Main', ponieważ nie to jest celem tego zadania.
            //
            // Wykonanie zadania NIE WYMAGA żadnych modyfikacji projektu 'TestMejscZerowych'.
            //
            // Aby możliwe było wykonanie testów, metoda 'Calculate' musi być metodą publiczną (to pozwala na dostęp do niej
            // z poziomu projektu TestMiejscZerowych.
        }
    }
}
