using FlashCardApplication.Domain.Abstractions;
using FlashCardApplication.Domain.Entities;
using Serializer;
using System.ComponentModel;

namespace FlashCardApplication.Persistense.Repository
{
    public class LocalFileRepository<T> : IRepository<T> where T : Entity
    {
        private List<T> collection;
        private string path;
        public LocalFileRepository(string path)
        {
            this.path = path;
            collection = new List<T>();
        }
        public async Task AddAsync(T entity)
        {
            await Task.Run(() =>
            {
                collection.Add(entity);
            });
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            await Task.Run(() =>
            {
                var item = FindByIdAsync(id).Result;
                if (item != null)
                {
                    collection.Remove(item);
                }
            });
        }

        public async Task<bool> ExistsById(Guid id)
        {
            return await Task.Run(() =>
            {
                var item = FindByIdAsync(id).Result;
                if (item != null)
                {
                    return true;
                }

                return false;
            });
        }

        public async Task<T?> FindByIdAsync(Guid id)
        {
            return await Task.Run(() =>
            {
                return collection.Where(x => x.Id == id).FirstOrDefault();
            });
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() => collection);
        }

        public async Task UpdateAsync(T entity)
        {
            await DeleteByIdAsync(entity.Id);
            await AddAsync(entity);
        }

        public async Task Load()
        {
            await Task.Run(() =>
            {
                var deserialized = Serializer.Serializer.DeSerializeJSONAsync<List<T>>(path).Result;
                if (deserialized != null)
                {
                    collection.Clear();
                    collection.AddRange(deserialized);
                }
            });
        }

        public async Task Save()
        {
            await Task.Run(() =>
            {
                _ = Serializer.Serializer.SerializeJSONAsync<List<T>>(collection, path);
            });
        }
    }
}
