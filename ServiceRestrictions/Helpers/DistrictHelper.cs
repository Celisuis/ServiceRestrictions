using System.Collections.Generic;
using ColossalFramework;
using ServiceRestrictions.Internal;
using UnityEngine;

namespace ServiceRestrictions.Helpers
{
    public class DistrictHelper
    {
        public static List<string> RetrieveAllDistrictNames()
        {
            List<string> districtNamesList = new List<string>();

            for (byte x = 1; x < DistrictManager.instance.m_districts.m_buffer.Length; x++)
            {
                if (!DistrictManager.instance.m_districts.m_buffer[x].m_flags.IsFlagSet(District.Flags.Created))
                    continue;


                districtNamesList.Add(DistrictManager.instance.GetDistrictName(x));
            }

            districtNamesList.Add("Areas without a district.");
            return districtNamesList;
        }

        public static List<string> RetrieveAllParkNames()
        {
            List<string> parkNames = new List<string>();

            for (byte x = 0; x < DistrictManager.instance.m_parks.m_buffer.Length; x++)
            {
                if (!DistrictManager.instance.m_parks.m_buffer[x].m_flags.IsFlagSet(DistrictPark.Flags.Created))
                    continue;

                if (DistrictManager.instance.m_parks.m_buffer[x].IsPark)
                    parkNames.Add(DistrictManager.instance.GetParkName(x));
            }

            return parkNames;
        }

        public static List<string> RetrieveAllIndustryNames()
        {
            List<string> industryNames = new List<string>();

            for (byte x = 0; x < DistrictManager.instance.m_parks.m_buffer.Length; x++)
            {
                if (!DistrictManager.instance.m_parks.m_buffer[x].m_flags.IsFlagSet(DistrictPark.Flags.Created))
                    continue;

                if (DistrictManager.instance.m_parks.m_buffer[x].IsIndustry)
                    industryNames.Add(DistrictManager.instance.GetParkName(x));
            }

            return industryNames;
        }


        public static List<string> RetrieveAllCampusNames()
        {
            List<string> campusNames = new List<string>();

            for (byte x = 0; x < DistrictManager.instance.m_parks.m_buffer.Length; x++)
            {
                if (!DistrictManager.instance.m_parks.m_buffer[x].m_flags.IsFlagSet(DistrictPark.Flags.Created))
                    continue;

                if (DistrictManager.instance.m_parks.m_buffer[x].IsCampus)
                    campusNames.Add(DistrictManager.instance.GetParkName(x));
            }

            return campusNames;
        }

        public static byte RetrieveDistrictIDFromName(string name)
        {
            for (byte x = 1; x < DistrictManager.instance.m_districts.m_buffer.Length; x++)
            {
                if (!DistrictManager.instance.m_districts.m_buffer[x].m_flags.IsFlagSet(District.Flags.Created))
                    continue;

                if (DistrictManager.instance.GetDistrictName(x) != name)
                    continue;

                return x;

            }


            return 0;
        }

        public static byte RetrieveParkIDFromName(string name)
        {
            for (byte x = 0; x < DistrictManager.instance.m_parks.m_buffer.Length; x++)
            {
                if (!DistrictManager.instance.m_parks.m_buffer[x].m_flags.IsFlagSet(DistrictPark.Flags.Created))
                    continue;

                if (DistrictManager.instance.GetParkName(x) == name)
                    return x;
            }

            return 0;
        }



