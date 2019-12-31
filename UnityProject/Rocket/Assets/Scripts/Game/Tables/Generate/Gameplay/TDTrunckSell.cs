//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDTrunckSell
    {
        
       
        private EInt m_ID = 0;   
        private EInt m_Level = 0;   
        private string m_Cost;   
        private string m_Load;   
        private string m_Capacity;   
        private EInt m_Speed = 0;   
        private string m_SpeedShow;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  iD {get { return m_ID; } }
       
        /// <summary>
        /// 卡车等级
        /// </summary>
        public  int  level {get { return m_Level; } }
       
        /// <summary>
        /// 升级价格
        /// </summary>
        public  string  cost {get { return m_Cost; } }
       
        /// <summary>
        /// 装货速度（每秒）
        /// </summary>
        public  string  load {get { return m_Load; } }
       
        /// <summary>
        /// 装货容量
        /// </summary>
        public  string  capacity {get { return m_Capacity; } }
       
        /// <summary>
        /// 移动速度
        /// </summary>
        public  int  speed {get { return m_Speed; } }
       
        /// <summary>
        /// 移动速度显示
        /// </summary>
        public  string  speedShow {get { return m_SpeedShow; } }
       

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
                    m_Load = dataR.ReadString();
                    break;
                case 4:
                    m_Capacity = dataR.ReadString();
                    break;
                case 5:
                    m_Speed = dataR.ReadInt();
                    break;
                case 6:
                    m_SpeedShow = dataR.ReadString();
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
          
          ret.Add("ID", 0);
          ret.Add("Level", 1);
          ret.Add("Cost", 2);
          ret.Add("Load", 3);
          ret.Add("Capacity", 4);
          ret.Add("Speed", 5);
          ret.Add("SpeedShow", 6);
          return ret;
        }
    } 
}//namespace LR