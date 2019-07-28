using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICities;
using ServiceRestricter.Internal;

namespace ServiceRestricter.Extensions
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public static bool _isDoneLoading;


        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);

            if (mode == LoadMode.NewAsset || mode == LoadMode.LoadAsset || mode == LoadMode.NewMap ||
                mode == LoadMode.LoadMap || mode == LoadMode.NewTheme || mode == LoadMode.LoadTheme)
                return;


            while (!_isDoneLoading)
                if (LoadingManager.instance.m_loadingComplete)
                {
                    ServiceRestrictTool.instance.Initialize();
                    _isDoneLoading = true;
                }
        }
    }
}
