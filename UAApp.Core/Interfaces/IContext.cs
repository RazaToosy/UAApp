using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAApp.Core.Models;

namespace UAApp.Core.Interfaces
{
    public interface IContext
    {
        void populateContext(String Source);
        IList<ModelAttendance> Attendances { get; }
        IList<ModelDischarge> Discharges { get; }
        IList<ModelPatient> Patients { get; }
        IList<ModelSollisEntry> SollisEntries { get; }
        IList<ModelSurgery> Surgeries { get; }
    }
}
