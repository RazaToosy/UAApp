﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAApp.Core.Interfaces
{
    public interface IImportData<T> where T:class,new()
    {
        IList<T> FetchList(string FileName);
    }
}
