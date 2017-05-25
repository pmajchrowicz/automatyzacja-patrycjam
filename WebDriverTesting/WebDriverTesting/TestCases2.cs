using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace WebDriverTesting
{
    public class TestCases2 : IDisposable
    {
        public readonly string expected_title;
        public static string ExampleContent = "abc";

        public TestCases2()
        {
            expected_title = Guid.NewGuid().ToString();
        }

        [Fact]
        public void Widocznosc_stworzonej_notki_na_blogu()
        {
            Administrator.GoTo();
            Administrator.Login(Credentials.Valid);
            var url = Administrator.CreateNewPost(expected_title, ExampleContent);
            Administrator.Logout();

            Note.GoTo(url);
            Note.AssertPostExist(expected_title);
        }

        
        public void Dispose()
        {
            Browser.Get().Quit();
        }
    }

    class Browser
    {
        private static FirefoxDriver _driver;

        static Browser()
        {
            _driver = new FirefoxDriver();
            _driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(5);
        }

        internal static FirefoxDriver Get()
        {
            return _driver;
        }
    }

    internal class Note
    {
        private static FirefoxDriver _driver = Browser.Get();

        internal static void AssertPostExist(string expected_title)
        {
            var founded_title = _driver.FindElementByClassName("entry-title").Text;
            Assert.Equal(expected_title, founded_title);
        }

        internal static void GoTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }

    internal class Credentials
    {
        public static WpCredentials Valid = new WpCredentials
        {
            UserName = "autotestdotnet@gmail.com",
            Password = "codesprinters2016"
        };

        public static WpCredentials InValid = new WpCredentials
        {
            UserName = "hdskjfbskdjfbs",
            Password = "fjkdsbfkajbkfl"
        };
    }

    public class WpCredentials
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    class Administrator
    {
        private static FirefoxDriver _driver = Browser.Get();

        private static void waitForElementPresent(By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        protected static void WaitForElementPresent(IWebElement by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(_driver,
                TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        internal static string CreateNewPost(string expected_title, string ExampleContent)
        {

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
            //var expected_title = "Notka_Patrycja_" + Guid.NewGuid();
            title.SendKeys(expected_title);

            var pole_tekstowe = "wp-editor-area";
            var notka = _driver.FindElementByClassName(pole_tekstowe);
            notka.Click();
            notka.SendKeys(ExampleContent);

            var publish_id = "publish";
            var publish = _driver.FindElementById(publish_id);
            publish.Click();

            waitForElementPresent(By.Id("sample-permalink"), 10);
            return _driver.FindElementByXPath("//span[@id='sample-permalink']/a").GetAttribute("href");
            
        }

        internal static void GoTo()
        {
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/wp-admin/");
        }

        internal static void Login(WpCredentials Valid)
        {
            var username_id = "user_login";
            var password_id = "user_pass";
            var login_id = "wp-submit";
            _driver.FindElementById(username_id).SendKeys(Valid.UserName);
            _driver.FindElementById(password_id).SendKeys(Valid.Password);
            _driver.FindElementById(login_id).Click();
            
        }

        internal static void Logout()
        {
            var avatar_id = "wp-admin-bar-my-account";
            var avatar = _driver.FindElementById(avatar_id);
            avatar.Click();

            waitForElementPresent(By.ClassName("ab-sign-out"), 5);
            var sign_out_class = "ab-sign-out";
            _driver.FindElementByClassName(sign_out_class).Click();
            
        }
    }
}
