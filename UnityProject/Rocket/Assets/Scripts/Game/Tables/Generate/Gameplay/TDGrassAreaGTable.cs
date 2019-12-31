//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public static partial class TDGrassAreaGTable
    {
        private static TDTableMetaData m_MetaData = new TDTableMetaData(TDGrassAreaGTable.Parse, "grass_area_g");
        public static TDTableMetaData metaData
        {
            get { return m_MetaData; }
        }
        
        private static Dictionary<int, TDGrassAreaG> m_DataCache = new Dictionary<int, TDGrassAreaG>();
        private static List<TDGrassAreaG> m_DataList = new List<TDGrassAreaG >();
        
        public static void Parse(byte[] fileData)
        {
            m_DataCache.Clear();
            m_DataList.Clear();
            DataStreamReader dataR = new DataStreamReader(fileData);
            int rowCount = dataR.GetRowCount();
            int[] fieldIndex = dataR.GetFieldIndex(TDGrassAreaG.GetFieldHeadIndex());
    #if (UNITY_STANDALONE_WIN) || UNITY_EDITOR || UNITY_STANDALONE_OSX
            dataR.CheckFieldMatch(TDGrassAreaG.GetFieldHeadIndex(), "GrassAreaGTable");
    #endif
            for (int i = 0; i < rowCount; ++i)
            {
                TDGrassAreaG memberInstance = new TDGrassAreaG();
                memberInstance.ReadRow(dataR, fieldIndex);
                OnAddRow(memberInstance);
                memberInstance.Reset();
                CompleteRowAdd(memberInstance);
            }
            Log.i(string.Format("Parse Success TDGrassAreaG"));
        }

        private static void OnAddRow(TDGrassAreaG memberInstance)
        {
            int key = memberInstance.iD;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDGrassAreaGTable Id already exists {0}", key));
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

        public static List<TDGrassAreaG> dataList
        {
            get 
            {
                return m_DataList;
            }    
        }

        public static TDGrassAreaG GetData(int key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDGrassAreaG", key));
                return null;
            }
        }
    }
}//namespace LR