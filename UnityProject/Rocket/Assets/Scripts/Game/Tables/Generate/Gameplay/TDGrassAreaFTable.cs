//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public static partial class TDGrassAreaFTable
    {
        private static TDTableMetaData m_MetaData = new TDTableMetaData(TDGrassAreaFTable.Parse, "grass_area_f");
        public static TDTableMetaData metaData
        {
            get { return m_MetaData; }
        }
        
        private static Dictionary<int, TDGrassAreaF> m_DataCache = new Dictionary<int, TDGrassAreaF>();
        private static List<TDGrassAreaF> m_DataList = new List<TDGrassAreaF >();
        
        public static void Parse(byte[] fileData)
        {
            m_DataCache.Clear();
            m_DataList.Clear();
            DataStreamReader dataR = new DataStreamReader(fileData);
            int rowCount = dataR.GetRowCount();
            int[] fieldIndex = dataR.GetFieldIndex(TDGrassAreaF.GetFieldHeadIndex());
    #if (UNITY_STANDALONE_WIN) || UNITY_EDITOR || UNITY_STANDALONE_OSX
            dataR.CheckFieldMatch(TDGrassAreaF.GetFieldHeadIndex(), "GrassAreaFTable");
    #endif
            for (int i = 0; i < rowCount; ++i)
            {
                TDGrassAreaF memberInstance = new TDGrassAreaF();
                memberInstance.ReadRow(dataR, fieldIndex);
                OnAddRow(memberInstance);
                memberInstance.Reset();
                CompleteRowAdd(memberInstance);
            }
            Log.i(string.Format("Parse Success TDGrassAreaF"));
        }

        private static void OnAddRow(TDGrassAreaF memberInstance)
        {
            int key = memberInstance.iD;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDGrassAreaFTable Id already exists {0}", key));
            }
            else
            {
                m_DataCache.Add(key, memberInstance);
                m_DataList.Add(memberInstance);
            }
        }    
        
        public static void Reload(byte[] fileData)
        {
            Parse(fileData);
        }

        public static int count
        {
            get 
            {
                return m_DataCache.Count;
            }
        }

        public static List<TDGrassAreaF> dataList
        {
            get 
            {
                return m_DataList;
            }    
        }

        public static TDGrassAreaF GetData(int key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDGrassAreaF", key));
                return null;
            }
        }
    }
}//namespace LR