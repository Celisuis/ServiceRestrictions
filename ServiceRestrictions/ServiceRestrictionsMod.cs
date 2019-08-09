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

            try
            {
                _harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception)
            {
                Debug.Log($"Couldn't Patch Service Restrictions.");
            }

            Debug.Log($"Successfully Patched Routines.");
        }

        public void OnDisabled()
        {
            _harmony.UnpatchAll();
        }

      
    }
}