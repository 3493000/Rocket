using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDLevelTable
    {
        static void CompleteRowAdd(TDLevel tdData)
        {

        }

        public static TDLevel GetTDLevel(int level)
        {
            if (level <= 0 || level > count) return null;
            return dataList[level - 1];
        }
    }
}