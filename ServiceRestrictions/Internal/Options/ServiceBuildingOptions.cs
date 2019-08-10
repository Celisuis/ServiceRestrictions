using System;
using System.Collections.Generic;

namespace ServiceRestrictions.Internal.Options
{
    [Serializable]
    public class ServiceBuildingOptions
    {
        public List<byte> CoveredDistricts;

        public List<byte> CoveredParks;

        public bool RestrictToSelf;

        public bool RestrictEmptying;

        public bool Inverted;

        public ServiceBuildingOptions()
        {
            CoveredDistricts = new List<byte>();
            CoveredParks = new List<byte>();
            RestrictEmptying = false;
            Inverted = false;
        }
    }
}