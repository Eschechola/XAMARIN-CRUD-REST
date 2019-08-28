using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Threading.Tasks;

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

        public async void ChamarAlterar(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new GetUserAlter());
        }

        public async void ChamarTodosUsuarios(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new ShowAllUsers());
        }

        public async void ChamarDeletar(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new GetUserDelete());
        }
    }
}