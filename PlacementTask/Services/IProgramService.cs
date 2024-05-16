using PlacementTask.DTO;

namespace PlacementTask.Services
{
    public interface IProgramService
    {
        Task<ResponseDTO> CreateProgram(CreateProgramDTO model);
        Task<ResponseDTO> GetProgram(string id);
        Task<ResponseDTO> UpdateProgram(string programId, EditProgramDTO model);
    }
}