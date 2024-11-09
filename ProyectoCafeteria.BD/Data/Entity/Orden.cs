using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.BD.Data.Entity
{
    [Index(nameof(Total), Name = "Orden_UQ", IsUnique = true)]
    public class Orden : EntityBase
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int MetodoPagoId { get; set; }
        public MetodoPago MetodoPago { get; set; }

        [Required(ErrorMessage = "El total de la orden es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Total { get; set; }
        public int DomicilioId { get; set; }
        public Domicilio Domicilio { get; set; }

        //public List<Producto> Productos { get; set; }
    }
}
