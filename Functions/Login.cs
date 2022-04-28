
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.DoctorModel;
using MongoDB.Driver;
namespace HealthcareSystem.Functions;

static class Login {
    public static User validate(IMongoDatabase db,string email,string password) {
        var userCollection = db.GetCollection<User>("Users");
        var doctorCardCollection = db.GetCollection<Doctor>("Doctors");
        UserController uc = new UserController(db);
        DoctorController dc = new DoctorController(db);


        User loggedUser = uc.checkCredentials(email, password);
        BlockedUserController blockedUserController = new BlockedUserController(db);


        if (loggedUser == null)
        {
            loggedUser = (User)dc.checkCredentials(email, password);
        }
        if (loggedUser != null) {
            if (blockedUserController.checkIfBlocked(loggedUser._id) != null) {
                Console.WriteLine("Sorry, you are blocked!B)");
                return null;
            }
        }
        return loggedUser;


    }

}