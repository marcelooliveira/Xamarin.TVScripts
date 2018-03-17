﻿using System;

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
using Xamarin.TVScripts.Services;
using System.Threading.Tasks;
using System.Linq;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace Xamarin.TVScripts.Droid
{
    [Activity(Label = "Xamarin.TVScripts", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IFileService
    {
        static AssetManager assets;
        static IList<Season> seasons = new List<Season>();
        static IList<Episode> episodes = new List<Episode>();
        static IList<Quote> quotes = new List<Quote>();

        public MainActivity()
        {

        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            assets = this.Assets;
        }

        private void LoadSeasons(AssetManager assets)
        {
            seasons.Clear();
            using (StreamReader sr = new StreamReader(assets.Open(@"Seasons.txt")))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('\t');
                    int.TryParse(parts[0], out int number);
                    var name = parts[1];
                    seasons.Add(new Season(number, name));
                }
            }
        }

        private void LoadEpisodes(AssetManager assets)
        {
            episodes.Clear();
            using (StreamReader sr = new StreamReader(assets.Open(@"Episodes.txt")))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('\t');
                    int.TryParse(parts[0], out int number);
                    var name = parts[1];
                    episodes.Add(new Episode(1, number, name));
                }
            }
        }

        public void LoadQuotes(AssetManager assets)
        {
            quotes.Clear();
            int seasonNumber = 1;

            foreach (var episode in episodes)
            {
                using (StreamReader sr = new StreamReader(assets.Open($@"Scripts/Lost/{seasonNumber:d2}{episode.EpisodeNumber:d2}.txt")))
                {
                    sr.ReadLine(); //episode name

                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split('\t');
                        int.TryParse(parts[0], out int id);
                        var character = parts[2];
                        var speech = parts[3];
                        quotes.Add(new Quote(episode.SeasonNumber, episode.EpisodeNumber, quotes.Count + 1, character, speech));
                    }
                }
            }
        }

        public IEnumerable<Season> GetSeasons()
        {
            LoadSeasons(assets);
            return seasons;
        }

        public IEnumerable<Episode> GetEpisodes(int seasonNumber)
        {
            LoadEpisodes(assets);

            return episodes
                .Where(e => e.SeasonNumber == seasonNumber);
        }

        public IEnumerable<Quote> GetQuotes(int seasonNumber, int episodeNumber)
        {
            LoadQuotes(assets);

            return quotes
                .Where(q =>
                    q.SeasonNumber == seasonNumber
                    && q.EpisodeNumber == episodeNumber);
        }
    }
}

