//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDReborn
    {
        
       
        private EInt m_ID = 0;   
        private EInt m_Level = 0;   
        private EInt m_ProfitCount = 0;   
        private string m_Cost;   
        private EInt m_ExtraDiamondCount = 0;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  iD {get { return m_ID; } }
       
        /// <summary>
        /// 当前等级=转生次数
        /// </summary>
        public  int  level {get { return m_Level; } }
       
        /// <summary>
        /// 当前倍率（直接改变每刀收益）
        /// </summary>
        public  int  profitCount {get { return m_ProfitCount; } }
       
        /// <summary>
        /// 升级费用
        /// </summary>
        public  string  cost {get { return m_Cost; } }
       
        /// <summary>
        /// 升级额外奖励
        /// </summary>
        public  int  extraDiamondCount {get { return m_ExtraDiamondCount; } }
       

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
                    m_ProfitCount = dataR.ReadInt();
                    break;
                case 3:
                    m_Cost = dataR.ReadString();
                    break;
                case 4:
                    m_ExtraDiamondCount = dataR.ReadInt();
                    break;
                default:
                    //TableHelper.CacheNewField(dataR, schemeNames[col], m_DataCacheNoGenerate);
                    break;
            }
          }

        }
        
        public static Dictionary<string, int> GetFieldHeadIndex()
        {
          Dictionary<string, int> ret = new Dictionary<string, int>(5);
          
          ret.Add("ID", 0);
          ret.Add("Level", 1);
          ret.Add("ProfitCount", 2);
          ret.Add("Cost", 3);
          ret.Add("ExtraDiamondCount", 4);
          return ret;
        }
    } 
}//namespace LR