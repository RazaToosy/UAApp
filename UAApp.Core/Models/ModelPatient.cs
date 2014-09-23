using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;
using UAApp.Core.Interfaces;

namespace UAApp.Core.Models
{
    public class ModelPatient
    {
        public int ModelPatientId { get; set; }

        [CsvColumn(Name = "EMIS Number", FieldIndex = 1)]
        public int? EmisNo { get; set; }

        [CsvColumn(Name = "Organisation Code", FieldIndex = 2)]
        public string OrganisationCode { get; set; }

        [CsvColumn(Name = "Organisation Name", FieldIndex = 3)]
        public string OrganisationName { get; set; }

        [CsvColumn(Name = "Usual GP's Full Name", FieldIndex = 4)]
        public string UsualGP { get; set; }

        [CsvColumn(Name = "NHS Number", FieldIndex = 5)]
        public string NHSNo { get; set; }

        [CsvColumn(Name = "Title", FieldIndex = 6)]
        public string Title { get; set; }

        [CsvColumn(Name = "Family Name", FieldIndex = 7)]
        public string FamilyName { get; set; }

        [CsvColumn(Name = "Calling Name", FieldIndex = 8)]
        public string CallingName { get; set; }

        [CsvColumn(Name = "Age", FieldIndex = 9)]
        public int? Age { get; set; }

        [CsvColumn(Name = "Date of Birth", FieldIndex = 10)]
        public DateTime? DateOfBirth { get; set; }

        [CsvColumn(Name = "Gender", FieldIndex = 11)]
        public string Gender { get; set; }

        [CsvColumn(Name = "House Name / Flat Number", FieldIndex = 12)]
        public string HouseNameFlatNumber { get; set; }

        [CsvColumn(Name = "Number and Street", FieldIndex = 13)]
        public string NumberAndStreet { get; set; }

        [CsvColumn(Name = "Locality", FieldIndex = 14)]
        public string Locality { get; set; }

        [CsvColumn(Name = "Town", FieldIndex = 15)]
        public string Town { get; set; }

        [CsvColumn(Name ="County", FieldIndex = 16)]
        public string County { get; set; }

        [CsvColumn(Name = "Postcode", FieldIndex = 17)]
        public string PostCode { get; set; }

        [CsvColumn(Name = "Home Telephone", FieldIndex = 18)]
        public string HomeTelephone { get; set; }

        [CsvColumn(Name = "Mobile Telephone", FieldIndex = 19)]
        public string MobileTelephone { get; set; }

        [CsvColumn(Name = "Work Telephone", FieldIndex = 20)]
        public string WorkTelephone { get; set; }

        [CsvColumn(Name = "E-mail Address", FieldIndex = 21)]
        public string EmailAddress { get; set; }

        public virtual List<ModelAttendance> ModelAttendances { get; set; }
        public virtual List<ModelDischarge> ModelDischarges { get; set; }
        public virtual List<ModelSurgery> ModelSurgeries { get; set; }
        public virtual List<ModelSollisEntry> ModelSollisEntries { get; set; }

    }
}
