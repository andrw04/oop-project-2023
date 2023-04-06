using Domain;

namespace Repository
{
    public class FlashCardRepository : IFlashCardRepository
    {
        public long Count()
        {
            return flashCards.Count;
        }

        public void DeleteAll(IEnumerable<IFlashCard> entities)
        {
            foreach(var entity in entities)
            {
                if(ExistsById(entity.Id))
                    flashCards.Remove(entity);
            }
        }

        public void DeleteById(long id)
        {
            var item = FindById(id);
            if(item != null)
                flashCards.Remove(item);
        }

        public bool ExistsById(long id)
        {
            foreach(var flashCard in flashCards)
            {
                if(flashCard.Id == id)
                    return true;
            }
            return false;
        }

        public IEnumerable<IFlashCard> FindAll(long moduleId)
        {
            List<IFlashCard> result = new();
            foreach(var flashCard in flashCards)
            {
                if(flashCard.ModuleId == moduleId)
                    result.Add(flashCard);
            }
            return result;
        }

        public IFlashCard? FindById(long id)
        {
            foreach(var flashCard in flashCards)
            {
                if(flashCard.Id == id)
                    return flashCard;
            }
            return null;
        }

        public void Save(IFlashCard entity)
        {
            flashCards.Add(entity);
        }

        private List<IFlashCard> flashCards = new();
    }
}