using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceRestrictions.Internal.Options;

namespace ServiceRestrictions.Internal
{
    public class Clipboard
    {
        public static ServiceBuildingOptions CopiedOptions;

        public static ushort CopiedBuildingID;

        public static void CopyOptions(ServiceBuildingOptions options, ushort buildingID)
        {
            CopiedOptions = new ServiceBuildingOptions
            {
                CoveredDistricts = options.CoveredDistricts,
                Inverted = options.Inverted,
                RestrictEmptying = options.RestrictEmptying,
            };

            CopiedBuildingID = buildingID;
        }

        public static ServiceBuildingOptions PasteOptions()
        {
            if (CopiedOptions == null)
                return new ServiceBuildingOptions();

            var options = new ServiceBuildingOptions
            {
                CoveredDistricts = CopiedOptions.CoveredDistricts,
                Inverted = CopiedOptions.Inverted,
                RestrictEmptying = CopiedOptions.RestrictEmptying
            };

            return options;
        }
    }
}
