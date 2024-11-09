using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.BD.Data.Entity
{
    [Index(nameof(Email), Name = "Usuario_UQ", IsUnique = true)]
    public class Usuario : EntityBase
    {
        [Required(ErrorMessage = "El email del Usuario es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El password del Usuario es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Password { get; set; }
    }
}
