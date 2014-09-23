using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;
using UAApp.Core.Interfaces;

namespace UAApp.Core.Models
{
    public class ModelSollisEntry
    {
        public int ModelPatientId { get; set; }
        public virtual ModelPatient ModelPatient { get; set; }

        public int ModelSolisEntityId { get; set; }

         [CsvColumn(FieldIndex = 1)]
        public string UsualGPCode { get; set; }
         [CsvColumn(FieldIndex = 2)]
         public string NHSNumber { get; set; }
         [CsvColumn(FieldIndex = 3)]
        public int LocalPatientID2 { get; set; }
         [CsvColumn(FieldIndex = 4)]
        public int Age { get; set; }
         [CsvColumn(FieldIndex = 5)]
        public string GenderShort { get; set; }
         [CsvColumn(FieldIndex = 6)]
        public double ProbabilityInjuryHospitalisation { get; set; }
         [CsvColumn(FieldIndex = 7)]
        public string RubGroup { get; set; }
         [CsvColumn(FieldIndex = 8)]
        public int ChronicConditionCount { get; set; }
    }
}
