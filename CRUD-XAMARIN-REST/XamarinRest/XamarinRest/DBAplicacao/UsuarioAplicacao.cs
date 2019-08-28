using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinRest.Models;

namespace XamarinRest.DBAplicacao
{
    public class UsuarioAplicacao
    {
        private HttpClient Conexaohttp { get; set; }
        public List<Usuario> ListaComTodosUsuarios { get; set; }
        public Usuario DadosUsuarioByEmail { get; set; }
        public string Mensagem { get; set; }

        public async Task InserirUsuario(Usuario usuario)
        {
            using (Conexaohttp = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(usuario);
                    Conexaohttp.BaseAddress = new Uri("https://lyfrapi.herokuapp.com");
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await Conexaohttp.PostAsync("/api/Pessoa/Inserir/", content);
                    string resposta = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        Mensagem = "Usuario inserido com sucesso!";
                    }
                    else
                    {
                        Mensagem = resposta;
                    }
                }
                catch (Exception)
                {
                    Mensagem = "Erro de conexão";
                }
            }
        }

        public async Task AlterarUsuario(Usuario usuario)
        {
            using (Conexaohttp = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(usuario);
                    Conexaohttp.BaseAddress = new Uri("https://lyfrapi.herokuapp.com");
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await Conexaohttp.PostAsync("/api/Pessoa/Alterar/", content);
                    string resposta = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        Mensagem = "Usuario alterado com sucesso!";
                    }
                    else
                    {
                        Mensagem = resposta;
                    }

                }
                catch (Exception)
                {
                    Mensagem = "Erro ao conectar com o servidor";
                }
            }
        }

        public async Task DeletarUsuario(Usuario usuario)
        {
            using (Conexaohttp = new HttpClient())
            {
                try
                {
                    Conexaohttp.BaseAddress = new Uri("https://lyfrapi.herokuapp.com");
                    var content = new StringContent(usuario.Id.ToString());
                    HttpResponseMessage response = await Conexaohttp.PostAsync("/api/Pessoa/Deletar/", content);
                    string resposta = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        Mensagem = "Usuario deletado com sucesso!";
                    }
                    else
                    {
                        Mensagem = resposta;
                    }

                }
                catch (Exception)
                {
                    Mensagem = "Erro ao conectar com o servidor";
                }
            }
        }

        public async Task GetTodosUsuarios()
        {
            using (Conexaohttp = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await Conexaohttp.GetAsync("https://lyfrapi.herokuapp.com/api/Pessoa/GetTodosUsuarios");
                    string resposta = await response.Content.ReadAsStringAsync();
                    

                    if (response.IsSuccessStatusCode)
                    {
                        ListaComTodosUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(resposta);
                        Mensagem = "Usuários encontrados!";
                    }
                    else
                    {
                        Mensagem = resposta;
                    }
                    
                }
                catch (Exception)
                {
                    Mensagem = "Não foi possível conectar ao servidor!";
                }
            }
        }

        public async Task GetUsuarioByEmail(string email)
        {
            using (Conexaohttp = new HttpClient())
            {
                try
                {
                    Conexaohttp.BaseAddress = new Uri("https://lyfrapi.herokuapp.com");
                    var content = new StringContent(email);
                    HttpResponseMessage response = await Conexaohttp.PostAsync("/api/Pessoa/GetUsuarioByEmail/", content);
                    string resposta = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        Mensagem = "Usuario deletado com sucesso!";
                    }
                    else
                    {
                        Mensagem = resposta;
                    }
                }
                catch (Exception)
                {
                    Mensagem = "Erro ao tentar se conectar com o servidor!";
                }
            }
        }
    }
}
