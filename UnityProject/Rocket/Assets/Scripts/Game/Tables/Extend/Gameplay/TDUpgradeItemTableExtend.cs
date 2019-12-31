using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDUpgradeItemTable
    {
        static void CompleteRowAdd(TDUpgradeItem tdData)
        {

        }
        public static List<TDUpgradeItem> GetDataListByGroup(int Group)
        {
            List<TDUpgradeItem> dataList=new List<TDUpgradeItem>();
            for (int i = 0; i < TDUpgradeItemTable.count; i++)
            {
                if (TDUpgradeItemTable.dataList[i].group == Group)
                {
                    dataList.Add(TDUpgradeItemTable.dataList[i]);
                }
            }
            return dataList;
        }
    }
}