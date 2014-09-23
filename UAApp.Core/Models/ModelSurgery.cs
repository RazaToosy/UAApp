using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;
using UAApp.Core.Interfaces;

namespace UAApp.Core.Models 
{
    public class ModelSurgery
    {
        public int ModelPatientId { get; set; }
        public virtual ModelPatient ModelPatient { get; set; }

        public int ModelSurgeryId { get; set; }

        [CsvColumn(Name = "Organisation Code", FieldIndex = 1)]
        public string OrganisationCode { get; set; }

        [CsvColumn(Name = "Organisation Name", FieldIndex = 2)]
        public string OrganisationName { get; set; }

        [CsvColumn(Name = "Main Contact", FieldIndex = 3)]
        public string MainContact { get; set; }

        [CsvColumn(Name = "Address", FieldIndex = 4)]
        public string Address { get; set; }

        [CsvColumn(Name = "Surgery Email", FieldIndex = 5)]
        public string SurgeryEmail { get; set; }
    }
}
