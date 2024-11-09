using Microsoft.EntityFrameworkCore;
using ProyectoCafeteria.BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.BD.Data
{
    public class Context : DbContext
    {
        
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<DetalleOrden> DetallesOrdenes { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<MetodoPago> MetodosPagos { get; set; }
        public DbSet<Orden> Ordenes { get; set; }       
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }    
                
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                          .SelectMany(t => t.GetForeignKeys())
                                          .Where(fk => !fk.IsOwnership
                                              && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
