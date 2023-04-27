using FlashCardApplication.AppServices.Abstractions;
using FlashCardApplication.Domain.Abstractions;
using FlashCardApplication.Domain.Entities;

namespace FlashCardApplication.AppServices.Services
{
    public class DoublePageFlashCardService : IDoublePageFlashCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DoublePageFlashCardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(DoublePageFlashCard item)
        {
            await _unitOfWork.DoublePageFlashCardRepository.AddAsync(item);
        }

        public async Task DeleteAsync(DoublePageFlashCard item)
        {
            await _unitOfWork.DoublePageFlashCardRepository.DeleteAsync(item);
        }

        public void Flip(DoublePageFlashCard flashCard)
        {
            flashCard.Flipped = !flashCard.Flipped;
        }

        public async Task<IEnumerable<DoublePageFlashCard>> GetAllAsync()
        {
            return await _unitOfWork.DoublePageFlashCardRepository.ListAllAsync();
        }

        public async Task<DoublePageFlashCard> GetByIdAsync(int id)
        {
            return await _unitOfWork.DoublePageFlashCardRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(DoublePageFlashCard item)
        {
            await _unitOfWork.DoublePageFlashCardRepository.UpdateAsync(item);
        }
    }
}
