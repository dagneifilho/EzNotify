using Domain;

namespace WebApi;

public static class DatabaseConfig
{
    public static void ConfigureDatabase(IServiceCollection services, ConfigurationManager configuration){
        string connectionString = configuration.GetSection("MongoDb:ConnectionString").Value;
        string databaseName = configuration.GetSection("MongoDb:DatabaseName").Value;

        MongoConfig mongoConfig = new(connectionString, databaseName);

        services.AddSingleton<MongoConfig>(mongoConfig);
    }
}
