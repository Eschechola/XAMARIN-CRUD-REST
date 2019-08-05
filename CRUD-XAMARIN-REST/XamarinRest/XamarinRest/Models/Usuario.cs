using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinRest.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
    }
}
