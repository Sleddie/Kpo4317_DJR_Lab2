﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpo4317_DJR.Lib
{
    public class SemiconductorSplitFileFactory : ISemiconductorFactory
    {
        public ISemiconductorListLoader CreateSemiconductorListLoader()
        {
            return new SemiconductorListSplitFileLoader();
        }
    }
}
