using Harmony;
using ServiceRestrictions.Helpers;
using UnityEngine;

namespace ServiceRestrictions.Patches
{
    [HarmonyPatch(typeof(HelicopterDepotAI), "StartTransfer")]
    public static class HelicopterDepotTransferPatch
    {
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            if (DistrictHelper.CanTransfer(buildingID, material, offer))
            {
                Debug.Log("Transfer Request Accepted.");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, material, offer);
            {
                Debug.Log("Moving Transfer Request.");
                return false;
            }
        }
    }

    [HarmonyPatch(typeof(DisasterResponseBuildingAI), "StartTransfer")]
    public static class DisasterResponseCanTransferPatch
    {
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            if (DistrictHelper.CanTransfer(buildingID, material, offer))
            {
                Debug.Log("Transfer Request Accepted.");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, material, offer);
            {
                Debug.Log("Moving Transfer Request.");
                return false;
            }
        }
    }

    [HarmonyPatch(typeof(FireStationAI), "StartTransfer")]
    public static class FireStationTransferPatch
    {
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            if (DistrictHelper.CanTransfer(buildingID, material, offer))
            {
                Debug.Log("Transfer Request Accepted.");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, material, offer);
            {
                Debug.Log("Moving Transfer Request.");
                return false;
            }
        }
    }

    [HarmonyPatch(typeof(HospitalAI), "StartTransfer")]
    public static class HospitalAITransferPatch
    {
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            if (DistrictHelper.CanTransfer(buildingID, material, offer))
            {
                Debug.Log("Transfer Request Accepted.");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, material, offer);
            {
                Debug.Log("Moving Transfer Request.");
                return false;
            }
        }
    }

    [HarmonyPatch(typeof(LandfillSiteAI), "StartTransfer")]
    public static class LandfillSiteTransferPatch
    {
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            if (DistrictHelper.CanTransfer(buildingID, material, offer))
            {
                Debug.Log("Transfer Request Accepted.");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, material, offer);
            {
                Debug.Log("Moving Transfer Request.");
                return false;
            }
        }
    }

    [HarmonyPatch(typeof(MaintenanceDepotAI), "StartTransfer")]
    public static class MaintenanceDepotTransferPatch
    {
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            if (DistrictHelper.CanTransfer(buildingID, material, offer))
            {
                Debug.Log("Transfer Request Accepted.");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, material, offer);
            {
                Debug.Log("Moving Transfer Request.");
                return false;
            }
        }
    }

    [HarmonyPatch(typeof(PoliceStationAI), "StartTransfer")]
    public static class PoliceStationTransferPatch
    {
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            if (DistrictHelper.CanTransfer(buildingID, material, offer))
            {
                Debug.Log("Transfer Request Accepted.");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, material, offer);
            {
                Debug.Log("Moving Transfer Request.");
                return false;
            }
        }
    }

    [HarmonyPatch(typeof(PostOfficeAI), "StartTransfer")]
    public static class PostOfficeCanTransferPatch
    {
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            if (DistrictHelper.CanTransfer(buildingID, material, offer))
            {
                Debug.Log("Transfer Request Accepted.");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, material, offer);
            {
                Debug.Log("Moving Transfer Request.");
                return false;
            }
        }
    }

    [HarmonyPatch(typeof(SnowDumpAI), "StartTransfer")]
    public static class SnowDumpTransferPatch
    {
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            if (DistrictHelper.CanTransfer(buildingID, material, offer))
            {
                Debug.Log("Transfer Request Accepted.");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, material, offer);
            {
                Debug.Log("Moving Transfer Request.");
                return false;
            }
        }
    }

    [HarmonyPatch(typeof(WaterFacilityAI), "StartTransfer")]
    public static class WaterFacilityTransferPatch
    {
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            if (DistrictHelper.CanTransfer(buildingID, material, offer))
            {
                Debug.Log("Transfer Request Accepted.");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, material, offer);
            {
                Debug.Log("Moving Transfer Request.");
                return false;
            }
        }
    }

    [HarmonyPatch(typeof(CemeteryAI), "StartTransfer")]
    public static class CemeteryTransferPatch
    {
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            if (DistrictHelper.CanTransfer(buildingID, material, offer))
            {
                Debug.Log("Transfer Request Accepted.");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, material, offer);
            {
                Debug.Log("Moving Transfer Request.");
                return false;
            }
        }
    }

    [HarmonyPatch(typeof(TaxiStandAI), "StartTransfer")]
    public static class TaxiStandTransferPatch
    {
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            if (DistrictHelper.CanTransfer(buildingID, material, offer))
            {
                Debug.Log("Transfer Request Accepted.");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, material, offer);
            {
                Debug.Log("Moving Transfer Request.");
                return false;
            }
        }
    }

    [HarmonyPatch(typeof(DepotAI), "StartTransfer")]
    public static class DepotAITransferPatch
    {
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            if (DistrictHelper.CanTransfer(buildingID, material, offer))
            {
                Debug.Log("Transfer Request Accepted.");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, material, offer);
            {
                Debug.Log("Moving Transfer Request.");
                return false;
            }
        }
    }
}