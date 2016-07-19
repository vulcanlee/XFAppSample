using System;

using Xamarin.Forms;

namespace DoggyMobileBE
{
	public class App : Application
	{
        public static object UIContext { get; set; }

        public App ()
		{
            // The root page of your application
            //MainPage = new TodoList();
            MainPage = new NavigationPage(new TodoList());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

