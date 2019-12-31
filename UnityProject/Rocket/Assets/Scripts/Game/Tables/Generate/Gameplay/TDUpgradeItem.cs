//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDUpgradeItem
    {
        
       
        private EInt m_ID = 0;   
        private EInt m_Level = 0;   
        private string m_Value;   
        private string m_Cost;   
        private EInt m_ContinuousUpgrading = 0;   
        private EInt m_Group = 0;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  iD {get { return m_ID; } }
       
        /// <summary>
        /// 等级
        /// </summary>
        public  int  level {get { return m_Level; } }
       
        /// <summary>
        /// 值
        /// </summary>
        public  string  value {get { return m_Value; } }
       
        /// <summary>
        /// 升到下一级所需金钱
        /// </summary>
        public  string  cost {get { return m_Cost; } }
       
        /// <summary>
        /// 是否弹出连升弹框
        /// </summary>
        public  int  continuousUpgrading {get { return m_ContinuousUpgrading; } }
       
        /// <summary>
        /// 分类
        /// </summary>
        public  int  group {get { return m_Group; } }
       

        public void ReadRow(DataStreamReader dataR, int[] filedIndex)
        {
          //var schemeNames = dataR.GetSchemeName();
          int col = 0;
          while(true)
          {
            col = dataR.MoreFieldOnRow();
            if (col == -1)
            {
              break;
            }
            switch (filedIndex[col])
            { 
            
                case 0:
                    m_ID = dataR.ReadInt();
                    break;
                case 1:
                    m_Level = dataR.ReadInt();
                    break;
                case 2:
                    m_Value = dataR.ReadString();
                    break;
                case 3:
                    m_Cost = dataR.ReadString();
                    break;
                case 4:
                    m_ContinuousUpgrading = dataR.ReadInt();
                    break;
                case 5:
                    m_Group = dataR.ReadInt();
                    break;
                default:
                    //TableHelper.CacheNewField(dataR, schemeNames[col], m_DataCacheNoGenerate);
                    break;
            }
          }

        }
        
        public static Dictionary<string, int> GetFieldHeadIndex()
        {
          Dictionary<string, int> ret = new Dictionary<string, int>(6);
          
          ret.Add("ID", 0);
          ret.Add("Level", 1);
          ret.Add("Value", 2);
          ret.Add("Cost", 3);
          ret.Add("ContinuousUpgrading", 4);
          ret.Add("Group", 5);
          return ret;
        }
    } 
}//namespace LR