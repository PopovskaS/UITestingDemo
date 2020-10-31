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
        public void UserIsRegisterdSuccesfully()
        {
            //Arrange
            app.EnterText("EntryUsernameID", "PopovskaS");
            app.EnterText("EntryEmailID", "spo@spo.com");
            app.EnterText("EntryPasswordID", "TestPassword111!");
            app.EnterText("EntryConfrimPasswordID", "TestPassword111!");

            //Act
            app.Tap("RegisterBtnID");

            //Assert
            Assert.DoesNotThrow(() => app.WaitForElement("WelcomeLabelID"),
                "Unable to find WelcomeLabelID", TimeSpan.FromSeconds(5));
        }
    }
}
