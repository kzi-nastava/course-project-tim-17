using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.Survey.DoctorSurvey;
using HealthcareSystem.Entity.Survey.HospitalSurvey;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.Survey
{
    internal class SurveyService

    {

        public IDoctorSurveysRepository doctorSurveyRepository;
        public IHospitalSurveysRepository hospitalSurveyRepository;
        public IDoctorRepository doctorRepository;
        public SurveyService(IDoctorSurveysRepository doctorSurveyRepository, IHospitalSurveysRepository hospitalSurveyRepository, IDoctorRepository doctorRepository)
        {
            this.doctorSurveyRepository = doctorSurveyRepository;
            this.hospitalSurveyRepository = hospitalSurveyRepository;
            this.doctorRepository = doctorRepository;

        }

        public List<HospitalSurveys> GetAllHospitalSurveys()
        { 
            return hospitalSurveyRepository.GetAll(); 
        }

        public double MarkToDouble(Mark mark)
        {
            if (mark == Mark.ONE) return 1;
            if (mark == Mark.TWO) return 2;
            if (mark == Mark.THREE) return 3;
            if (mark == Mark.FOUR) return 4;
            if (mark == Mark.FIVE) return 5;
            return 0;
        }

        public List<DoctorSurveys> GetAllDoctorSurveys()
        {
            return doctorSurveyRepository.GetAll();
        }
        public List<DoctorSurveysAverages> GetAllDoctorSurveysAverages()
        {
            List<DoctorSurveysAverages> doctorSurveysAverages = new List<DoctorSurveysAverages>();
            foreach(Doctor doctor in doctorRepository.GetAll())
            {
                doctorSurveysAverages.Add(GetDoctorSurveyAverages(doctor));
            }
            return doctorSurveysAverages;
        }

        public void InsertDoctorSurvey(DoctorSurveys doctorSurvey)
        {
            doctorSurveyRepository.Insert(doctorSurvey);
        }

        public void InsertHospitalSurvey(HospitalSurveys hospitalSurvey)
        {
            hospitalSurveyRepository.Insert(hospitalSurvey);
        }

        public DoctorSurveysAverages GetDoctorSurveyAverages(Doctor doctor)
        {
            DoctorSurveysAverages doctorSurveyAverages = new DoctorSurveysAverages();
            doctorSurveyAverages.DoctorName = doctor.name;
            doctorSurveyAverages.DoctorSurname = doctor.lastName;
            foreach (DoctorSurveys doctorSurvey in GetAllDoctorSurveys()) 
            {
                if (doctorSurvey.doctorId == doctor._id)
                {
                    doctorSurveyAverages.comments.Add(doctorSurvey.comment);
                    doctorSurveyAverages.AverageQuality += MarkToDouble(doctorSurvey.quality);
                    doctorSurveyAverages.marksForQuality.Add(MarkToDouble(doctorSurvey.quality));
                    doctorSurveyAverages.AverageReccomendation += MarkToDouble(doctorSurvey.recommendation);
                    doctorSurveyAverages.marksForReccomendation.Add(MarkToDouble(doctorSurvey.recommendation));

                }
            }
            if (GetAllDoctorSurveys().Count > 0)
            {
                doctorSurveyAverages.AverageQuality = doctorSurveyAverages.AverageQuality / GetAllDoctorSurveys().Count;
                doctorSurveyAverages.AverageReccomendation = doctorSurveyAverages.AverageReccomendation / GetAllDoctorSurveys().Count;
            }

            return doctorSurveyAverages;
            
        }
        public HospitalSurveysAverages GetHospitalSurveysAverages()
        {
            HospitalSurveysAverages hospitalSurverAverages = new HospitalSurveysAverages();
            foreach (HospitalSurveys hospitalSurvey in GetAllHospitalSurveys())
            {
                hospitalSurverAverages.AverageQuality += MarkToDouble(hospitalSurvey.quality);
                hospitalSurverAverages.marksForQuality.Add(MarkToDouble(hospitalSurvey.quality));
                hospitalSurverAverages.AverageCleanliness += MarkToDouble(hospitalSurvey.cleanliness);
                hospitalSurverAverages.marksForCleanliness.Add(MarkToDouble(hospitalSurvey.cleanliness));
                hospitalSurverAverages.AverageSatisfaction += MarkToDouble(hospitalSurvey.satisfaction);
                hospitalSurverAverages.marksForSatisfaction.Add(MarkToDouble(hospitalSurvey.satisfaction));
            }
            if (GetAllDoctorSurveys().Count > 0)
            {
                hospitalSurverAverages.AverageQuality = hospitalSurverAverages.AverageQuality / GetAllDoctorSurveys().Count;
                hospitalSurverAverages.AverageCleanliness = hospitalSurverAverages.AverageCleanliness / GetAllDoctorSurveys().Count;
                hospitalSurverAverages.AverageSatisfaction = hospitalSurverAverages.AverageSatisfaction / GetAllDoctorSurveys().Count;

            }

            return hospitalSurverAverages;

        }

        public double[] GetNumberOfMarks(List<double> marks)
        {
            double[] eachMark = new double[5];
            foreach (double mark in marks)
            {
                eachMark[(int)mark-1] += 1 ;
            }
            return eachMark;

        }
    }
}
