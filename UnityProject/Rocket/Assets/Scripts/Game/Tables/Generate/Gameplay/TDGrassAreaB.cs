//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDGrassAreaB
    {
        
       
        private EInt m_ID = 0;   
        private EInt m_Level = 0;   
        private string m_Cost;   
        private string m_GrassValue;   
        private EFloat m_GrowthTake = 0.0f;   
        private EFloat m_Speed = 0.0f;   
        private string m_SpeedShow;   
        private string m_Profit;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  iD {get { return m_ID; } }
       
        /// <summary>
        /// 草地等级
        /// </summary>
        public  int  level {get { return m_Level; } }
       
        /// <summary>
        /// 升级价格
        /// </summary>
        public  string  cost {get { return m_Cost; } }
       
        /// <summary>
        /// 草价格
        /// </summary>
        public  string  grassValue {get { return m_GrassValue; } }
       
        /// <summary>
        /// 草生长间隔（秒）
        /// </summary>
        public  float  growthTake {get { return m_GrowthTake; } }
       
        /// <summary>
        /// 飞镖速度
        /// </summary>
        public  float  speed {get { return m_Speed; } }
       
        /// <summary>
        /// 移动速度显示
        /// </summary>
        public  string  speedShow {get { return m_SpeedShow; } }
       
        /// <summary>
        /// 收益值（每秒）
        /// </summary>
        public  string  profit {get { return m_Profit; } }
       

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
                    m_Cost = dataR.ReadString();
                    break;
                case 3:
                    m_GrassValue = dataR.ReadString();
                    break;
                case 4:
                    m_GrowthTake = dataR.ReadFloat();
                    break;
                case 5:
                    m_Speed = dataR.ReadFloat();
                    break;
                case 6:
                    m_SpeedShow = dataR.ReadString();
                    break;
                case 7:
                    m_Profit = dataR.ReadString();
                    break;
                default:
                    //TableHelper.CacheNewField(dataR, schemeNames[col], m_DataCacheNoGenerate);
                    break;
            }
          }

        }
        
        public static Dictionary<string, int> GetFieldHeadIndex()
        {
          Dictionary<string, int> ret = new Dictionary<string, int>(8);
          
          ret.Add("ID", 0);
          ret.Add("Level", 1);
          ret.Add("Cost", 2);
          ret.Add("GrassValue", 3);
          ret.Add("GrowthTake", 4);
          ret.Add("Speed", 5);
          ret.Add("SpeedShow", 6);
          ret.Add("Profit", 7);
          return ret;
        }
    } 
}//namespace LR