using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_segov.Controlador
{
    class Variaveis_globais
    {
        private static string _usuario;
        public static string usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private static string _id_usuario;
        public static string id_usuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }
        private static string _ip;
        public static string ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        private static string _status;
        public static string status
        {
            get { return _status; }
            set { _status = value; }
        }
        private static string _id_grupo;
        public static string id_grupo
        {
            get { return _id_grupo; }
            set { _id_grupo = value; }
        }
        private static string _mensagem;
        public static string mensagem
        {
            get { return _mensagem; }
            set { _mensagem = value; }
        }
    }
}
