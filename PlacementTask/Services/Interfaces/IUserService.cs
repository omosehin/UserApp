using PlacementTask.DTO;
using PlacementTask.Model;

namespace PlacementTask.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseDTO> CreateAsync(CreateUserDTO user);
        Task<ResponseDTO> GetUser(string id);
    }
}