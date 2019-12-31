//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public static partial class TDLevelTable
    {
        private static TDTableMetaData m_MetaData = new TDTableMetaData(TDLevelTable.Parse, "Level");
        public static TDTableMetaData metaData
        {
            get { return m_MetaData; }
        }
        
        private static Dictionary<int, TDLevel> m_DataCache = new Dictionary<int, TDLevel>();
        private static List<TDLevel> m_DataList = new List<TDLevel >();
        
        public static void Parse(byte[] fileData)
        {
            m_DataCache.Clear();
            m_DataList.Clear();
            DataStreamReader dataR = new DataStreamReader(fileData);
            int rowCount = dataR.GetRowCount();
            int[] fieldIndex = dataR.GetFieldIndex(TDLevel.GetFieldHeadIndex());
    #if (UNITY_STANDALONE_WIN) || UNITY_EDITOR || UNITY_STANDALONE_OSX
            dataR.CheckFieldMatch(TDLevel.GetFieldHeadIndex(), "LevelTable");
    #endif
            for (int i = 0; i < rowCount; ++i)
            {
                TDLevel memberInstance = new TDLevel();
                memberInstance.ReadRow(dataR, fieldIndex);
                OnAddRow(memberInstance);
                memberInstance.Reset();
                CompleteRowAdd(memberInstance);
            }
            Log.i(string.Format("Parse Success TDLevel"));
        }

        private static void OnAddRow(TDLevel memberInstance)
        {
            int key = memberInstance.iD;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDLevelTable Id already exists {0}", key));
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

        public static List<TDLevel> dataList
        {
            get 
            {
                return m_DataList;
            }    
        }

        public static TDLevel GetData(int key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDLevel", key));
                return null;
            }
        }
    }
}//namespace LR