using Newtonsoft.Json;
using PlacementTask.Infrastructure.Enum;
using System.ComponentModel.DataAnnotations;

namespace PlacementTask.Model
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; } 
        public string CurrentResidence { get; set; }
        //public List<Question> Questions { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Enums Gender { get; set; }
    }
}
