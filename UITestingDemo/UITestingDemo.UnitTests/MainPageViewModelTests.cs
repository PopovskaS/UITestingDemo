using System.Linq;
using Autofac.Extras.Moq;
using NUnit.Framework;
using UITestingDemo.ViewModels;
using static Pattern.Tests.XamarinFormsMock;

namespace UITestingDemo.UnitTests
{
    public class MainPageViewModelTests
    {
        readonly App _app;
        readonly WelcomePage _loginPage;

        public MainPageViewModelTests()
        {
            Init();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async void CreatingHomePageViewModel_WhenSuccessfull_SelectedVideoIsNull()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arange
                var viewModel = mock.Create<MainPageViewModel>();

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

                var welcomePage = new WelcomePage();
                await viewModel._naviagtion.PushAsync(welcomePage);
                Assert.AreEqual(viewModel._naviagtion.NavigationStack.Last(), welcomePage);
            }

        }
    }
}