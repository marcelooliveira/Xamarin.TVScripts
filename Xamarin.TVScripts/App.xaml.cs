﻿using System;

using Xamarin.TVScripts.Views;
using Xamarin.Forms;

namespace Xamarin.TVScripts
{
	public partial class App : Application
	{

		public App ()
		{
			InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new EpisodeListPage());
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
