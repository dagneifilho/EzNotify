using MongoDB.Driver;

namespace Infra;

public interface IMongoDbContext : IDisposable
{
    IMongoCollection<T> GetCollection<T>(string collectionName);
}
