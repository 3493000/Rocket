//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public static partial class TDItemProbabilityTable
    {
        private static TDTableMetaData m_MetaData = new TDTableMetaData(TDItemProbabilityTable.Parse, "item_probability");
        public static TDTableMetaData metaData
        {
            get { return m_MetaData; }
        }
        
        private static Dictionary<int, TDItemProbability> m_DataCache = new Dictionary<int, TDItemProbability>();
        private static List<TDItemProbability> m_DataList = new List<TDItemProbability >();
        
        public static void Parse(byte[] fileData)
        {
            m_DataCache.Clear();
            m_DataList.Clear();
            DataStreamReader dataR = new DataStreamReader(fileData);
            int rowCount = dataR.GetRowCount();
            int[] fieldIndex = dataR.GetFieldIndex(TDItemProbability.GetFieldHeadIndex());
    #if (UNITY_STANDALONE_WIN) || UNITY_EDITOR || UNITY_STANDALONE_OSX
            dataR.CheckFieldMatch(TDItemProbability.GetFieldHeadIndex(), "ItemProbabilityTable");
    #endif
            for (int i = 0; i < rowCount; ++i)
            {
                TDItemProbability memberInstance = new TDItemProbability();
                memberInstance.ReadRow(dataR, fieldIndex);
                OnAddRow(memberInstance);
                memberInstance.Reset();
                CompleteRowAdd(memberInstance);
            }
            Log.i(string.Format("Parse Success TDItemProbability"));
        }

        private static void OnAddRow(TDItemProbability memberInstance)
        {
            int key = memberInstance.id;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDItemProbabilityTable Id already exists {0}", key));
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

        public static List<TDItemProbability> dataList
        {
            get 
            {
                return m_DataList;
            }    
        }

        public static TDItemProbability GetData(int key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDItemProbability", key));
                return null;
            }
        }
    }
}//namespace LR