using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAApp.Core.Enums
{
    public enum DischargeCodes
    {
        Admitted = 1,
        Discharged_FU_to_GP = 2,
        Discharged_No_FU_Required = 3,
        Referred_To_AE_Clinic = 4,
        Referred_To_Fracture_Care = 5,
        Referred_To_Other_OPD = 6,
        Transfer_To_Other_HCP = 7,
        Died_In_Department = 10,
        Referred_To_Other_HCP = 11,
        Left_Departement_Before_Treatment = 12,
        Left_Department_Refusing_Treatment = 13,
        Other = 14
    }
}
