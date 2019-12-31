using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDWeaponFuritTable
    {
        static void CompleteRowAdd(TDWeaponFurit tdData)
        {

        }
       public static List<TDWeaponFurit> GetWeaponDataList()
        {
            List<TDWeaponFurit> dataList=new List<TDWeaponFurit>();
            for (int i = 0; i < TDWeaponFuritTable.count; i++)
            {
                if (TDWeaponFuritTable.dataList[i].group == 1)
                {
                    dataList.Add(TDWeaponFuritTable.dataList[i]);
                }
            }
            return dataList;
        }

        public static List<TDWeaponFurit> GetFruitDataList()
        {
            List<TDWeaponFurit> dataList = new List<TDWeaponFurit>();
            for (int i = 0; i < TDWeaponFuritTable.count; i++)
            {
                if (TDWeaponFuritTable.dataList[i].group == 2)
                {
                    dataList.Add(TDWeaponFuritTable.dataList[i]);
                }
            }
            return dataList;
        }

        public static List<TDWeaponFurit> GetPropDataList()
        {
            List<TDWeaponFurit> dataList = new List<TDWeaponFurit>();
            for (int i = 0; i < TDWeaponFuritTable.count; i++)
            {
                if (TDWeaponFuritTable.dataList[i].group == 3)
                {
                    dataList.Add(TDWeaponFuritTable.dataList[i]);
                }
            }
            return dataList;

        }
    }
}