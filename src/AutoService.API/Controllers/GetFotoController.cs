using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetFotoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetFoto(string path) 
        {
            var fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "image/jpeg");
        }
    }
}
