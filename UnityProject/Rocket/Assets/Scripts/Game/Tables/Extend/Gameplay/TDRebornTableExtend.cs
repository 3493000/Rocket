using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDRebornTable
    {
        static void CompleteRowAdd(TDReborn tdData)
        {

        }

        public static TDReborn GetDataByRebornCount(int rebornCount)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                if (dataList[i].level == rebornCount)
                {
                    return dataList[i];
                }           
            }
            return null;
        }
    }
}