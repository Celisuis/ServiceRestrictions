﻿using System;
using System.Collections.Generic;

namespace ServiceRestrictions.Internal.Options
{
    [Serializable]
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