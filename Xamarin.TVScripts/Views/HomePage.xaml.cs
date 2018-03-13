using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.TVScripts.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();

            btnStart.Clicked += BtnStart_Clicked;
		}

        private async void BtnStart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EpisodeListPage());
        }
    }
}