using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAApp.Core.Interfaces;

namespace UAApp.Core.Models
{
    public class ModelDischarge
    {
        public int ModelPatientId { get; set; }
        public virtual ModelPatient ModelPatient { get; set; }

        public int ModelDischargeId { get; set; }
        public string EpisodeId { get; set; }
        public string OrganisationCode { get; set; }
        public string OrganisationName { get; set; }
        public string PBCConsortiaName { get; set; }
        public string TypeOfAdmission { get; set; }
        public string DischargeWardCode { get; set; }
        public string DischargeWard { get; set; }
        public string DischargeHospitalSite { get; set; }
        public string DischargeSpeciality { get; set; }
        public string NHSNo { get; set; }
        public string PASHospitalNumber { get; set; }
        public string PatientName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public string DishDeceasedFlag { get; set; }
    }
}
