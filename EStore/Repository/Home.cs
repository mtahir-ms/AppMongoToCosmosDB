using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Linq;
using System;

namespace EStore.Repository
{
    public class Home
    {
        private readonly IMongoClient _mongoClient;
        private readonly string _databaseName;
        private readonly IConfiguration _configuration;
        public Home(IMongoClient mongoClient, string databaseName, IConfiguration configuration)
        {
            _mongoClient = mongoClient;
            _databaseName = databaseName;
            _configuration = configuration;
        }

        public async Task<List<BsonDocument>> GetAllDataAsync()
        {
            try
            {
                //MongoClient is used for MongoDB and Cosmos DB both. 
                IMongoDatabase database = _mongoClient.GetDatabase(_databaseName);
                IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("Products");
                var documents = await collection.Find(_ => true).ToListAsync();
                return documents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Home ConnectionStringSetUp(IConfiguration configuration)
        {
            try
            {
                //Only make changes to connection string here. 
                //Add this code to your application line 45 to 68. 

                var databaseName = configuration["DatabaseName"];
                var DatabaseProvider = configuration["DatabaseProvider"];
                if (DatabaseProvider == "MongoDB")
                {
                    var connectionString = configuration.GetConnectionString("LocalMongoDB");
                    var mongoClient = new MongoClient(connectionString);
                    return new Home(mongoClient, databaseName, configuration);
                }
                else
                {
                    //Cosmos DB connection string has some extra parameters. 
                    var connectionString = configuration.GetConnectionString("CosmosDB");
                    MongoClientSettings settings = MongoClientSettings.FromUrl(
                      new MongoUrl(connectionString)
                    );
                    settings.SslSettings =
                      new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                    var mongoClient = new MongoClient(settings);
                    return new Home(mongoClient, databaseName, configuration);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
