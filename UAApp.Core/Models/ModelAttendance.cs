using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAApp.Core.Interfaces;

namespace UAApp.Core.Models
{
    public class ModelAttendance
    {
        public int ModelPatientId { get; set; }
        public virtual ModelPatient ModelPatient { get; set; }

        public int? ModelAttendanceId { get; set; }
        public string AandEDepartment { get; set; }
        public string AandEDepartementName { get; set; }
        public string AandEUniqueId { get; set; }
        public string PasId { get; set; }
        public string PatientName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNo { get; set; }
        public string NHSNo { get; set; }
        public string GPCode { get; set; }
        public string OrganisationCode { get; set; }
        public string OrgainsationName { get; set; }
        public DateTime? DateOfArrival { get; set; }
        public string TimeOfArrival { get; set; }
        public string SourceOfReferralCode { get; set; }
        public string ArrivalMode { get; set; }
        public string PresentedWith { get; set; }
        public string DiagnosisCode { get; set; }
        public string DiagnosisDescription { get; set; }
        public string InvestigationCodeOne { get; set; }
        public string InvestigationCodeTwo { get; set; }
        public string TreatmentCodeOne { get; set; }
        public string TreatmentCodeTwo { get; set; }
        public string TreatmentCodeThree { get; set; }
        public string HRG { get; set; }
        public string AttendanceDisposal { get; set; }
    }
}
