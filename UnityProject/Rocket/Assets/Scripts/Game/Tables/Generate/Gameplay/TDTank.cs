//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDTank
    {
        
       
        private EInt m_ID = 0;   
        private EInt m_TankUnlockLevel = 0;   
        private string m_TankText;   
        private EInt m_TankCD = 0;   
        private EInt m_TankTime = 0;   
        private EInt m_TankTimeAD = 0;   
        private string m_TankCost;   
        private EInt m_TankUnlockTime = 0;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  iD {get { return m_ID; } }
       
        /// <summary>
        /// 解锁等级：对应土地
        /// </summary>
        public  int  tankUnlockLevel {get { return m_TankUnlockLevel; } }
       
        /// <summary>
        /// 提示文字
        /// </summary>
        public  string  tankText {get { return m_TankText; } }
       
        /// <summary>
        /// CD时间（秒）
        /// </summary>
        public  int  tankCD {get { return m_TankCD; } }
       
        /// <summary>
        /// 持续时间
        /// </summary>
        public  int  tankTime {get { return m_TankTime; } }
       
        /// <summary>
        /// 看1次广告额外加时间
        /// </summary>
        public  int  tankTimeAD {get { return m_TankTimeAD; } }
       
        /// <summary>
        /// 金币花费
        /// </summary>
        public  string  tankCost {get { return m_TankCost; } }
       
        /// <summary>
        /// 解锁耗时-秒
        /// </summary>
        public  int  tankUnlockTime {get { return m_TankUnlockTime; } }
       

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
                    m_TankUnlockLevel = dataR.ReadInt();
                    break;
                case 2:
                    m_TankText = dataR.ReadString();
                    break;
                case 3:
                    m_TankCD = dataR.ReadInt();
                    break;
                case 4:
                    m_TankTime = dataR.ReadInt();
                    break;
                case 5:
                    m_TankTimeAD = dataR.ReadInt();
                    break;
                case 6:
                    m_TankCost = dataR.ReadString();
                    break;
                case 7:
                    m_TankUnlockTime = dataR.ReadInt();
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
          ret.Add("TankUnlockLevel", 1);
          ret.Add("TankText", 2);
          ret.Add("TankCD", 3);
          ret.Add("TankTime", 4);
          ret.Add("TankTimeAD", 5);
          ret.Add("TankCost", 6);
          ret.Add("TankUnlockTime", 7);
          return ret;
        }
    } 
}//namespace LR