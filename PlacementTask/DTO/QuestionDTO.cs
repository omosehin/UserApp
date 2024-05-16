using PlacementTask.Infrastructure.Enum;

namespace PlacementTask.DTO
{
    public class QuestionDTO
    {
    }

    public class CreateQuestionDTO()
    {
        public QuestionType QuestionType { get; set; }
        public string? AskQuestion { get; set; }
        public List<string>? Answers { get; set; } // question and answer pair
    }
}
