using UITestingDemo.ViewModels;
using Xamarin.Forms;

namespace UITestingDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new MainPageViewModel(Navigation);
        }
    }
}
