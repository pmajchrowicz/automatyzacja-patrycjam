using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace WebDriverTesting
{
    public class TestCases : IDisposable
    {
        private FirefoxDriver _driver;

        public TestCases()
        {
            _driver = new FirefoxDriver();
            _driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void Dispose()
        {
            _driver.Quit();
        } 

        /*[Fact]
        public void First_note_should_be_Vivamus_aliguam_feugiat()
        {
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/");
            IWebElement firstPost = _driver.FindElementByClassName("post-title");
            string firstNoteTitle = firstPost.FindElement(By.TagName("a")).Text;
            Assert.Equal("Vivamus aliquam feugiat",firstNoteTitle);
        } */

        /*[Fact]
        public void Second_note_should_be_Vivamus_aliguam_feugiat()
        {
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/");
            //var posts = _driver.FindElementsByClassName("post-title"); // szuka wszystkich class "post-title"
            ReadOnlyCollection<IWebElement> posts = _driver.FindElementsByClassName("post-title");
            //var secondPost = posts[1];  // drugi element ze znalezionych class "post-title"
            IWebElement secondPost = posts[1];
            string secondNoteTitle = secondPost.FindElement(By.TagName("a")).Text;
            Assert.Equal("Vivamus aliquam feugiat", secondNoteTitle);
        } */

        private void waitForElementPresent(By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        protected void WaitForElementPresent(IWebElement by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(_driver,
                TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        //[Fact]
        public void Widocznosc_stworzonej_notki_na_blogu()
        {
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/wp-admin/");
            var username_id = "user_login";
            var password_id = "user_pass";
            var login_id = "wp-submit";
            _driver.FindElementById(username_id).SendKeys("autotestdotnet@gmail.com");
            _driver.FindElementById(password_id).SendKeys("codesprinters2016");
            _driver.FindElementById(login_id).Click();

            var menu_classname = "wp-menu-name";
            var menu = _driver.FindElementsByClassName(menu_classname);
            IWebElement menu_posts = menu[2];
            menu_posts.Click();

            var add_new_classname = "page-title-action";
            waitForElementPresent(By.ClassName(add_new_classname), 10);
            IWebElement new_post = _driver.FindElementByClassName(add_new_classname);
            new_post.Click();

            var title_id = "title-prompt-text";
            var title = _driver.FindElementById(title_id);
            title.Click();
            var expected_title = "Notka_Patrycja_" + Guid.NewGuid();
            title.SendKeys(expected_title);

            var pole_tekstowe = "wp-editor-area";
            var notka = _driver.FindElementByClassName(pole_tekstowe);
            notka.Click();
            notka.SendKeys("aaabbbccc");

            var publish_id = "publish";
            var publish = _driver.FindElementById(publish_id);
            publish.Click();

            waitForElementPresent(By.Id("sample-permalink"), 10);
            var permalink = _driver.FindElementByXPath("//span[@id='sample-permalink']/a").GetAttribute("href");

            var avatar_id = "wp-admin-bar-my-account";
            var avatar = _driver.FindElementById(avatar_id);
            avatar.Click();

            waitForElementPresent(By.ClassName("ab-sign-out"),5);
            var sign_out_class = "ab-sign-out";
            _driver.FindElementByClassName(sign_out_class).Click();


            //_driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/");
            //var post = _driver.FindElementByLinkText(expected_title);
            //var post_url = post.GetAttribute("href");
            //Assert.Equal(permalink, post_url);

            _driver.Navigate().GoToUrl(permalink);
            var founded_title = _driver.FindElementByClassName("entry-title").Text;
            Assert.Equal(expected_title, founded_title);

        }

    }
}
