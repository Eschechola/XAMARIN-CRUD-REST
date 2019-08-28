using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinRest.DBAplicacao;
using XamarinRest.Models;

namespace XamarinRest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DelUser : ContentPage
	{
        private Usuario _usuario;
		public DelUser (Usuario usuario)
		{
			InitializeComponent ();
            _usuario = usuario;
            txt_id.Text = usuario.Id.ToString();
            txt_nome.Text = usuario.Nome;
            txt_idade.Text = usuario.Idade.ToString();
            txt_senha.Text = usuario.Senha;
            txt_email.Text = usuario.Email;
		}

        public void NaoDeletar(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }

        public void Deletar(object sender, EventArgs args)
        {
            var aplicacao = new UsuarioAplicacao();

            Task task = Task.Run(async () =>
            {
                await aplicacao.DeletarUsuario(_usuario);
            });

            while (!task.IsCompleted)
            {
                continue;
            }

            DisplayAlert("!", aplicacao.Mensagem, "Ok");

            Navigation.PopModalAsync();
        }

    }
}