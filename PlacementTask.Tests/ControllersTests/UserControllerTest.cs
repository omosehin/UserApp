using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PlacementTask.Controllers;
using PlacementTask.DTO;
using PlacementTask.Services;
using PlacementTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementTask.Tests.ControllersTests
{
    public class UserControllerTest
    {
        private readonly IUserService userService;

        public UserControllerTest()
        {
            userService = A.Fake<IUserService>();
        }

        [Fact]
        public async Task User_CreateUser_ReturnsOk()
        {
            var createModel = A.Fake<CreateUserDTO>();
            var expectedResult = new ResponseDTO()
            {
                    Data = true,
                    Message = "Successful Operation",
                    Status = true
            };
            A.CallTo(() => userService.CreateAsync(createModel)).Returns(Task.FromResult(expectedResult));
            var controller = new UsersController(userService);
            var result = await controller.Create(createModel);
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var resultObject = result as OkObjectResult;
            resultObject?.Value.Should().BeEquivalentTo(expectedResult);
            resultObject?.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task User_GetUser_ReturnsOk()
        {
            var userId = Guid.NewGuid().ToString();
            var expectedResult = new ResponseDTO()
            {
                Data = A.Fake<UserDTO>(),
                Message = "Successful Operation",
                Status = true
            };
            A.CallTo(() => userService.GetUser(userId)).Returns(Task.FromResult(expectedResult));
            var controller = new UsersController(userService);
            var result = await controller.GetUser(userId);
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var resultObject = result as OkObjectResult;
            resultObject?.Value.Should().BeEquivalentTo(expectedResult);
            resultObject?.StatusCode.Should().Be(200);
        }
    }
}
