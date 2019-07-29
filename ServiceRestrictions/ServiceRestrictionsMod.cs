using System;
using System.Reflection;
using Harmony;
using ICities;
using ServiceRestrictions.Patches;
using ServiceRestrictions.Settings;
using UnityEngine;

namespace ServiceRestrictions
{
    public class ServiceRestrictionsMod : IUserMod
    {
        private static HarmonyInstance _harmony;

        private static ServiceRestrictionSettings _settings;

        public static ServiceRestrictionSettings Settings
        {
            get
            {
                if (_settings != null)
                    return _settings;

                _settings = ServiceRestrictionSettings.Load();

                if (_settings != null)
                    return _settings;

                _settings = new ServiceRestrictionSettings();
                _settings.Save();

                return _settings;
            }
            set => _settings = value;
        }

        public string Name => "Service Restrictions";

        public string Description => "Restrict Services to Selected Districts";

        public void OnEnabled()
        {
            _harmony = HarmonyInstance.Create("com.github.celisuis.csl.servicerestrict");
            PatchBuildings();
            PatchVehicles();

            Debug.Log($"Successfully Patched Routines.");
        }

        public void OnDisabled()
        {
            _harmony.UnpatchAll();
        }

        private void PatchBuildings()
        {
            try
            {
                _harmony.Patch(typeof(HelicopterDepotAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(HelicopterDepotTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Helicopter Depot Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(DisasterResponseBuildingAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(DisasterResponseCanTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Disaster Response Building Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(FireStationAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(FireStationTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Fire Station Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(HospitalAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(HospitalAITransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Hospital AI Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(MedicalCenterAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(MedicalCenterTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Medical Center Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(LandfillSiteAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(LandfillSiteTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Land Fill Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(MaintenanceDepotAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(MaintenanceDepotTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Maintenance Depot Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(PoliceStationAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(PoliceStationTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Police Station Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(PostOfficeAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(PostOfficeCanTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Post Office Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(SnowDumpAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(SnowDumpTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Snow Dump Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(WaterFacilityAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(WaterFacilityTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Water Facility Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(CemeteryAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(CemeteryTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Cemetary Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(TaxiStandAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(TaxiStandTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Taxi Stand Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(DepotAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(DepotAITransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Depot AI Restrictions. {e.Message} - {e.StackTrace}");
            }
        }

        private void PatchVehicles()
        {
            try
            {
                _harmony.Patch(typeof(AmbulanceAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(AmbulanceTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Ambulance Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(AmbulanceCopterAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(AmbulanceCopterTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Ambulance Copter Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(DisasterResponseCopterAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(DisasterResponseCopterTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Disaster Response Copter Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(DisasterResponseVehicleAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(DisasterResponseVehicleAIPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Disaster Response Vehicle Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(FireCopterAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(FireCopterTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Fire Copter Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(FireTruckAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(FireTruckTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Fire Truck Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(GarbageTruckAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(GarbageTruckTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Garbage Truck Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(HearseAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(HearseTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Hearse Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(MaintenanceTruckAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(MaintenanceTruckTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Maintenance Truck Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(ParkMaintenanceVehicleAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(ParkMaintenanceVehiceTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Park Maintenance Vehicle Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(PoliceCarAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(PoliceCarTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Police Car Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(PoliceCopterAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(PoliceCopterTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Police Copter Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(PostVanAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(PostVanTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Post Van Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(SnowTruckAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(SnowTruckTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Snow Plows Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(TaxiAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(TaxiTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Taxi Restrictions. {e.Message} - {e.StackTrace}");
            }

            try
            {
                _harmony.Patch(typeof(WaterTruckAI).GetMethod("StartTransfer"),
                    new HarmonyMethod(typeof(WaterTruckTransferPatch).GetMethod("Prefix")));

            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Water Truck Restrictions. {e.Message} - {e.StackTrace}");
            }


        }
    }
}