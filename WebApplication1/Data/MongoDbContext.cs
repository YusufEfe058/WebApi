using MongoDB.Driver;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("OkulDb");
        }

        public IMongoCollection<Student> Students => _database.GetCollection<Student>("Öğrenciler");
        public IMongoCollection<Course> Courses => _database.GetCollection<Course>("Dersler");
    }
}
