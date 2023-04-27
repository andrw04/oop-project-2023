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
    public class SinglePageFlashCardService : ISinglePageFlashCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SinglePageFlashCardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(SinglePageFlashCard item)
        {
             await _unitOfWork.SinglePageFlashCardRepository.AddAsync(item);
        }

        public async Task DeleteAsync(SinglePageFlashCard item)
        {
             await _unitOfWork.SinglePageFlashCardRepository.DeleteAsync(item);
        }

        public async Task<IEnumerable<SinglePageFlashCard>> GetAllAsync()
        {
            return await _unitOfWork.SinglePageFlashCardRepository.ListAllAsync();
        }

        public async Task<SinglePageFlashCard> GetByIdAsync(int id)
        {
            return await _unitOfWork.SinglePageFlashCardRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(SinglePageFlashCard item)
        {
            await _unitOfWork.SinglePageFlashCardRepository.UpdateAsync(item);
        }
    }
}
