using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAApp.Core.Enums;
using UAApp.Core.Interfaces;

namespace UAApp.Core.Models.Queries
{
    public class ModelLastMonthAttendances
    {
        public string Notes { get; set; }
        public string OrganisationName { get; set; }
        public int EmisNo { get; set; }
        public string UsualGP { get; set; }
        public string NHSNo { get; set; }
        public string Title { get; set; }
        public string FamilyName { get; set; }
        public string CallingName { get; set; }
        public DateTime DateOfArrival { get; set; }
        public string TimeOfArrival { get; set; }
        public string ArrivalMode { get; set; }
        public string PresentedWith { get; set; }
        public string DiagnosisDescription { get; set; }
        public DischargeCodes AttendanceDisposal { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string HouseNameFlatNumber { get; set; }
        public string NumberAndStreet { get; set; }
        public string Locality { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string HomeTelephone { get; set; }
        public string MobileTelephone { get; set; }
        public string WorkTelephone { get; set; }
    }
}
