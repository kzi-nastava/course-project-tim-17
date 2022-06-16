using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.DoctorModel
{
    internal interface IDoctorRepository : IRepository<Doctor>
    {
        List<Doctor> FindDoctorsBySpecialisation(Specialisation s);
        Doctor checkCredentials(string email, string password);
        Doctor GetByNameAndLastName(string name, string lastname);
        Doctor GetById(ObjectId id);
    }
}
