using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harmony;
using ServiceRestricter.Helpers;

namespace ServiceRestricter.Patches
{
    [HarmonyPatch(typeof(AmbulanceAI), "StartTransfer")]
    public static class AmbulanceTransferPatch
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }

    [HarmonyPatch(typeof(AmbulanceCopterAI), "StartTransfer")]
    public static class AmbulanceCopterTransferPatch
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }

     [HarmonyPatch(typeof(DisasterResponseCopterAI), "StartTransfer")]
    public static class DisasterResponseCopterTransferPatch
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }

    [HarmonyPatch(typeof(DisasterResponseVehicleAI), "StartTransfer")]
    public static class DisasterResponseVehicleAI
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }

    [HarmonyPatch(typeof(FireCopterAI), "StartTransfer")]
    public static class FireCopterTransferPatch
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }

    [HarmonyPatch(typeof(FireTruckAI), "StartTransfer")]
    public static class FireTruckTransferPatch
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }

    [HarmonyPatch(typeof(GarbageTruckAI), "StartTransfer")]
    public static class GarbageTruckTransferPatch
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }

    [HarmonyPatch(typeof(HearseAI), "StartTransfer")]
    public static class HearseTransferPatch
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }

    [HarmonyPatch(typeof(MaintenanceTruckAI), "StartTransfer")]
    public static class MaintenanceTruckTransferPatch
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }

    [HarmonyPatch(typeof(ParkMaintenanceVehicleAI), "StartTransfer")]
    public static class ParkMaintenanceVehiceTransferPatch
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }

    [HarmonyPatch(typeof(PoliceCarAI), "StartTransfer")]
    public static class PoliceCarTransferPatch
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }

    [HarmonyPatch(typeof(PoliceCopterAI), "StartTransfer")]
    public static class PoliceCopterTransferPatch
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }

    [HarmonyPatch(typeof(PostVanAI), "StartTransfer")]
    public static class PostVanTransferPatch
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }

    [HarmonyPatch(typeof(SnowTruckAI), "StartTransfer")]
    public static class SnowTruckTransferPatch
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }

    [HarmonyPatch(typeof(TaxiAI), "StartTransfer")]
    public static class TaxiTransferPatch
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }

    [HarmonyPatch(typeof(WaterTruckAI), "StartTransfer")]
    public static class WaterTruckTransferPatch
    {
        public static bool Prefix(ushort vehicleID, ref Vehicle data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            return DistrictHelper.CanTransfer(data.m_sourceBuilding, material, offer);
        }
    }
}
