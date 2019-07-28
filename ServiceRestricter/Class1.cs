using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Harmony;
using ICities;
using ServiceRestricter.Settings;
using UnityEngine;

namespace ServiceRestricter
{
    public class ServiceResticterMod : IUserMod
    {
        public string Name => "Service Restricter";

        public string Description => "Restrict Services to Selected Districts";

        private static HarmonyInstance _harmony;

        public void OnEnabled()
        {
            _harmony = HarmonyInstance.Create("com.github.celisuis.csl.servicerestrict");

            try
            {
                _harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception e)
            {
                Debug.Log($"Error Patching Service Restricter. {e.Message} - {e.StackTrace}");
            }
        }

        public void OnDisabled()
        {
            _harmony.UnpatchAll();
        }

        private static ServiceRestricterSettings _settings;

        public static ServiceRestricterSettings Settings
        {
            get
            {
                if (_settings != null)
                    return _settings;

                _settings = ServiceRestricterSettings.Load();

                if (_settings != null)
                    return _settings;

                _settings = new ServiceRestricterSettings();
                _settings.Save();

                return _settings;
            }
            set => _settings = value;
        }
    }
}
