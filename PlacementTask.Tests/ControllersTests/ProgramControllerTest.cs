using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PlacementTask.Controllers;
using PlacementTask.DTO;
using PlacementTask.Services;

namespace PlacementTask.Tests.ControllersTests
{
    public class ProgramControllerTest
    {
        private readonly IProgramService programService;

        public ProgramControllerTest()
        {
            programService = A.Fake<IProgramService>();
        }

        [Fact]
        public async Task Program_CreateProgram_ReturnsOk()
        {
            var createModel = A.Fake<CreateProgramDTO>();
            var expectedCreateModel = new ResponseDTO()
            {
                Data = true,
                Message = "Successful Operation",
                Status = true
            };
            A.CallTo(() => programService.CreateProgram(createModel)).Returns(Task.FromResult(expectedCreateModel));
            var controller = new ProgramController(programService);
           
            var result = await controller.CreateProgram(createModel);
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var resultObject = result as OkObjectResult;
            resultObject?.Value.Should().BeEquivalentTo(expectedCreateModel);
            resultObject?.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Program_GetProgram_ReturnsOk()
        {
            var programId = Guid.NewGuid().ToString();
            var expectedResult = new ResponseDTO()
            {
                Data = A.Fake<UserDTO>(),
                Message = "Successful Operation",
                Status = true
            };
            A.CallTo(() => programService.GetProgram(programId)).Returns(Task.FromResult(expectedResult));
            var controller = new ProgramController(programService);
            var result = await controller.GetProgram(programId);

            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var resultObject = result as OkObjectResult;
            resultObject?.Value.Should().BeEquivalentTo(expectedResult);
            resultObject?.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task Program_EditProgram_ReturnsOk()
        {
            var editModel = A.Fake<EditProgramDTO>();
            var programId = Guid.NewGuid().ToString();  
            var expectedEditModel = new ResponseDTO()
            {
                Data = true,
                Message = "Successful Operation",
                Status = true
            };
            A.CallTo(() => programService.UpdateProgram(programId, editModel)).Returns(Task.FromResult(expectedEditModel));
            var controller = new ProgramController(programService);

            var result = await controller.PutApplication(programId,editModel);
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var resultObject = result as OkObjectResult;
            resultObject?.Value.Should().BeEquivalentTo(expectedEditModel);
            resultObject?.StatusCode.Should().Be(200);
        }

    }
}
