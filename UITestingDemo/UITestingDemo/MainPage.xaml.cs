using System;
using System.Net.Mail;
using Xamarin.Forms;

namespace UITestingDemo
{
    public partial class MainPage : ContentPage
    {
        private bool AreFieldsNotNullOrEmpty => string.IsNullOrEmpty(EmailEntry.Text)
            && string.IsNullOrEmpty(UserNameEntry.Text)
            && string.IsNullOrEmpty(PasswordEntry.Text)
            && string.IsNullOrEmpty(ConfirmPasswordEntry.Text);

        private bool DoPasswordsMatch => PasswordEntry.Text == ConfirmPasswordEntry.Text;

        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if(!AreFieldsNotNullOrEmpty && IsValidEmail(EmailEntry.Text) && DoPasswordsMatch)
            {
                await Navigation.PushAsync(new WelcomePage());
            }
        }

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}
