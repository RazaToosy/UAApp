using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAApp.Core.Interfaces;

namespace UAApp.Core.Models.Queries
{
    public class ModelLastMonthsDischarges
    {
        public string Notes { get; set; }
        public string OrganisationName { get; set; }
        public int EmisNo { get; set; }
        public string UsualGP { get; set; }
        public string NHSNo { get; set; }
        public string Title { get; set; }
        public string FamilyName { get; set; }
        public string CallingName { get; set; }
        public string TypeOfAdmission { get; set; }
        public string DischargeWard { get; set; }
        public string DischargeSpeciality { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public string DishDeceasedFlag { get; set; }
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
