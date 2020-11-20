using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Windows.Input;
using Xamarin.Forms;


namespace UITestingDemo.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public INavigation _naviagtion { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool AreFieldsNotNullOrEmpty => string.IsNullOrEmpty(Email)
            && string.IsNullOrEmpty(Username)
            && string.IsNullOrEmpty(Password)
            && string.IsNullOrEmpty(ConfirmPassword);

        private bool DoPasswordsMatch => Password == ConfirmPassword;

        public MainPageViewModel(INavigation navigation)
        {
            _naviagtion = navigation;

            HandleRegistrationCommand = HandleRegistrationButtonClicked();
        }

        public ICommand HandleRegistrationCommand { get; }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
            }
        }

        private ICommand HandleRegistrationButtonClicked()
        {
            return new Command(() =>
            {
                if (!AreFieldsNotNullOrEmpty && IsValidEmail(Email) && DoPasswordsMatch)
                {
                    Action _navigateToMainPage =
                         async () =>
                         {
                             await _naviagtion.PushAsync(new WelcomePage());
                         };
                    _navigateToMainPage.Invoke();
                }
            });
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
