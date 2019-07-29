using Harmony;
using ServiceRestrictions.Helpers;

namespace ServiceRestrictions.Patches
{
    [HarmonyPatch(typeof(TransferManager), "StartTransfer")]
    public static class TransferManagerPatch
    {
        public static bool Prefix(TransferManager.TransferReason material, TransferManager.TransferOffer offerOut,
            TransferManager.TransferOffer offerIn, int delta)
        {
            bool active = offerIn.Active;
            bool active2 = offerOut.Active;

            if (active2 && offerIn.Vehicle != 0)
            {
                if (VehicleManager.instance.m_vehicles.m_buffer[offerIn.Vehicle].Info.m_vehicleAI.GetType() == typeof(CargoPlaneAI) || VehicleManager.instance.m_vehicles.m_buffer[offerIn.Vehicle].Info.m_vehicleAI.GetType() == typeof(CargoShipAI) ||
                VehicleManager.instance.m_vehicles.m_buffer[offerIn.Vehicle].Info.m_vehicleAI.GetType() == typeof(CargoTrainAI) || VehicleManager.instance.m_vehicles.m_buffer[offerIn.Vehicle].Info.m_vehicleAI.GetType() == typeof(CargoTruckAI))
                    return true;

                offerOut.Amount = delta;

                return DistrictHelper.CanTransfer(
                    VehicleManager.instance.m_vehicles.m_buffer[offerIn.Vehicle].m_sourceBuilding, material, offerOut);
            }

            if (active2 && offerOut.Vehicle != 0)
            {
                if (VehicleManager.instance.m_vehicles.m_buffer[offerOut.Vehicle].Info.m_vehicleAI.GetType().Name
                    .Contains("Cargo"))
                    return true;

                offerIn.Amount = delta;

                return DistrictHelper.CanTransfer(
                    VehicleManager.instance.m_vehicles.m_buffer[offerOut.Vehicle].m_sourceBuilding, material, offerOut);
            }

            if (active && offerIn.Citizen != 0)
            {
                return true;
            }

            if (active2 && offerOut.Citizen != 0)
            {
                return true;
            }

            if (active2 && offerOut.Building != 0)
            {
                if (BuildingManager.instance.m_buildings.m_buffer[offerOut.Building].Info.m_buildingAI.GetType() ==
                    typeof(WarehouseAI) ||
                    BuildingManager.instance.m_buildings.m_buffer[offerOut.Building].Info.m_buildingAI.GetType() ==
                    typeof(UniqueFactoryAI) ||
                    BuildingManager.instance.m_buildings.m_buffer[offerOut.Building].Info.m_buildingAI.GetType() ==
                    typeof(IndustryBuildingAI) ||
                    BuildingManager.instance.m_buildings.m_buffer[offerOut.Building].Info.m_buildingAI.GetType() ==
                    typeof(ExtractingFacilityAI) || BuildingManager.instance.m_buildings.m_buffer[offerOut.Building].Info.m_buildingAI.GetType().BaseType == typeof(PrivateBuildingAI))
                    return true;

                offerIn.Amount = delta;

                if (DistrictHelper.CanTransfer(offerOut.Building, material, offerIn))
                    return true;
                BuildingHelper.MoveRequest(offerOut.Building,
                    ref BuildingManager.instance.m_buildings.m_buffer[offerOut.Building], material, offerIn);
                return false;
            }

            if (active && offerIn.Building != 0)
            {
                if (BuildingManager.instance.m_buildings.m_buffer[offerIn.Building].Info.m_buildingAI.GetType() ==
                    typeof(WarehouseAI) ||
                    BuildingManager.instance.m_buildings.m_buffer[offerIn.Building].Info.m_buildingAI.GetType() ==
                    typeof(UniqueFactoryAI) ||
                    BuildingManager.instance.m_buildings.m_buffer[offerIn.Building].Info.m_buildingAI.GetType() ==
                    typeof(IndustryBuildingAI) ||
                    BuildingManager.instance.m_buildings.m_buffer[offerIn.Building].Info.m_buildingAI.GetType() ==
                    typeof(ExtractingFacilityAI) || BuildingManager.instance.m_buildings.m_buffer[offerIn.Building].Info.m_buildingAI.GetType().BaseType == typeof(PrivateBuildingAI))
                    return true;

                offerOut.Amount = delta;

                if (DistrictHelper.CanTransfer(offerIn.Building, material, offerOut))
                    return true;
                BuildingHelper.MoveRequest(offerIn.Building,
                    ref BuildingManager.instance.m_buildings.m_buffer[offerIn.Building], material, offerOut);
                return false;
            }

            return true;
        }
    }


}
