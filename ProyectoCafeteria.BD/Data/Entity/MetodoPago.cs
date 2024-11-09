using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.BD.Data.Entity
{
    [Index(nameof(Nombre), Name = "MetodoPago_UQ", IsUnique = true)]
    public class MetodoPago : EntityBase
    {
        [Required(ErrorMessage = "El nombre del métedo de pago es obligatorio.")]
        [MaxLength(20, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Nombre { get; set; }
    }
}
