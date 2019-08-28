using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinRest.DBAplicacao;
using XamarinRest.Models;

namespace XamarinRest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowAllUsers : ContentPage
    {

        public ShowAllUsers()
        {
            InitializeComponent();
            indicator.BackgroundColor = Color.FromRgba(0, 0, 0, 0.5);
            GetTodosUsuarios();
        }

        private async void GetTodosUsuarios()
        {
            indicator.IsVisible = true;
            var aplicacao = new UsuarioAplicacao();

            Task task = Task.Run(async () =>
            {
                await aplicacao.GetTodosUsuarios();
            });

            while (!task.IsCompleted)
            {
                continue;
            }

            lv_usuarios.ItemsSource = aplicacao.ListaComTodosUsuarios;
            DisplayAlert("!", aplicacao.Mensagem, "Ok");

            indicator.IsVisible = false;
        }

        public async void Voltar(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}