using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Application.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public class SignUpDto
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
        }
    }
}