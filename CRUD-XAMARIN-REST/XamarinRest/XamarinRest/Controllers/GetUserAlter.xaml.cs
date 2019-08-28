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
    public partial class GetUserAlter : ContentPage
    {
        public GetUserAlter()
        {
            InitializeComponent();
            indicator.BackgroundColor = Color.FromRgba(0, 0, 0, 0.5);
        }

        public async void GetUsuarioByEmail(object sender, EventArgs args)
        {
            indicator.IsVisible = true;
            ContentEmail.IsVisible = false;

            if (txt_email.Text == string.Empty || txt_email.Text == "" || txt_email.Text == null)
            {
                await DisplayAlert("Erro!", "Insira um email valido", "Ok");
            }
            else
            {
                var usuario = new Usuario();
                string email = txt_email.Text;
                
                var aplicacao = new UsuarioAplicacao();

                Task task = Task.Run(async () =>
                {
                    await aplicacao.GetUsuarioByEmail(email);
                });

                while (!task.IsCompleted)
                {
                    continue;
                }

                usuario = aplicacao.DadosUsuarioByEmail;
                DisplayAlert("!", aplicacao.Mensagem, "Ok");

                if (aplicacao.Mensagem == "Usuário encontrado!")
                {
                    Navigation.PushModalAsync(new AlterUsers(usuario));
                }

                indicator.IsVisible = false;
                ContentEmail.IsVisible = true;
            }
        }
    }
}