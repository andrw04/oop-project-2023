using FlashCardApplication.Domain.Abstractions;
using FlashCardApplication.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlashCardApplication.Persistense.Repository
{
    public class Repository<T> : IRepository<T> where T: Entity
    {
        protected IMongoDatabase database;
        protected string collectionName;

        public Repository(string name)
        {
            collectionName = name;
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("FlashCardApp");
        }

        public async Task AddAsync(T entity)
        {
            var collection = database.GetCollection<T>(collectionName);
            await collection.InsertOneAsync(entity);
        }
        public async Task<T?> FindByIdAsync(Guid id)
        {
            var collection = database.GetCollection<T>(collectionName);
            var filter = new BsonDocument { { "_id", id } };
            var cursor = await collection.FindAsync(filter);

            return cursor.FirstOrDefault();
        }

        public async Task<bool> ExistsById(Guid id)
        {
            var collection = database.GetCollection<T>(collectionName);
            var filter = new BsonDocument { { "_id", id } };
            var cursor = await collection.FindAsync(filter);

            if (cursor.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var collection = database.GetCollection<T>(collectionName);
            var result = await collection.FindAsync(new BsonDocument());

            return result.ToList();
        }

        public async Task UpdateAsync(T entity)
        {
            var collection = database.GetCollection<T>(collectionName);
            var filter = new BsonDocument() { { "_id", entity.Id } };
            await collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var collection = database.GetCollection<T>(collectionName);
            var filter = new BsonDocument() { { "_id", id } };
            await collection.DeleteOneAsync(filter);
        }
    }

}
