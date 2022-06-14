using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.Survey.DoctorSurvey
{
    internal class DoctorSurveysAverages
    {
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public double AverageQuality { get; set; }
        public double AverageReccomendation { get; set; }

        public List<double> marksForQuality;

        public List<double> marksForReccomendation;
        public List<string> comments;

        public DoctorSurveysAverages()
        {
            marksForQuality = new List<double>();
            marksForReccomendation = new List<double>();
            comments = new List<string>();
        }


    }
}
