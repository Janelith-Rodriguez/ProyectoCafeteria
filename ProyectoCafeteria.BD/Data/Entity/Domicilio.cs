using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.BD.Data.Entity
{
    [Index(nameof(Telefono), Name = "Domicilio_UQ", IsUnique = true)]
    public class Domicilio : EntityBase
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "La fecha del producto es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "La fecha del producto es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string CP { get; set; }
    }
}
