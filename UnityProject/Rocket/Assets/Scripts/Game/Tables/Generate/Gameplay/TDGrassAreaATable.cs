//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public static partial class TDGrassAreaATable
    {
        private static TDTableMetaData m_MetaData = new TDTableMetaData(TDGrassAreaATable.Parse, "grass_area_a");
        public static TDTableMetaData metaData
        {
            get { return m_MetaData; }
        }
        
        private static Dictionary<int, TDGrassAreaA> m_DataCache = new Dictionary<int, TDGrassAreaA>();
        private static List<TDGrassAreaA> m_DataList = new List<TDGrassAreaA >();
        
        public static void Parse(byte[] fileData)
        {
            m_DataCache.Clear();
            m_DataList.Clear();
            DataStreamReader dataR = new DataStreamReader(fileData);
            int rowCount = dataR.GetRowCount();
            int[] fieldIndex = dataR.GetFieldIndex(TDGrassAreaA.GetFieldHeadIndex());
    #if (UNITY_STANDALONE_WIN) || UNITY_EDITOR || UNITY_STANDALONE_OSX
            dataR.CheckFieldMatch(TDGrassAreaA.GetFieldHeadIndex(), "GrassAreaATable");
    #endif
            for (int i = 0; i < rowCount; ++i)
            {
                TDGrassAreaA memberInstance = new TDGrassAreaA();
                memberInstance.ReadRow(dataR, fieldIndex);
                OnAddRow(memberInstance);
                memberInstance.Reset();
                CompleteRowAdd(memberInstance);
            }
            Log.i(string.Format("Parse Success TDGrassAreaA"));
        }

        private static void OnAddRow(TDGrassAreaA memberInstance)
        {
            int key = memberInstance.iD;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDGrassAreaATable Id already exists {0}", key));
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

        public static List<TDGrassAreaA> dataList
        {
            get 
            {
                return m_DataList;
            }    
        }

        public static TDGrassAreaA GetData(int key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDGrassAreaA", key));
                return null;
            }
        }
    }
}//namespace LR