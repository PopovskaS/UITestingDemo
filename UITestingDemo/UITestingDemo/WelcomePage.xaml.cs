using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UITestingDemo
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
