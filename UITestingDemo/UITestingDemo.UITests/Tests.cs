using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITestingDemo.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void UserIsRegisterdSuccesfully()
        {
            //all fields are mandatory

            //Arrange
            app.EnterText("EntryUsername", "PopovskaS");
            app.EnterText("EntryEmail", "spo@spo.com");
            app.EnterText("EntryPassword", "TestPassword");
            app.EnterText("EntryConfrimPassword", "TestPassword");

            //Act

            //Assert
            Assert.IsTrue(true);
            // Assert. 

        }
    }
}
