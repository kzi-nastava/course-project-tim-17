using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.Survey.HospitalSurvey
{
    class HospitalSurveysController
    {
        public IMongoCollection<HospitalSurveys> hospitalSurveysCollection;

        public HospitalSurveysController(IMongoDatabase database)
        {
            this.hospitalSurveysCollection = database.GetCollection<HospitalSurveys>("HospitalSurveys");
        }

        public void insertToCollection(HospitalSurveys hospitalSurveys)
        {
            hospitalSurveysCollection.InsertOne(hospitalSurveys);
        }

        public List<HospitalSurveys> getAllSurveys()
        {
            return hospitalSurveysCollection.Find(item => true).ToList();
        }
    }
}
