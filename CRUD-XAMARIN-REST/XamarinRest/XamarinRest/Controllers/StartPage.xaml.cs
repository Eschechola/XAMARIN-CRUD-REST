using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinRest.Views;

namespace XamarinRest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartPage : ContentPage
	{
		public StartPage ()
		{
			InitializeComponent ();
		}

        public async void ChamarPainel(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new Painel());
        }

    }
}