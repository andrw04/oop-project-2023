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
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(User item)
        {
            await _unitOfWork.UserRepository.AddAsync(item);
        }

        public Task ChangeUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(User item)
        {
            await _unitOfWork.UserRepository.DeleteAsync(item);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _unitOfWork.UserRepository.ListAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _unitOfWork.UserRepository.GetByIdAsync(id);
        }

        public Task<User?> Login(string login, string password)
        {
            var users = _unitOfWork.UserRepository.ListAsync((x) => x.Login == login).Result;
            foreach(var user in users)
            {
                if (user.Password == password)
                    return Task.FromResult(user);
            }
            return null;
        }

        public Task Registrate(User user)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User item)
        {
           await  _unitOfWork.UserRepository.UpdateAsync(item);
        }
    }
}
