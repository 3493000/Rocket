using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    [System.Serializable]
    public class CustomColorConfig : ScriptableObject
    {
      

        [SerializeField]
        public Color[] Colors;

        [SerializeField]
        public Color[] StockColors;
        


    }
}
