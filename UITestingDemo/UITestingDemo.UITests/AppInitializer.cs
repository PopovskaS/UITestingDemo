using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITestingDemo.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.InstalledApp("com.uitestingdemo.droid").StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}