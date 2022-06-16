using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.UserModel
{
    internal interface IUserRepository : IRepository<User>
    {
        public User GetByEmail(string email);
        public User CheckCredentials(string email, string password);

        public List<User> GetAllPatients();
    }
}
