using Microsoft.EntityFrameworkCore;
using PlacementTask.Data;
using PlacementTask.DTO;
using PlacementTask.Model;
using PlacementTask.Services.Interfaces;

namespace PlacementTask.Services
{
    public class UserService(AppDbContext context) : IUserService
    {
        public async Task<ResponseDTO> CreateAsync(CreateUserDTO model)
        {
            var user = new User()
            {
                CurrentResidence = model.CurrentResidence,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                Email = model.Email,
                Gender = model.Gender,
                IDNumber = model.IDNumber,
                LastName = model.LastName,
                Nationality = model.Nationality,
                Phone = model.Phone
            };
            context.Add(user);
            var saved = await context.SaveChangesAsync() > 0;
            return saved ? Response.SuccessResponse(true): Response.ErrorResponse("Something went wrong");
        }

        public async Task<ResponseDTO> GetUser(string id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x=>x.Id == id);
            if (user == default) return Response.ErrorResponse("User not found");
            var userDTO = new UserDTO()
            {
                CurrentResidence = user.CurrentResidence,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                Email = user.Email,
                Gender = user.Gender,
                IDNumber = user.IDNumber,
                LastName = user.LastName,
                Nationality = user.Nationality,
                Phone = user.Phone
            };
            return Response.SuccessResponse(userDTO);
        }
    }
}
