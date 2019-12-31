//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDLandText
    {
        
       
        private EInt m_ID = 0;   
        private EInt m_Value = 0;   
        private string m_GrowthTake;   
        private string m_MoveSpeed;   
        private string m_Profit;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  iD {get { return m_ID; } }
       
        /// <summary>
        /// 价格
        /// </summary>
        public  int  value {get { return m_Value; } }
       
        /// <summary>
        /// 生长间隔
        /// </summary>
        public  string  growthTake {get { return m_GrowthTake; } }
       
        /// <summary>
        /// 飞镖速度
        /// </summary>
        public  string  moveSpeed {get { return m_MoveSpeed; } }
       
        /// <summary>
        /// 收益
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
                    m_Value = dataR.ReadInt();
                    break;
                case 2:
                    m_GrowthTake = dataR.ReadString();
                    break;
                case 3:
                    m_MoveSpeed = dataR.ReadString();
                    break;
                case 4:
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
          Dictionary<string, int> ret = new Dictionary<string, int>(5);
          
          ret.Add("ID", 0);
          ret.Add("Value", 1);
          ret.Add("GrowthTake", 2);
          ret.Add("MoveSpeed", 3);
          ret.Add("Profit", 4);
          return ret;
        }
    } 
}//namespace LR