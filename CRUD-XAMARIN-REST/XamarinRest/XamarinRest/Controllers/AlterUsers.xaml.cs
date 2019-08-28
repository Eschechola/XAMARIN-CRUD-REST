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
    public partial class AlterUsers : ContentPage
    {
        private Usuario UsuarioAtualizar;
        private int Idade = 16;
        private bool AlterouIdade = false;

        public AlterUsers(Usuario usuario)
        {
            InitializeComponent();
            UsuarioAtualizar = usuario;

            txt_nome.Text = usuario.Nome;
            txt_senha.Text = usuario.Senha;
            txt_idade.Text = usuario.Idade.ToString();
            Idade = usuario.Idade;
            txt_email.Text = usuario.Email;
        }

        public void AlterarUsuario(object sender, EventArgs args)
        {
            indicator.IsVisible = true;
            ContentUser.IsVisible = false;
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
            else if (txt_senha.Text != txt_confirmarSenha.Text)
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
                    Id = UsuarioAtualizar.Id,
                    Nome = txt_nome.Text,
                    Senha = txt_senha.Text,
                    Email = txt_email.Text,
                    Idade = this.Idade
                };

                var aplicacao = new UsuarioAplicacao();

                Task task = Task.Run(async () =>
                {
                    await aplicacao.AlterarUsuario(usuario);
                });

                DisplayAlert("!", aplicacao.Mensagem, "Ok");

                Navigation.PopModalAsync();
            }
            indicator.IsVisible = false;
            ContentUser.IsVisible = true;
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
            Idade = Idade <= 16 ? 16 : Idade -= 1;
            txt_idade.Text = Idade.ToString();
        }
    }
}