using FlashCardApplication.AppServices.Abstractions;
using FlashCardApplication.Domain.Abstractions;
using FlashCardApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.AppServices.Services
{
    public class ModuleService : IModuleService
    {
        private IUnitOfWork _unitOfWork;
        public ModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(Module item)
        {
            await _unitOfWork.CreateDatabaseAsync();
            await _unitOfWork.ModuleRepository.AddAsync(item);
        }

        public async Task DeleteAsync(Module item)
        {
            await _unitOfWork.ModuleRepository.DeleteAsync(item);
        }

        public async Task<IEnumerable<Module>> GetAllAsync()
        {
            return await _unitOfWork.ModuleRepository.ListAllAsync();
        }

        public async Task<Module> GetByIdAsync(int id)
        {
            return await _unitOfWork.ModuleRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Module item)
        {
            await _unitOfWork.ModuleRepository.UpdateAsync(item);
        }
    }
}
