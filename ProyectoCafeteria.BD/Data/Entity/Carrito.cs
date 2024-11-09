using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoCafeteria.BD.Data.Entity
{
    [Index(nameof(UsuarioId), nameof(Cantidad), Name = "Carrito_UQ", IsUnique = true)]
    public class Carrito : EntityBase
    {
        [Required(ErrorMessage = "La cantidad del carrito es obligatorio.")]
        [MaxLength(5, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Cantidad { get; set; }

        [Required(ErrorMessage = "El Usuario es obligatorio.")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
