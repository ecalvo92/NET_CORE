using Microsoft.AspNetCore.Mvc;
using NetCore_API.Entities;

namespace NetCore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public static List<Usuario> lista = new List<Usuario>();

        [HttpGet]
        [Route("ConsultarUsuarios")]
        public IActionResult ConsultarUsuarios()
        {
            return Ok(lista);
        }

        [HttpGet]
        [Route("ConsultarUsuario")]
        public IActionResult ConsultarUsuario(int Id)
        {
            var resultado = lista.Where(x => x.Id == Id).FirstOrDefault();
            return Ok(resultado);
        }

        [HttpPost]
        [Route("AgregarUsuario")]
        public IActionResult AgregarUsuario(Usuario Entidad)
        {
            lista.Add(Entidad);
            return Ok(lista);
        }

        [HttpPut]
        [Route("ActualizarUsuario")]
        public IActionResult ActualizarUsuario(Usuario Entidad)
        {
            foreach (var item in lista.Where(x => x.Id == Entidad.Id))
            {
                item.Nombre = Entidad.Nombre;
                item.Estado = Entidad.Estado;
            }

            return Ok(lista);
        }

        [HttpDelete]
        [Route("EliminarUsuario")]
        public IActionResult EliminarUsuario(int Id)
        {
            var resultado = lista.Where(x => x.Id == Id).FirstOrDefault();
            lista.Remove(resultado!);
            return Ok(lista);
        }

    }
}