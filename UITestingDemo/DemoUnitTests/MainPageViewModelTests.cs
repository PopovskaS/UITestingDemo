using Autofac.Extras.Moq;
using Moq;
using NUnit.Framework;
using UITestingDemo;
using UITestingDemo.ViewModels;
using Xamarin.Forms;

namespace DemoUnitTests
{
    public class MainPageViewModelTests
    {
        public MainPageViewModelTests()
        {
            XamarinFormsMock.Init();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreatingWelcomePageViewModel_WhenSuccessfull_Registration()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arange
                var viewModel = mock.Create<MainPageViewModel>();
                var navigationMock = new Mock<INavigation>();


                viewModel.Username = "PopovskaS";
                viewModel.Email = "spo@spo.com";
                viewModel.Password = "Test111!";
                viewModel.ConfirmPassword = "Test111!";

                //Act
                viewModel.HandleRegistrationValidation();

                //Assert
                Assert.AreEqual(!viewModel.AreFieldsNotNullOrEmpty, true);
                Assert.AreEqual(viewModel.IsValidEmail(viewModel.Email), true);
                Assert.AreEqual(viewModel.DoPasswordsMatch, true);

                navigationMock.Setup(s => s.PushAsync(It.IsAny<WelcomePage>()));
            }

        }
    }
}