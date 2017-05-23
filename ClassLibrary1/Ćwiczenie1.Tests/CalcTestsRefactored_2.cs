using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ćwiczenie1.Tests
{
    public class CalcTestsRefactored_2
    {
        /*private Calc _calculator;

        public CalcTestsRefactored_2()
        {
            _calculator = new Calc(9, 3);
        }
        */

        //[Fact]
        [Theory]
        [InlineData(1,1,2)]
        public void Dodawanie_zwraca_sume_dwoch_liczb(int x, int y, int expected)
        {
            var calculator = new Calc(x, y);
            var result = calculator.Dodawanie();
            Assert.Equal(expected, result);
        }

        //[Fact]
        //public void Odejmowanie_zwraca_roznice_dwoch_liczb()
        //{
        //    var result = _calculator.Odejmowanie();
        //    Assert.Equal(6, result);
        //}

        //[Fact]
        //public void Mnozenie_zwraca_iloczyn_dwoch_liczb()
        //{
        //    var result = _calculator.Mnozenie();
        //    Assert.Equal(27, result);
        //}

        //[Fact]
        [Theory]
        [InlineData(9,3,3)]
        //[InlineData(3, 0, 5.0F/0.0F)]
        public void Dzielenie_zwraca_iloraz_dwoch_liczb(int x, int y, double expected)
        {
            var calculator = new Calc(x, y);
            var result = calculator.Dzielenie();
            Assert.Equal(expected, result);
        }
    }
}
