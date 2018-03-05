using System.Collections.Generic;
using System.IO;

using Android.App;
using Android.Content.Res;
using Android.OS;
using Xamarin.Forms;
using Xamarin.TVScripts.Droid;
using Xamarin.TVScripts.Models;

[assembly: Dependency(typeof(ReadAsset))]
namespace Xamarin.TVScripts.Droid
{
    public class ReadAsset : Activity, IQuotes
    {
        List<Quote> quotes = new List<Quote>();

        public List<Quote> GetQuotes()
        {
            return quotes;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open(@"Scripts\Lost\0101.txt")))
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