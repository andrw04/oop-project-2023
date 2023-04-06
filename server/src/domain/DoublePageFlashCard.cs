namespace Domain
{
    public class DoublePageFlashCard : IFlashCard
    {
        public DoublePageFlashCard(Page p1, Page p2, long moduleId)
        {
            front = p1;
            back = p2;
            id = flashCardCount++;
            this.moduleId = moduleId;
        }
        public Page Show()
        {
            return flipped ? back : front;
        }
        public void Flip()
        {
            flipped = flipped ? false : true;
        }

        public long ModuleId{get => moduleId;}
        public long Id{get => id;}
        private bool flipped = false; 
        private Page front;
        private Page back;
        private long moduleId;
        private long id;
        private static long flashCardCount = 0;
    }
}