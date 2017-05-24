﻿using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebDriverTesting
{
    public class TestCases : IDisposable
    {
        private ChromeDriver _driver;

        public TestCases()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void Dispose()
        {
            _driver.Quit();
        }

        [Fact]
        public void FixMe()
        {
            Assert.Equal(true, false);
        }
    }
}
