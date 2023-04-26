using FlashCardApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.AppServices.Abstractions
{
    public interface IModuleService : IBaseService<Module>
    {
        Task<IReadOnlyList<Module>> GetModulesByNameAsync(string name);

        Task<IReadOnlyList<Module>> GetAllByAuthorName(string authorName);
    }
}
