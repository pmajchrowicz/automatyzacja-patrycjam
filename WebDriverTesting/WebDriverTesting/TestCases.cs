﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        public void First_note_should_be_Vivamus_aliguam_feugiat()
        {
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/");
            IWebElement firstPost = _driver.FindElementByClassName("post-title");
            string firstNoteTitle = firstPost.FindElement(By.TagName("a")).Text;
            Assert.Equal("Vivamus aliquam feugiat",firstNoteTitle);
        }
    }
}
