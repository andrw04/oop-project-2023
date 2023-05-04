using MongoDB.Bson.Serialization.Attributes;


namespace FlashCardApplication.Domain.Entities
{
    public class Entity
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
