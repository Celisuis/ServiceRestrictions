using System.Text.RegularExpressions;
using ColossalFramework;
using UnityEngine;

namespace ServiceRestrictions.Helpers
{
    public class BuildingHelper
    {
        public static void MoveRequest(ushort buildingID, ref Building data, TransferManager.TransferReason reason,
            TransferManager.TransferOffer offer)
        {

            Debug.Log($"Move Requested from {DistrictManager.instance.GetDistrictName(DistrictManager.instance.GetDistrict(BuildingManager.instance.m_buildings.m_buffer[buildingID].m_position))}");
            var buildingType = data.Info.m_buildingAI.GetType().BaseType;

            FastList<ushort> buildings = BuildingManager.instance.GetServiceBuildings(data.Info.GetService());

            if (buildings == null)
                return;

            bool moveRequest = (reason == TransferManager.TransferReason.Fire ||
                               reason == TransferManager.TransferReason.Crime ||
                               reason == TransferManager.TransferReason.Dead ||
                               reason == TransferManager.TransferReason.Fire2 ||
                               reason == TransferManager.TransferReason.Garbage
                               || reason == TransferManager.TransferReason.RoadMaintenance ||
                               reason == TransferManager.TransferReason.Snow ||
                               reason == TransferManager.TransferReason.Sick ||
                               reason == TransferManager.TransferReason.Sick2 ||
                               reason == TransferManager.TransferReason.Taxi ||
                               reason == TransferManager.TransferReason.OutgoingMail ||
                               reason == TransferManager.TransferReason.SortedMail ||
                               reason == TransferManager.TransferReason.Mail ||
                               reason == TransferManager.TransferReason.FloodWater);

            for (ushort x = 0; x < buildings.m_size; x++)
            {
                ushort targetBuildingId = buildings.m_buffer[x];

                if (targetBuildingId == buildingID)
                    continue;

                var targetBuilding = BuildingManager.instance.m_buildings.m_buffer[targetBuildingId];

                if (!targetBuilding.m_flags.IsFlagSet(Building.Flags.Created) ||
                    targetBuilding.m_problems.IsFlagSet(Notification.Problem.Emptying) ||
                    targetBuilding.m_problems.IsFlagSet(Notification.Problem.EmptyingFinished))
                    continue;

                if (!buildingType.IsInstanceOfType(targetBuilding.Info.m_buildingAI))
                    continue;

                if (targetBuilding.Info.m_buildingAI.IsFull(targetBuildingId, ref targetBuilding))
                    continue;

                if (moveRequest && !SpareVehicles(buildingID, ref data))
                    continue;

                if (moveRequest)
                {
                    if (DistrictHelper.CanTransfer(targetBuildingId, reason, offer))
                        targetBuilding.Info.m_buildingAI.StartTransfer(targetBuildingId, ref targetBuilding, reason,
                            offer);
                }
                else
                {
                    offer.Building = targetBuildingId;
                    offer.Position = targetBuilding.m_position;

                    if (DistrictHelper.CanTransfer(buildingID, reason, offer))
                        data.Info.m_buildingAI.StartTransfer(buildingID, ref data, reason, offer);
                }
            }
        }

        private static bool SpareVehicles(ushort buildingID, ref Building data)
        {
            string stats = data.Info.m_buildingAI.GetLocalizedStats(buildingID, ref data);

            if (string.IsNullOrEmpty(stats))
                return false;

            string lastIndex = stats.Substring(stats.LastIndexOf(':') + 2);

            Match match = new Regex(@"(\d+)\D+(\d+)").Match(stats);

            if (match.Success)
            {
                var usedVehicles = int.Parse(match.Groups[1].Value);
                var availableVehicles = int.Parse(match.Groups[2].Value);

                return usedVehicles < availableVehicles;
            }

            return false;
        }
    }
}