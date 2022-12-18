using Microsoft.AspNetCore.Hosting.Server.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public PicturesController(IWebHostEnvironment env)
        {
            _env = env;
        }
        [HttpGet("{id}")]
        public IActionResult getpictures(int id)
        {
            var webroot = _env.WebRootPath;
            var path=Path.Combine($"{webroot}/Pictures/", $"pic{id}.jpg");
            var buffer = System.IO.File.ReadAllBytes(path);
            return File(buffer, "image/jpeg");
        }

    }
}
