using Domain;
using Repository;
using Events;

namespace Services
{
    public class ModuleService
    {
        public ModuleService(EventManager manager)
        {
            modules = new ModuleRepository();
            flashCards = new FlashCardRepository();
            this.eventManager = manager;
        }
        public void CreateModule(Module module)
        {
            modules.Save(module);
            eventManager.Notify($"{DateTime.Now} Module {module.Id} has been created.");
        }
        public void AddFlashCard(FlashCard flashCard, Module module)
        {
            flashCard.ModuleId = module.Id;
            flashCards.Save(flashCard);
            eventManager.Notify($"{DateTime.Now} FlashCard {flashCard.Id} has been added to module {module.Id}.");
        }
        public void DeleteFlashCard(FlashCard flashCard)
        {
            if (flashCards.ExistsById(flashCard.Id))
            {
                flashCards.DeleteById(flashCard.Id);
                eventManager.Notify($"{DateTime.Now} FlashCard {flashCard.Id} has been deleted");
            }
        }

        public IEnumerable<FlashCard> GetAllFlashCards()
        {
            List<FlashCard> result = new();
            foreach (var st in flashCards.GetAll())
            {
                result.Add((FlashCard)st);
            }

            return result;
        }
        public IEnumerable<Module> GetAllModulesByName(string name)
        {
            return modules.FindAllByName(name);
        }
        public IEnumerable<Module> GetAllModulesByAuthorName(string author)
        {
            return modules.FindAllByAuthorName(author);
        }
        public Module? GetModuleById(long id)
        {
            var test = modules.FindById(id);
            if(test != null)
            {
                var module = (Module)test;
                return module;
            }
            return null;
        }
        public void DeleteModule(long id)
        {
            if (modules.ExistsById(id))
            {
                modules.DeleteById(id);
                eventManager.Notify($"{DateTime.Now} Module {id} has been deleted.");
            }

        }
        private ModuleRepository modules;
        private FlashCardRepository flashCards;
        private EventManager eventManager;
    }
}