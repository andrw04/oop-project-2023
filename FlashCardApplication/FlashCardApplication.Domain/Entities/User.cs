namespace FlashCardApplication.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public List<Guid> Modules { get; set; } = new List<Guid>();
    }
}
