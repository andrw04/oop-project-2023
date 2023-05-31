namespace FlashCardApplication.Domain.Entities
{
    public class FlashCard : Entity
    {
        public Guid ModuleId { get; set; }
        public Page FrontSide { get; set; }
        public Page BackSide { get; set; }
    }
}
