using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCafeteria.BD.Data;
using ProyectoCafeteria.BD.Data.Entity;

namespace ProyectoCafeteria.Server.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]   //Este controlador manejará las operaciones CRUD para los usuarios.
    public class UsuariosControllers : ControllerBase
    {
        private readonly Context context;

        public UsuariosControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]   // Método para ver todos los usuarios
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await context.Usuarios.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(Usuario entidad)
        {
            try
            {
                context.Usuarios.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
               return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]  //api/Usuarios/2----------// Método para actualizar un usuario existente
        public async Task<ActionResult> Put(int id, [FromBody] Usuario entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var c = await context.Usuarios
                          .Where(e => e.Id==id)
                          .FirstOrDefaultAsync();
            if (c == null)
            {
                return NotFound("No existe el usuario buscado.");
            }

            c.Email = entidad.Email;
            c.Password = entidad.Password;
            c.Activo = entidad.Activo;

            try
            {
                context.Usuarios.Update(c);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
