using PlacementTask.Model;

namespace PlacementTask.Services.Interfaces
{
    public interface IDBSetup
    {
        Task CreateUserAsync();
        //Task CreateDatabaseAsync(string databaseId);
        //Task CreateCollectionAsync(string databaseId, string collectionId);
        //Task CreateDocumentAsync(string databaseId, string collectionId, object document);
    }
}
