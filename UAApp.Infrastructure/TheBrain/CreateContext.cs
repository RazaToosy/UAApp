using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAApp.Core.Interfaces;
using UAApp.Core.Models;
using UAApp.Infrastructure.DataStore;

namespace UAApp.Infrastructure.TheBrain
{
    public class CreateContext
    {
        private IContext _theData;

        public CreateContext(String Source)
        {
            _theData = new InMemoryContext();
            _theData.populateContext(Source);
        }

        public IContext TheData
        {
            get { return _theData; }
            set { _theData = value; }
        }
    }
}
