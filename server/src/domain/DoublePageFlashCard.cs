namespace Domain
{
    public class DoublePageFlashCard : FlashCard
    {
        public DoublePageFlashCard(Page p1, Page p2)
        {
            front = p1;
            back = p2;
        }
        public override Page Show()
        {
            return flipped ? back : front;
        }
        public void Flip()
        {
            flipped = !flipped;
        }

        private bool flipped = false; 
        private Page front;
        private Page back;
    }
}