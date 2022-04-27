using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.User;
namespace HealthcareSystem.Entity.Doctor
{
    class Doctor : User.User
    {
        [BsonElement("specialisation")]
        public Specialisation specialisation{ get; set; }

        public Doctor(string name, string lastName, string email, string password, Role role, Specialisation specialisation) : base(name, lastName, email, password, role){
                
                this.specialisation = specialisation;
            }

    }
}