using MongoDB.Driver;
using Application.Model;

namespace Application.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var mongoSettings = configuration.GetSection("MongoSettings");
            var connectionString = mongoSettings["mongodb+srv://Karan:Raj@karan.qeepb.mongodb.net/"];
            var databaseName = mongoSettings["KGRestaurent"];

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Menu> Menus => _database.GetCollection<Menu>(nameof(Menu));
        public IMongoCollection<Order> Orders => _database.GetCollection<Order>(nameof(Order));
        public IMongoCollection<User> User => _database.GetCollection<User>(nameof(User));
        public IMongoCollection<Review> Reviews => _database.GetCollection<Review>(nameof(Review));
    }
}
