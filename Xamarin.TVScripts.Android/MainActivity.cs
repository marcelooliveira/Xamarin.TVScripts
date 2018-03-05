using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Xamarin.TVScripts.Models;
using Android.Content.Res;
using System.IO;
using System.Runtime.CompilerServices;
using Xamarin.TVScripts.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace Xamarin.TVScripts.Droid
{
    [Activity(Label = "Xamarin.TVScripts", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IQuotes
    {
        public MainActivity()
        {

        }

        static List<Quote> quotes = new List<Quote>();

        public List<Quote> GetQuotes()
        {
            return quotes;
        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());


            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open(@"0101.txt")))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    quotes.Add(new Quote("", line));
                }
            }
        }
    }
}

