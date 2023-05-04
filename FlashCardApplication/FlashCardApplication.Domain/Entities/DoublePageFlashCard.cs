namespace FlashCardApplication.Domain.Entities
{
    public class DoublePageFlashCard : FlashCard
    {
        public Page FrontSide { get; set; }
        public Page BackSide { get; set; }
    }
}
