using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_segov.Repositorio
{
    class Grupo
    {
        public string Nm_grupo { get; set; }
        public byte[] Foto_grupo { get; set; }
        public string Mensagem { get; set; }
        public string Participantes { get; set; }


        public Grupo(string nm_grupo,byte[] foto_grupo, string mensagem, string participantes)
        {
            this.Nm_grupo = nm_grupo;
            this.Foto_grupo = foto_grupo;
            this.Mensagem = mensagem;
            this.Participantes = participantes;
        }
        public Grupo()
        {

        }
    }
}
