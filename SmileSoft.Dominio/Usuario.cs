using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string TipoUsuario { get; set; } // El usuario podria ser: Odontologo,Secretario o Admin(un solo admin)

        public Usuario(string username,string password) 
        { 
            Username = username;
            Password = password;
        }

    }
}
