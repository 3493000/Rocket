using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public class ColorModule : TSingleton<ColorModule>
    {
        private CustomColorConfig m_Config;

        public void Init()
        {
            Log.i("Init ColorModule.");
        }

        public CustomColorConfig colorConfig
        {
            get { return m_Config; }
        }

        public override void OnSingletonInit()
        {
            m_Config = LoadConfig();
        }

        public Color GetColor(float precent)
        {
            return ColorGradientHelper.CalcualteColor(m_Config.Colors, precent);
        }

        private CustomColorConfig LoadConfig()
        {
            ResLoader loader = ResLoader.Allocate("ColorModule", null);

            UnityEngine.Object obj = loader.LoadSync("CustomColorConfig");
            if (obj == null)
            {
                Log.e("Not Find Color Config.");
                loader.Recycle2Cache();
                return null;
            }

            //Log.i("Success Load SDK Config.");
            CustomColorConfig prefab = obj as CustomColorConfig;

            CustomColorConfig newAB = GameObject.Instantiate(prefab);

            loader.Recycle2Cache();

            return newAB;
        }

        public Color GetColorByIndex(int index)
        {
            return m_Config.Colors[index];
        }

    }
}
