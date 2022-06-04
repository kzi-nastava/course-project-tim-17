using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.Survey.HospitalSurvey
{
    class HospitalSurveysController
    {
        public IMongoCollection<HospitalSurveys> hospitalSurveysCollection;

        public HospitalSurveysController(IMongoDatabase database)
        {
            this.hospitalSurveysCollection = database.GetCollection<HospitalSurveys>("DoctorSurveys");
        }

        public void insertToCollection(HospitalSurveys doctorSurveys)
        {
            hospitalSurveysCollection.InsertOne(doctorSurveys);
        }

        public List<HospitalSurveys> getAllSurveys()
        {
            return hospitalSurveysCollection.Find(item => true).ToList();
        }
    }
}
