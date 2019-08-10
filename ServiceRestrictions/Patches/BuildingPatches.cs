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
            Debug.Log("Start Transfer Called");
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
            Debug.Log("Start Transfer Called");
            if (DistrictHelper.CanTransfer(buildingID, material, offer))
            {
                Debug.Log(
                    $"Transfer Request Accepted from {DistrictManager.instance.GetDistrictName(DistrictManager.instance.GetDistrict(data.m_position))}");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, material, offer);
            {
                Debug.Log(
                    $"Moving Transfer Request from {DistrictManager.instance.GetDistrictName(DistrictManager.instance.GetDistrict(data.m_position))}");
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
            Debug.Log("Start Transfer Called");
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
            Debug.Log("Start Transfer Called");
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

    [HarmonyPatch(typeof(MedicalCenterAI), "StartTransfer")]
    public static class MedicalCenterTransferPatch
    {
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason material,
            TransferManager.TransferOffer offer)
        {
            Debug.Log("Start Transfer Called");
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
            Debug.Log("Start Transfer Called");
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
            Debug.Log("Start Transfer Called");
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
            Debug.Log("Start Transfer Called");
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
            Debug.Log("Start Transfer Called");
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
            Debug.Log("Start Transfer Called");
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
            Debug.Log("Start Transfer Called");
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
            Debug.Log("Start Transfer Called");
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
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason reason,
            TransferManager.TransferOffer offer)
        {
            Debug.Log("Start Transfer Called");
            if (DistrictHelper.CanTransfer(buildingID, reason, offer))
            {
                Debug.Log("Transfer Request Accepted.");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, reason, offer);
            {
                Debug.Log("Moving Transfer Request.");
                return false;
            }
        }
    }

    [HarmonyPatch(typeof(DepotAI), "StartTransfer")]
    public static class DepotAITransferPatch
    {
        public static bool Prefix(ushort buildingID, ref Building data, TransferManager.TransferReason reason,
            TransferManager.TransferOffer offer)
        {
            Debug.Log("Start Transfer Called");
            if (DistrictHelper.CanTransfer(buildingID, reason, offer))
            {
                Debug.Log("Transfer Request Accepted.");
                return true;
            }

            BuildingHelper.MoveRequest(buildingID, ref data, reason, offer);
            {
                Debug.Log("Moving Transfer Request.");
                return false;
            }
        }
    }
}