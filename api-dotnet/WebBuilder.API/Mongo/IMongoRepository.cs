using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;
using WebBuilder.API.Attributes;
using WebBuilder.API.Models;

namespace WebBuilder.API.Mongo;

public interface IMongoRepository<TDocument> where TDocument : IDocumentObject
{

    Task<List<TDocument>> FilterByAsync(
        Expression<Func<TDocument, bool>> filterExpression);

    Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);

    Task<TDocument> FindByIdAsync(string id);

    Task<string> InsertOneAsync(TDocument document);

    Task<bool> ReplaceOneAsync(TDocument document);

    Task<bool> DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);

    Task<bool> DeleteByIdAsync(string id);
}

public class MongoRepositorty<TDocument> : IMongoRepository<TDocument>
    where TDocument : IDocumentObject
{
    private readonly IMongoCollection<TDocument> _collection;
    private readonly MongoDbSettings _settings;
    public MongoRepositorty()
    {
        var database = new MongoClient("mongodb://localhost:27017").GetDatabase("WebBuilderDb");
        _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
    }

    private protected string GetCollectionName(Type documentType)
    {
        string collectionName = ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true)?.FirstOrDefault())?.CollectionName;
        return collectionName;
    }

    public async Task<bool> DeleteByIdAsync(string id)
    {
        try
        {
            var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            var result = await _collection.FindOneAndDeleteAsync(filter);
            return result == null ? false : true;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<bool> DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
    {
        try
        {
            await _collection.FindOneAndDeleteAsync(filterExpression);
            return true;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<TDocument>> FilterByAsync(Expression<Func<TDocument, bool>> filterExpression)
    {
        try
        {
            var data = await _collection.FindAsync(filterExpression);
            return await data.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<TDocument> FindByIdAsync(string id)
    {
        try
        {
            var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
    {
        try
        {
            return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<string> InsertOneAsync(TDocument document)
    {
        try
        {
            await _collection.InsertOneAsync(document);
            return document.Id.ToString();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<bool> ReplaceOneAsync(TDocument document)
    {
        try
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            await _collection.FindOneAndReplaceAsync(filter, document);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}