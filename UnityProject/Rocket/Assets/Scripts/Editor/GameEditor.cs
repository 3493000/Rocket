using System;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using Hunter;
using Hunter.Editor;

namespace Hunter.Editor
{
    public class GameEditor
    {

        [MenuItem("Assets/Hunter/Config/Build CustomConfig")]
        public static void BuildSDKConfig()
        {
            SDKConfigEditor.BuildConfig<CustomColorConfig>("CustomColorConfig");
        }
        [MenuItem("数据工具/ClearPlayerPrefs")]
        static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
