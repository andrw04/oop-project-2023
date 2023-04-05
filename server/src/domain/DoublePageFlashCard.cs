namespace Domain
{
    public class DoublePageFlashCard : IFlashCard
    {
        public DoublePageFlashCard(Page p1, Page p2)
        {
            front = p1;
            back = p2;
        }
        public Page Show()
        {
            return flipped ? back : front;
        }
        public void Flip()
        {
            flipped = flipped ? false : true;
        }
        private bool flipped = false; 
        private Page front;
        private Page back;
    }
}