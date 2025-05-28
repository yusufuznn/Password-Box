using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasswordBox.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VersionController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public VersionController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> GetVersion()
        {
            var path = Path.Combine(_env.ContentRootPath, "App_Data", "version.json");

            if (!System.IO.File.Exists(path))
                return NotFound("Version file not found");

            var json = await System.IO.File.ReadAllTextAsync(path);
            var versionInfo = JsonSerializer.Deserialize<VersionInfo>(json);

            return Ok(versionInfo);
        }

        public class VersionInfo
        {
            [JsonPropertyName("version")]
            public string Version { get; set; }

            [JsonPropertyName("buildDate")]
            public string BuildDate { get; set; }

            [JsonPropertyName("notes")]
            public string[] Notes { get; set; }

            [JsonPropertyName("author")]
            public string Author { get; set; }
        }
    }
}
