using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.Enumerations;
namespace HealthcareSystem.Entity.User
{
    class User
    {
        public ObjectId _id{get;set;}
        [BsonElement("name")]
        public string name{get;set;}
        [BsonElement("lastName")]
        public string lastName {get; set;}
        [BsonElement("email")]
        public string email {get; set;}
        [BsonElement("password")]
        public string password {get; set;}
        [BsonElement("role")]
        public Role role {get; set;}

        public User(string name, string lastName, string email, string password, Role role){
                this._id = this._id = ObjectId.GenerateNewId();
                this.name = name;
                this.lastName = lastName;
                this.email = email;
                this.password = password;
                this.role = role;
            }
    }


}