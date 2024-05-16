using Microsoft.Azure.Cosmos;
using PlacementTask.Services.Interfaces;

namespace PlacementTask.Services
{
    public class DBSetup : IDBSetup
    {
        private readonly CosmosClient _cosmosClient;
        private readonly string _databaseName;
        private readonly string _containerName;

        public DBSetup(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
            _databaseName = "PlacementDb";
            _containerName = "User";
        }

        public async Task CreateUserAsync()
        {
            var database = _cosmosClient.GetDatabase(_databaseName);
            var container = database.GetContainer(_containerName);

            try
            {
                // Insert the record into the container
                var item = new { Message = "Hello world", id = Guid.NewGuid().ToString(), PartitionKey = "/id" }; // Wrapping the string in an object

                await container.CreateItemAsync(item, new PartitionKey(item.PartitionKey));
                Console.WriteLine("Record inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting record: {ex.Message}"); 
                // Handle the error
            }
        }

        #region
        //public Task CreateCollectionAsync(string databaseId, string collectionId)
        //{
        //    throw new NotImplementedException();
        //}

        //        public async Task CreateDatabaseAsync(string databaseId)
        //        {
        //            try
        //            {
        //                CosmosClientOptions cosmosClientOptions = new CosmosClientOptions()
        //                {
        //                    HttpClientFactory = () =>
        //                    {
        //                        HttpMessageHandler httpMessageHandler = new HttpClientHandler()
        //                        {
        //                            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        //                        };

        //                        return new HttpClient(httpMessageHandler);
        //                    },
        //                    ConnectionMode = ConnectionMode.Gateway
        //                };

        //              //  CosmosClient client3 = new CosmosClient(endpoint, authKey, cosmosClientOptions); 


        //                using CosmosClient client = new(
        //    accountEndpoint: "https://localhost:8081/",
        //    authKeyOrResourceToken: "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",cosmosClientOptions
        //);
        //                Database database = await client.CreateDatabaseIfNotExistsAsync(
        //    id: "cosmicworks",
        //    throughput: 400
        //);
        //                await _cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);

        //            }
        //            catch (Exception e)
        //            {
        //                await Console.Out.WriteLineAsync(e.ToString());
        //            }
        //        }

        //        public Task CreateDocumentAsync(string databaseId, string collectionId, object document)
        //        {
        //            throw new NotImplementedException();
        //        }
        #endregion
    }
}
