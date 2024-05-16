using System.ComponentModel.DataAnnotations;

namespace PlacementTask.DTO
{
    public class ProgramTemplateDTO
    {
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
    }

    public class CreateProgramDTO
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        public List<CreateQuestionDTO>? Questions { get; set; }
    }

    public class EditProgramDTO : CreateProgramDTO
    {

    }
}
