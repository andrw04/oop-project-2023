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
    public class FlashCardService : IFlashCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FlashCardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(FlashCard item)
        {
            await _unitOfWork.FlashCardRepository.AddAsync(item);
        }

        public async Task DeleteAsync(FlashCard item)
        {
            await _unitOfWork.FlashCardRepository.DeleteAsync(item);
        }

        public async Task<IEnumerable<FlashCard>> GetAllAsync()
        {
            return await _unitOfWork.FlashCardRepository.ListAllAsync();
        }

        public async Task<FlashCard> GetByIdAsync(int id)
        {
            return await _unitOfWork.FlashCardRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(FlashCard item)
        {
            await _unitOfWork.FlashCardRepository.UpdateAsync(item);
        }
    }
}
