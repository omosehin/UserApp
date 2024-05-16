using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlacementTask.Services;
using PlacementTask.Services.Interfaces;

namespace PlacementTask.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class DbSetUpController(IDBSetup dbSetup) : ControllerBase
    {
        private readonly IDBSetup _dBSetup = dbSetup;

        [HttpPost("createdatabase")]
        public async Task<IActionResult> CreateDatabaseAsync()
        {
            await _dBSetup.CreateUserAsync();
            return Ok("Database created successfully");
        }


    }
}
