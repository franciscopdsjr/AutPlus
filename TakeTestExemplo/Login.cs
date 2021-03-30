using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeTestExemplo
{
    class Login
    {
        public string Usuario { get; set; }

        public string Senha { get; set; }

        public Login()
        {
            Usuario = "francisco";
            Senha = "123456";
        }

        public string RetornaUsuario()
        {
            return Usuario;
        }

        public string RetornaSenha()
        {
            return Senha;
        }

    }
}
