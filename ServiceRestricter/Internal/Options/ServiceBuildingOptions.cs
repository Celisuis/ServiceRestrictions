using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceRestricter.Internal.Options
{
    public class ServiceBuildingOptions
    {
        public List<byte> CoveredDistricts;

        public bool RestrictEmptying;

        public ServiceBuildingOptions()
        {
            CoveredDistricts = new List<byte>();
            RestrictEmptying = false;
        }
    }
}
