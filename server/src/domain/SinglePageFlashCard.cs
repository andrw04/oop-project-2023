namespace Domain
{
    public class SinglePageFlashCard : FlashCard
    {
        public SinglePageFlashCard(Page p)
        {
            page = p;
        }
        public override Page Show()
        {
            return page;
        }
        private Page page;
    }
}