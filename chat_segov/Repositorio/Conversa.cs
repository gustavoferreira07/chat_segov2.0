using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_segov.Repositorio
{
    class Conversa
    {
        public string Remetente {get;set;}
        public string Destinatario { get; set; }
        public string Mensagem { get; set; }
      //  public string Codigo_conversa { get; set; }
        public string Lido { get; set; }

        public Conversa(string remetente, string destinatario, string mensagem,/*string codigo_conversa,*/ string lido)
        {
            this.Remetente = remetente;
            this.Destinatario = destinatario;
            this.Mensagem = mensagem;
            //this.Codigo_conversa = codigo_conversa;
            this.Lido = lido;
        }

        public Conversa()
        {

        }
    }
}
