using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("RegistrarError")]
        public IActionResult RegistrarError()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(
                detail : context!.Path,
                title : context!.Error.Message);
        }
    }
}