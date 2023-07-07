using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game.Api.Controllers
{
    public class ErrorsController : ApiController
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}
