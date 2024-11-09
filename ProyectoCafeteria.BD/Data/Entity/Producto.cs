using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.BD.Data.Entity
{
    [Index(nameof(Nombre), Name = "Producto_UQ", IsUnique = true)]
    public class Producto : EntityBase
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Precio { get; set; }

        [Required(ErrorMessage = "La fecha del producto es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public DateTime Fecha { get; set; }
        public List<Orden> Ordenes { get; set; }
    }
}

