using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.BD.Data.Entity
{
    public class Usuario : EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
