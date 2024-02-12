# AppMongoToCosmosDB

This is a sample Application utilizing ASP.net core and Mongo DB
An onprem applicagtion will be migrated to the cloud for Cosmos DB/Cloud scenario. 

Application code will not require much changes. Only connection string will change and few line of code to establish the connection. 

Rest of the application should continue to function since It is based on JSON structure (and BSON in c#). 

This application will connect with both Mongo DB and Cosmos DB to cover the scenarios. Only a configuration change is required. 

- Setup Instructions

- Install latest Mongo DB with Atlas client 
- Import datafiles/products JSON file 
- git clone/VS code from https://github.com/mtahir-ms/EStoreWeb
- Review code change, if any,
- Run the application locally
- Create Azure CosmosDB for MongoDB with vCore option
- Migrate data using Azure Data Studio or run JSON file import
- Connect local instance to Azure CosmosDB to validate the application
- Publish to an Azure App Service Plan and validate the application in Azure/CosmosDB.
- 2 to 4 hours. 

----Application only needs following changes. Add new connection string block. This code is in Repository/Home.cs class. -------------
You can continue to use  MongoDB.Bson and MongoDB.Driver without changing any application code. and only add connection string updates like below. 



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
        
