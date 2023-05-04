using FlashCardApplication.Domain.Entities;

namespace FlashCardApplication.Application.Abstractions
{
    public interface IModuleService : IBaseService<Module>
    {
        Task AddFlashCardAsync(Guid ModuleId, FlashCard flashCard);

        Task DeleteFlashCardAsync(Guid FlashCardId);

        Task<IEnumerable<Module>> GetAllUserModules(Guid userId);
    }
}
