using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceRestricter.Internal.Options
{
    public class ServiceBuildingOptions
    {
        public List<byte> CoveredDistricts = new List<byte>();

        public bool RestrictEmptying;
    }
}
