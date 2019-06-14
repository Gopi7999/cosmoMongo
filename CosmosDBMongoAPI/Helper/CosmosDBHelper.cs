using CosmosDBMongoAPI.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDBMongoAPI.Helper
{
    
    public class CosmosDBHelper
    {
        private string databaseName;
        private string collectionName;
        private MongoClient client;
        private IMongoDatabase database;

        public CosmosDBHelper(string connectionString,string databaseName,string collectionName)
        {
            this.databaseName = databaseName;
            this.collectionName = collectionName;
            this.client = new MongoClient(connectionString);
            this.database = client.GetDatabase(databaseName);
        }

        public IMongoDatabase Database => database;

        public IMongoCollection<Cars> cars => database.GetCollection<Cars>(collectionName);

        public async void InsertCarAsync(Cars car)
        {
            await this.cars.InsertOneAsync(car);
        }

        public IEnumerable<Cars> GetCars()
        {
            var items = this.cars.Find<Cars>(p => true);
            return items.ToEnumerable<Cars>();
        }

    }
}
