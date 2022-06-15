using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.Survey.HospitalSurvey
{
    internal class HospitalSurveysAverages
    {
        public double AverageQuality { get; set; }

        public double AverageCleanliness { get; set; }

        public double AverageSatisfaction { get; set; }

        

        public List<double> marksForQuality;

        public List<double> marksForCleanliness;

        public List<double> marksForSatisfaction;

        public HospitalSurveysAverages()
        {
            marksForQuality = new List<double>();
            marksForCleanliness = new List<double>();
            marksForSatisfaction = new List<double>();
            

        }
    }
}
