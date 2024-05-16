using Microsoft.AspNetCore.Mvc;
using PlacementTask.DTO;
using PlacementTask.Model;
using PlacementTask.Services.Interfaces;

namespace PlacementTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await userService.GetUser(id);
            return user.Status ? Ok(user) : BadRequest(user.Message);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDTO user)
        {
            try
            {
                var createUser = await userService.CreateAsync(user);
                return Ok(createUser);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
