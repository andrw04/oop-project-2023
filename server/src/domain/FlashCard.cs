namespace Domain
{
    public abstract class FlashCard : Entity
    {
        abstract public Page Show();
        public long ModuleId{get => moduleId; set => moduleId = value;}
        protected long moduleId = -1;
    }
}