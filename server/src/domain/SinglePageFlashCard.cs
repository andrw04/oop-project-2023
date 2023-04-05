namespace Domain
{
    public class SinglePageFlashCard : IFlashCard
    {
        public SinglePageFlashCard(Page p)
        {
            page = p;
        }
        public Page Show()
        {
            return page;
        }
        private Page page;
    }
}