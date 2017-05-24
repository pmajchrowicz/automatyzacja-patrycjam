using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebDriverTesting
{
    class TestCases2
    {
        public object ExampleTitle;
        public object ExampleContent = "abc";

        public TestCases2()
        {
            ExampleTitle = Guid.NewGuid().ToString();
        }

        [Fact]
        public void Widocznosc_stworzonej_notki_na_blogu()
        {
            Administrator.GoTo();
            Administrator.Login(Credentials.Valid);
            Administrator.CreateNewPost(ExampleTitle, ExampleContent);
            Administrator.Logout();

            Note.GoTo();
            Note.AssertPostExist(ExampleTitle);
        }
    }

    internal class Note
    {
        internal static void AssertPostExist(object exampleTitle)
        {
            throw new NotImplementedException();
        }

        internal static void GoTo()
        {
            throw new NotImplementedException();
        }
    }

    internal class Credentials
    {
        public static WpCredentials Valid { get; internal set; }
    }

    public class WpCredentials
    {
    }

    internal class Administrator
    {
        internal static void CreateNewPost(object exampleTitle, object exampleContent)
        {
            throw new NotImplementedException();
        }

        internal static void GoTo()
        {
            throw new NotImplementedException();
        }

        internal static void Login(object valid)
        {
            throw new NotImplementedException();
        }

        internal static void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
