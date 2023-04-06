namespace Domain
{
    public class SinglePageFlashCard : IFlashCard
    {
        public SinglePageFlashCard(Page p, long moduleId)
        {
            page = p;
            this.moduleId = moduleId;
            id = flashCardCount++;
        }
        public Page Show()
        {
            return page;
        }
        private Page page;
        public long ModuleId{get => moduleId;}
        public long Id{get => id;}
        private long moduleId;
        private long id;
        private static long flashCardCount = 0;
    }
}