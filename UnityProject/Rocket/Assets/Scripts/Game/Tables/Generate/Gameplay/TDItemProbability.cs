//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDItemProbability
    {
        
       
        private EInt m_Id = 0;   
        private EInt m_Probability = 0;   
        private EInt m_Angle = 0;   
        private string m_Name;   
        private bool m_AddGold = false;   
        private bool m_AddDiamond = false;   
        private EInt m_RewardValue = 0;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  id {get { return m_Id; } }
       
        /// <summary>
        /// 概率
        /// </summary>
        public  int  probability {get { return m_Probability; } }
       
        /// <summary>
        /// 角度
        /// </summary>
        public  int  angle {get { return m_Angle; } }
       
        /// <summary>
        /// NAME
        /// </summary>
        public  string  name {get { return m_Name; } }
       
        /// <summary>
        /// ADDGOLD
        /// </summary>
        public  bool  addGold {get { return m_AddGold; } }
       
        /// <summary>
        /// ADDDIAMOND
        /// </summary>
        public  bool  addDiamond {get { return m_AddDiamond; } }
       
        /// <summary>
        /// VALUEREWARD
        /// </summary>
        public  int  rewardValue {get { return m_RewardValue; } }
       

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
                    m_Id = dataR.ReadInt();
                    break;
                case 1:
                    m_Probability = dataR.ReadInt();
                    break;
                case 2:
                    m_Angle = dataR.ReadInt();
                    break;
                case 3:
                    m_Name = dataR.ReadString();
                    break;
                case 4:
                    m_AddGold = dataR.ReadBool();
                    break;
                case 5:
                    m_AddDiamond = dataR.ReadBool();
                    break;
                case 6:
                    m_RewardValue = dataR.ReadInt();
                    break;
                default:
                    //TableHelper.CacheNewField(dataR, schemeNames[col], m_DataCacheNoGenerate);
                    break;
            }
          }

        }
        
        public static Dictionary<string, int> GetFieldHeadIndex()
        {
          Dictionary<string, int> ret = new Dictionary<string, int>(7);
          
          ret.Add("Id", 0);
          ret.Add("Probability", 1);
          ret.Add("Angle", 2);
          ret.Add("Name", 3);
          ret.Add("AddGold", 4);
          ret.Add("AddDiamond", 5);
          ret.Add("RewardValue", 6);
          return ret;
        }
    } 
}//namespace LR