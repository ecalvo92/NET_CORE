using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore_API.Database;
using NetCore_API.Entities;

namespace NetCore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Context _context;
        public UsuarioController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ConsultarUsuarios")]
        public async Task<IActionResult> ConsultarUsuarios()
        {
            var datos = await _context.tUsuario.ToListAsync();
            return Ok(datos);
        }

        [HttpGet]
        [Route("ConsultarUsuario")]
        public async Task<IActionResult> ConsultarUsuario(int Id)
        {
            var dato = await _context.tUsuario.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return Ok(dato);
        }

        [HttpPost]
        [Route("AgregarUsuario")]
        public async Task<IActionResult> AgregarUsuario(Usuario Entidad)
        {
            _context.tUsuario.Add(Entidad);
            await _context.SaveChangesAsync();

            var datos = await _context.tUsuario.ToListAsync();
            return Ok(datos);
        }

        [HttpPut]
        [Route("ActualizarUsuario")]
        public async Task<IActionResult> ActualizarUsuario(Usuario Entidad)
        {
            var dato = await _context.tUsuario.Where(x => x.Id == Entidad.Id).FirstOrDefaultAsync();
            dato!.Nombre = Entidad.Nombre;
            dato!.Estado = Entidad.Estado;
            await _context.SaveChangesAsync();

            var datos = await _context.tUsuario.ToListAsync();
            return Ok(datos);
        }

        [HttpDelete]
        [Route("EliminarUsuario")]
        public async Task<IActionResult> EliminarUsuario(int Id)
        {
            var dato = await _context.tUsuario.Where(x => x.Id == Id).FirstOrDefaultAsync();
            _context.tUsuario.Remove(dato!);
            await _context.SaveChangesAsync();

            var datos = await _context.tUsuario.ToListAsync();
            return Ok(datos);
        }

    }
}