        public static bool CanTransfer(ushort sourceBuildingID, TransferManager.TransferReason reason,
            TransferManager.TransferOffer offer)
        {
            bool canTransfer;

            Debug.Log($"{BuildingManager.instance.GetBuildingName(sourceBuildingID, InstanceID.Empty)} has requested a transfer check.");

            ushort targetBuildingID = offer.Building;

            var sourceBuilding = BuildingManager.instance.m_buildings.m_buffer[sourceBuildingID];

            var targetBuilding = BuildingManager.instance.m_buildings.m_buffer[targetBuildingID];

            if (offer.Building == 0 && offer.Citizen != 0)
            {
                targetBuildingID = CitizenManager.instance.m_citizens.m_buffer[offer.Citizen].GetBuildingByLocation();
                targetBuilding = BuildingManager.instance.m_buildings.m_buffer[targetBuildingID];

                if (targetBuildingID == 0)
                {
                    targetBuilding.m_position = CitizenManager.instance.m_instances
                        .m_buffer[CitizenManager.instance.m_citizens.m_buffer[offer.Citizen].m_instance]
                        .GetLastFramePosition();
                }
            }

            byte sourceBuildingDistrict = DistrictManager.instance.GetDistrict(sourceBuilding.m_position);
            byte targetBuildingDistrict = DistrictManager.instance.GetDistrict(targetBuilding.m_position);

            if (targetBuildingDistrict == 0)
                targetBuildingDistrict = DistrictManager.instance.GetPark(targetBuilding.m_position);


            if (targetBuildingDistrict == 0)
            {
                Debug.Log($"Target District does not exist. Returning true.");
                return true;
            }
            Debug.Log($"Found Target District ID: {targetBuildingDistrict}");

            Debug.Log($"{BuildingManager.instance.GetBuildingName(sourceBuildingID, InstanceID.Empty)} has requested a transfer with {DistrictManager.instance.GetDistrictName(DistrictManager.instance.GetDistrict(targetBuilding.m_position))}.");

            if (!ServiceRestrictTool.instance.CustomServiceBuildingOptions.TryGetValue(sourceBuildingID,
                out var options))
            {
                Debug.Log($"{BuildingManager.instance.GetBuildingName(sourceBuildingID, InstanceID.Empty)} has no options. Returning true.");
                return true;
            }

            if (options.CoveredDistricts.Count <= 0 && options.CoveredParks.Count <= 0)
            {
                Debug.Log($"{BuildingManager.instance.GetBuildingName(sourceBuildingID, InstanceID.Empty)} has no restrictions. Returning true.");
                return true;
            }

            if (options.Inverted)
            {
                Debug.Log($"{BuildingManager.instance.GetBuildingName(sourceBuildingID, InstanceID.Empty)}'S options are inverted.");
                return !options.CoveredDistricts.Contains(targetBuildingDistrict) || !options.CoveredParks.Contains(targetBuildingDistrict);
            }
           

            switch (reason)
            {
                case TransferManager.TransferReason.Garbage:
                case TransferManager.TransferReason.Crime:
                case TransferManager.TransferReason.Sick:
                case TransferManager.TransferReason.Sick2:
                case TransferManager.TransferReason.Dead:
                case TransferManager.TransferReason.Fire:
                case TransferManager.TransferReason.Fire2:
                case TransferManager.TransferReason.Taxi:
                case TransferManager.TransferReason.Snow:
                case TransferManager.TransferReason.RoadMaintenance:
                case TransferManager.TransferReason.OutgoingMail:
                case TransferManager.TransferReason.SortedMail:
                case TransferManager.TransferReason.Mail:
                case TransferManager.TransferReason.FloodWater:
                    canTransfer =  targetBuildingDistrict == 0 || targetBuildingDistrict == sourceBuildingDistrict ||
                           options.CoveredDistricts.Contains(targetBuildingDistrict) || options.CoveredParks.Contains(targetBuildingDistrict);
                    break;
                case TransferManager.TransferReason.DeadMove:
                case TransferManager.TransferReason.GarbageMove:
                case TransferManager.TransferReason.SnowMove:
                case TransferManager.TransferReason.CriminalMove:
                case TransferManager.TransferReason.SickMove:
                    canTransfer =  !options.RestrictEmptying || targetBuildingDistrict == 0 ||
                           targetBuildingDistrict == sourceBuildingDistrict ||
                           options.CoveredDistricts.Contains(targetBuildingDistrict) || options.CoveredParks.Contains(targetBuildingDistrict);
                    break;
                default:
                    canTransfer =  true;
                    break;
            }

            Debug.Log($"{BuildingManager.instance.GetBuildingName(sourceBuildingID, InstanceID.Empty)}'s transfer request has returned: {canTransfer}");
            return canTransfer;
        }


       
    }
}