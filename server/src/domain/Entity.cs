namespace Domain
{
    public class Entity
    {
        public Entity()
        {
            id = count;
            count += 1;
        }
        public long Id{get => id;}
        protected long id;
        protected static long count = 0;
    }
}