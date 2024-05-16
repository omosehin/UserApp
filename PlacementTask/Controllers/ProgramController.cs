using Microsoft.AspNetCore.Mvc;
using PlacementTask.DTO;
using PlacementTask.Services;

namespace PlacementTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController(IProgramService programService) : ControllerBase
    {
        [HttpPost(Name = "Create Program")]
        public async Task<IActionResult> CreateProgram([FromBody] CreateProgramDTO model)
        {
            var created = await programService.CreateProgram(model);
            return Ok(created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgram(string id)
        {
            var program = await programService.GetProgram(id);
            return Ok(program);
        }

        [HttpPut("{programId}")]
        public async Task<IActionResult> PutApplication(string programId, [FromBody] EditProgramDTO model)
        {
            var application = await programService.UpdateProgram(programId, model);
            return Ok(application);
        }
    }
}
