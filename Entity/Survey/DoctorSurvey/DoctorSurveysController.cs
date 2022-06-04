using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.Survey.DoctorSurvey
{
    class DoctorSurveysController
    {
        public IMongoCollection<DoctorSurveys> doctorSurveysCollection;

        public DoctorSurveysController(IMongoDatabase database)
        {
            this.doctorSurveysCollection = database.GetCollection<DoctorSurveys>("DoctorSurveys");
        }

        public void insertToCollection(DoctorSurveys doctorSurveys)
        {
            doctorSurveysCollection.InsertOne(doctorSurveys);
        }

        public List<DoctorSurveys> getAllSurveys()
        {
            return doctorSurveysCollection.Find(item => true).ToList();
        }
    }
}