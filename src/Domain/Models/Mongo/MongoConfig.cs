namespace Domain;

public class MongoConfig
{
    public MongoConfig(string connectionString, string databaseName) 
    {
        ConnectionString = connectionString;
        DatabaseName = databaseName;
    }
    public string ConnectionString {get; set;}
    public string DatabaseName {get;set;}
}
