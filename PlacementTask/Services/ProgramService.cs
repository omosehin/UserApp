using Microsoft.EntityFrameworkCore;
using PlacementTask.Data;
using PlacementTask.DTO;
using PlacementTask.Model;

namespace PlacementTask.Services
{
    public class ProgramService(AppDbContext context) : IProgramService
    {
        public async Task<ResponseDTO> CreateProgram(CreateProgramDTO model)
        {
            var program = new ProgramTemplate()
            {
                 Description = model.Description,
                 Title = model.Title,
            };
            if (model.Questions != null && model.Questions.Count > 0)
            {
                var questions = model.Questions.Select(x => new Question()
                {
                     Answers = x.Answers,
                     AskQuestion = x.AskQuestion,
                     Type = x.QuestionType
                }).ToList();
                program.Questions = questions;
            }
            await context.AddAsync(program);
            await context.SaveChangesAsync();
            return Response.SuccessResponse(true);
        }

        public async Task<ResponseDTO> GetProgram(string id)
        {
            var program = await context.Programs.FirstOrDefaultAsync(x => x.Id == id);
            if (program == null) return Response.ErrorResponse("Program not found");
            var response = new ProgramTemplateDTO()
            {
                 Description = program.Description,
                 Title = program.Title,
            };
            return Response.SuccessResponse(program);
        }
    
        public async Task<ResponseDTO> UpdateProgram(string programId, EditProgramDTO model)
        {
            var program = await context.Programs.FirstOrDefaultAsync(x => x.Id == programId);
            if (program == default) return Response.ErrorResponse("Invalid program Id");
            if(program.Title !=  model.Title && model.Title != default) {
                program.Title = model.Title;
            }
            if(program.Description != model.Description && model.Title != default)
            {
                program.Description = model.Description;
            }
            if(model.Questions.Count > 0)
            {
                var questions = model.Questions.Select(x => new Question()
                {
                    Answers = x.Answers,
                    AskQuestion = x.AskQuestion,
                    Type = x.QuestionType
                }).ToList();
                program.Questions = questions;
            }
            context.Update(program);
            var saved = await context.SaveChangesAsync() > 0;
            return saved ? Response.SuccessResponse(true) : Response.ErrorResponse("Unable to update your program");
        }
    }
}
