using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.DoctorModel
{
    internal class DoctorService
    {
        public IDoctorRepository doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public void Insert(Doctor doctor)
        {
            doctorRepository.Insert(doctor);
        }
        public void Delete(Doctor doctor)
        {
            doctorRepository.Delete(doctor._id);
        }
        public void Update(Doctor doctor)
        {
            doctorRepository.Update(doctor);
        }
        public Doctor GetByNameAndLastName(string name, string lastname)
        {
            return doctorRepository.GetByNameAndLastName(name, lastname);
        }
        public List<Doctor> GetAll ()
        {
            return doctorRepository.GetAll();
        }
        public Doctor GetById(ObjectId id)
        {
            return doctorRepository.GetById(id);
        }
        public List<Doctor> GetBySpecialisation(Specialisation specialisation)
        {
            return doctorRepository.FindDoctorsBySpecialisation(specialisation);
        }
        public Doctor CheckCredentials(string email, string password)
        {
            return doctorRepository.checkCredentials(email, password);
        }

    }

}
