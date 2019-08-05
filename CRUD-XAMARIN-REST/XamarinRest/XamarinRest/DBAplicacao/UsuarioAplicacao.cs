using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinRest.Models;

namespace XamarinRest.DBAplicacao
{
    public class UsuarioAplicacao
    {
        private HttpClient client;


        public async Task<string> Inserir(Usuario usuario)
        {
            using (client = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(usuario);
                    HttpResponseMessage response = await client.PostAsync("https://lyfrapi.herokuapp.com/api/lyfr/Inserir/?json=" + json, null);

                    if(response.Content.ToString()== "O usuário enviado já existe na base de dados!")
                    {
                        return "Usuário já existe";
                    }
                    else if(response.Content.ToString() == "Erro!")
                    {
                        return "Erro de conexão";
                    }
                }
                catch (Exception)
                {
                    return "Erro de conexão";
                }
                return "Usuário cadastrado com sucesso";
            }
        }
    }
}
