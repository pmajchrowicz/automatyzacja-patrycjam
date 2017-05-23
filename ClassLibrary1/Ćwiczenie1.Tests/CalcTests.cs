using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ćwiczenie1.Tests
{
    public class CalcTests
    {
        // jezeli_podam_5_i_10_wowczas_Dodawanie_zwraca_15

        [Fact]   // dla .Framework i Xunit musi być [Fact] żeby traktowane było jako test jednostkowy
        public void Dodawanie_zwraca_sume_dwoch_liczb()
        {
            // arrange
            var calculator = new Calc(20, 15);

            // act
            var result = calculator.Dodawanie();

            // assert
            Assert.Equal(35, result);
        }

        [Fact]   
        public void Odejmowanie_zwraca_roznice_dwoch_liczb()
        {
            var calculator = new Calc(20, 15);
            var result = calculator.Odejmowanie();
            Assert.Equal(5, result);
        }

        [Fact]
        public void Mnozenie_zwraca_iloczyn_dwoch_liczb()
        {
            var calculator = new Calc(2, 5);
            var result = calculator.Mnozenie();
            Assert.Equal(10, result);
        }

        [Fact]
        public void Dzielenie_zwraca_iloraz_dwoch_liczb()
        {
            var calculator = new Calc(20, 5);
            var result = calculator.Dzielenie();
            Assert.Equal(4, result);
        }
    }
}
