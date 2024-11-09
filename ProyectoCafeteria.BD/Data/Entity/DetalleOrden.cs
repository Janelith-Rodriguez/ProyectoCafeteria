using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.BD.Data.Entity
{
    [Index(nameof(Cantidad), Name = "DetalleOrden_UQ", IsUnique = true)]
    public class DetalleOrden : EntityBase
    {
        [Required(ErrorMessage = "La orden del detalle de la orden es obligatorio.")]
        public int OrdenId { get; set; }
        public Orden Orden { get; set; }
        [Required(ErrorMessage = "El producto del detallle de la orden es obligatorio.")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        [Required(ErrorMessage = "La cantidad del detalle de la orden es obligatorio.")]
        [MaxLength(5, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Cantidad { get; set; }

        [Required(ErrorMessage = "El precio del detalle de la orden es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Precio { get; set; }
    }
}
