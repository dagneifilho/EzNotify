using Domain;
using MongoDB.Driver;

namespace Infra;

public class MongoDbContext : IMongoDbContext
{
    private readonly MongoConfig _mongoConfig;
    private IMongoDatabase _database {get; set;}
    private  MongoClient _mongoClient;
    public MongoDbContext(MongoConfig mongoConfig) 
    {
        _mongoConfig = mongoConfig; 
    }

    public void InitializeMongo(){
        MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(_mongoConfig.ConnectionString));
        _mongoClient = new(settings);
        _database = _mongoClient.GetDatabase(_mongoConfig.DatabaseName);
    }
    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        InitializeMongo();
        return _database.GetCollection<T>(collectionName);
    }

    #region Dispose

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
    #endregion
}
