namespace Domain
{
    public class DoublePageFlashCard : FlashCard
    {
        public DoublePageFlashCard(Page p1, Page p2, long moduleId)
        {
            front = p1;
            back = p2;
            this.moduleId = moduleId;
        }
        public override Page Show()
        {
            return flipped ? back : front;
        }
        public void Flip()
        {
            flipped = flipped ? false : true;
        }

        public long ModuleId{get => moduleId;}
        private bool flipped = false; 
        private Page front;
        private Page back;
        private long moduleId;
    }
}