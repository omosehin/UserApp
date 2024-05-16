

using PlacementTask.Infrastructure.Enum;

namespace PlacementTask.Model
{
    public class Question : BaseModel
    {
        public QuestionType Type { get; set; }
        public string? AskQuestion { get; set; }
        public List<string>? Answers { get; set; } // question and answer pair

    }
}
