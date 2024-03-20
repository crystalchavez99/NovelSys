using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NovelSys.Api.Controllers
{
    [Route("api/[controller]")]
    public class LibraryController : ApiController
    {
        [HttpGet]
        public IActionResult ListLibraries()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
