using System;
using System.Collections.Generic;

namespace ServiceRestrictions.Internal.Options
{
    [Serializable]
    public class ServiceBuildingOptions
    {
        public List<byte> CoveredDistricts;

        public bool RestrictEmptying;

        public bool RestrictToSelf;

        public bool Inverted;

        public ServiceBuildingOptions()
        {
            CoveredDistricts = new List<byte>();
            RestrictEmptying = false;
            RestrictToSelf = false;
            Inverted = false;
        }
    }
}