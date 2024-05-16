using PlacementTask.Infrastructure.Enum;

namespace PlacementTask.DTO
{
    public class CreateUserDTO
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

    public class UserDTO : CreateUserDTO
    {
        public string Id {  get; set; }
    }
}
