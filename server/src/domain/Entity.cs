namespace Domain
{
    public class Entity
    {
        public Entity()
        {
            id = count++;
        }
        public long Id{get;}
        private long id;
        static long count = 0;
    }
}