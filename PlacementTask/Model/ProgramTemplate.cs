using System.ComponentModel.DataAnnotations;

namespace PlacementTask.Model
{
    public class ProgramTemplate : BaseModel
    {
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<Question>? Questions { get; set; }
    }
}
