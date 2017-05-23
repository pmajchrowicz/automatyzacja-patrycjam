using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GoogleTesting
{
    public class GoogleTest
    {
        private ChromeDriver _driver;

        public GoogleTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        [Fact]
        public void  Hello_test()
        {
            _driver.Navigate().GoToUrl("http://www.google.com"); //otworzenie przeglądarki Chrome na stronę google.com
            _driver.FindElementById("lst-ib").SendKeys("code sprinters"); // wyszukanie pola Szukaj za pomocą id i wpisanie w to pole "code sprinters"
            _driver.FindElementById("_fZl").Click(); //kliknięcie w dany przycisk o id "_fZl"
            //Thread.Sleep(1000);
            var result = _driver.FindElementByXPath("//div/*/a[@href=\'http://agileszkolenia.pl/']");

            Assert.NotNull(result);
            Assert.Equal("Code Sprinters -", result.Text);

            _driver.Quit(); //zamykanie przeglądarki
        }
    }
}
