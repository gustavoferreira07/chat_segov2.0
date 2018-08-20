using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_segov.Repositorio
{
    class Usuario
    {
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string Departamento { get; set; }
        public byte[] Foto { get; set; }


        public Usuario(string nome, string username, string senha, string departamento, byte[] foto)
        {
            this.Nome = nome;
            this.Username = username;
            this.Senha = senha;
            this.Departamento = departamento;
            this.Foto = foto;
        }
        public Usuario()
        {

        }
    }
}
