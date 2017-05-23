using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ćwiczenie1.Tests
{
    public class CalcTestsRefactored
    {
        private Calc _calculator;

        public CalcTestsRefactored()
        {
            _calculator = new Calc(9, 3);
        }

        [Fact]
        public void Dodawanie_zwraca_sume_dwoch_liczb()
        {
            var result = _calculator.Dodawanie();
            Assert.Equal(12, result);
        }

        [Fact]
        public void Odejmowanie_zwraca_roznice_dwoch_liczb()
        {
            var result = _calculator.Odejmowanie();
            Assert.Equal(6, result);
        }

        [Fact]
        public void Mnozenie_zwraca_iloczyn_dwoch_liczb()
        {
            var result = _calculator.Mnozenie();
            Assert.Equal(27, result);
        }

        [Fact]
        public void Dzielenie_zwraca_iloraz_dwoch_liczb()
        {
            var result = _calculator.Dzielenie();
            Assert.Equal(3, result);
        }
    }
}
