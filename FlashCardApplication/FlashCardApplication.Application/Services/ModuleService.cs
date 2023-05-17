using FlashCardApplication.MyApplication.Abstractions;
using FlashCardApplication.Domain.Entities;
using FlashCardApplication.Persistense.Repository;

namespace FlashCardApplication.MyApplication.Services
{
    public class ModuleService : IModuleService
    {
        private Repository<Module> moduleRepository;
        private Repository<User> userRepository;
        private Repository<FlashCard> flashCardRepository;
        public ModuleService()
        {
            moduleRepository = new Repository<Module>("Modules");
            userRepository = new Repository<User>("Users");
            flashCardRepository = new Repository<FlashCard>("FlashCards");
        }
        public async Task AddAsync(Module entity)
        {
            var user = await userRepository.FindByIdAsync(entity.UserId);
            if (user != null)
            {
                await moduleRepository.AddAsync(entity);
                user.Modules.Add(entity.Id);
                await userRepository.UpdateAsync(user);
            }
        }

        public async Task AddFlashCardAsync(Guid ModuleId, FlashCard flashCard)
        {
            var module = await moduleRepository.FindByIdAsync(ModuleId);
            if (module != null)
            {
                flashCard.ModuleId = module.Id;
                await flashCardRepository.AddAsync(flashCard);
                module.FlashCards.Add(flashCard.Id);
                await moduleRepository.UpdateAsync(module);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var module = await moduleRepository.FindByIdAsync(id);
            if (module != null)
            {
                var user = await userRepository.FindByIdAsync(module.UserId);
                if (user != null)
                {
                    foreach (var fs in module.FlashCards)
                    {
                        await flashCardRepository.DeleteByIdAsync(fs);
                    }

                    user.Modules.Remove(module.Id);
                    await userRepository.UpdateAsync(user);
                    await moduleRepository.DeleteByIdAsync(module.Id);
                }
            }
        }

        public async Task DeleteFlashCardAsync(Guid FlashCardId)
        {
            var flashCard = await flashCardRepository.FindByIdAsync(FlashCardId);
            if (flashCard != null)
            {
                var module = await moduleRepository.FindByIdAsync(flashCard.ModuleId);
                if (module != null)
                {
                    module.FlashCards.Remove(flashCard.Id);
                    await moduleRepository.UpdateAsync(module);
                    await flashCardRepository.DeleteByIdAsync(flashCard.Id);
                }
            }
        }

        public async Task<IEnumerable<Module>> GetAllAsync()
        {
            return await moduleRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Module>> GetAllUserModules(Guid userId)
        {
            var modules = await moduleRepository.GetAllAsync();

            return modules.Where(x => x.UserId == userId);

        }

        public async Task<Module?> GetByIdAsync(Guid id)
        {
            return await moduleRepository.FindByIdAsync(id);
        }

        public async Task UpdateAsync(Module entity)
        {
            await moduleRepository.UpdateAsync(entity);
        }
    }
}
