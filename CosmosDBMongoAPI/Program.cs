using CosmosDBMongoAPI.Helper;
using CosmosDBMongoAPI.Models;
using System;

namespace CosmosDBMongoAPI
{
    class Program
    {
        private static string connectionString = "mongodb://gopi-mongo:@gopi-mongo.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
        private static string databaseName = "eshop";
        private static string collectionName = "cars";

        static void Main(string[] args)
        {
            CosmosDBHelper dbHelper = new CosmosDBHelper(connectionString, databaseName, collectionName);
            Cars car = new Cars
            {
                Name="Qualis",
                Category="Toyota",
                Price=700000,
                Fuel="Diesel"
            };
            dbHelper.InsertCarAsync(car);

            var cars = dbHelper.GetCars();
            foreach(var c in cars)
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10}", c.Name, c.Category, c.Price, c.Fuel);
            }
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
