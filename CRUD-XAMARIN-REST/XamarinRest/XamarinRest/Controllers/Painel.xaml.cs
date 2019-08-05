using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinRest.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinRest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Painel : ContentPage
	{
		public Painel ()
		{
			InitializeComponent();
		}

        public async void ChamarAdicionar(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new AddUser());
        }

    }
}