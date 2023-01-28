using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebBuilder.API.Mongo;

public interface IDocumentObject
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    ObjectId Id { get; set; }
    DateTime CreatedAt { get; }
}

public class BaseDocumentObject : IDocumentObject
{
    public ObjectId Id { get; set; }
    public DateTime CreatedAt => Id.CreationTime;
}