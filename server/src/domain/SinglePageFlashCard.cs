namespace Domain
{
    public class SinglePageFlashCard : FlashCard
    {
        public SinglePageFlashCard(Page p, long moduleId)
        {
            page = p;
            this.moduleId = moduleId;
        }
        public override Page Show()
        {
            return page;
        }
        private Page page;
    }
}