using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAApp.Core.Enums;
using UAApp.Core.Interfaces;
using UAApp.Core.Models.Queries;

namespace UAApp.Infrastructure.Queries
{
    public class DischargesIntheLastMonth
    {
        public IList<ModelLastMonthsDischarges> ReturnDischargesInLastMonth(IContext Context, String OrganisationCode)
        {
            var discharges = (from d in Context.Discharges
                              join p in Context.Patients
                                  on d.NHSNo equals p.NHSNo
                              where d.DischargeDate > DateTime.Now.AddDays(-34)
                              where p.OrganisationCode == OrganisationCode
                              select new ModelLastMonthsDischarges
                              {
                                  Age = p.Age.GetValueOrDefault(),
                                  CallingName = p.CallingName,
                                  County = p.County,
                                  DateOfBirth = p.DateOfBirth.GetValueOrDefault(),
                                  EmisNo = p.EmisNo.GetValueOrDefault(),
                                  FamilyName = p.FamilyName,
                                  Gender = p.Gender,
                                  HomeTelephone = p.HomeTelephone,
                                  HouseNameFlatNumber = p.HouseNameFlatNumber,
                                  Locality = p.Locality,
                                  MobileTelephone = p.MobileTelephone,
                                  NHSNo = p.NHSNo,
                                  Notes = string.Empty,
                                  NumberAndStreet = p.NumberAndStreet,
                                  OrganisationName = p.OrganisationName,
                                  PostCode = p.PostCode,
                                  Title = p.Title,
                                  Town = p.Town,
                                  UsualGP = p.UsualGP,
                                  WorkTelephone = p.WorkTelephone,
                                  AdmissionDate = d.AdmissionDate,
                                  DischargeDate = d.DischargeDate,
                                  DischargeSpeciality = d.DischargeSpeciality,
                                  DischargeWard = d.DischargeWard,
                                  DishDeceasedFlag = d.DishDeceasedFlag, 
                                  TypeOfAdmission = d.TypeOfAdmission
                              }).ToList();

            return discharges;
        }
    }
}
