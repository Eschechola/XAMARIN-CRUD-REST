using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinRest.DBAplicacao;
using XamarinRest.Models;

namespace XamarinRest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddUser : ContentPage
	{
        private int Idade = 16;
        private bool AlterouIdade = false;

		public AddUser ()
		{
			InitializeComponent ();
		}

        public void CadastrarUsuario(object sender, EventArgs args)
        {
            if (txt_nome.Text == string.Empty || txt_nome.Text == "" || txt_nome.Text == null)
            {
                DisplayAlert("Erro!", "O nome deve ser preenchido.", "Ok");
            }
            else if (txt_email.Text == string.Empty || txt_email.Text == "" || txt_email.Text == null)
            {
                DisplayAlert("Erro!", "O email deve ser preenchido.", "Ok");
            }
            else if (txt_senha.Text == string.Empty || txt_senha.Text == "" || txt_senha.Text == null)
            {
                DisplayAlert("Erro!", "A senha deve ser preenchida.", "Ok");
            }
            else if (txt_confirmarSenha.Text == string.Empty || txt_confirmarSenha.Text == "" || txt_confirmarSenha.Text == null)
            {
                DisplayAlert("Erro!", "A confirmação da senha deve ser preenchida.", "Ok");
            }
            else if (txt_senha.Text!=txt_confirmarSenha.Text)
            {
                DisplayAlert("Erro!", "As senhas não são iguais.", "Ok");
            }
            else if (!AlterouIdade)
            {
                DisplayAlert("Erro!", "Selecione sua idade.", "Ok");
            }
            else
            {
                Usuario usuario = new Usuario
                {
                    Nome = txt_nome.Text,
                    Senha = txt_senha.Text,
                    Email = txt_email.Text,
                    Idade = this.Idade
                };

                var sucesso = new UsuarioAplicacao().Inserir(usuario);

                DisplayAlert("!", sucesso.Result.ToString(), "Ok");
            }
        }

        public void AumentarIdade(object sender, EventArgs args)
        {
            AlterouIdade = AlterouIdade ? true : true;
            Idade++;
            txt_idade.Text = Idade.ToString();
        }

        public void DiminuirIdade(object sender, EventArgs args)
        {
            AlterouIdade = AlterouIdade ? true : true;
            Idade = Idade <= 16 ? 16 : Idade-=1;
            txt_idade.Text = Idade.ToString();
        }

    }
}