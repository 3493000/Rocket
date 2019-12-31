//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDLevel
    {
        
       
        private EInt m_ID = 0;   
        private EInt m_Numberofcuts = 0;   
        private EInt m_Appearanceskin = 0;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  iD {get { return m_ID; } }
       
        /// <summary>
        /// 升级所需刀数
        /// </summary>
        public  int  numberofcuts {get { return m_Numberofcuts; } }
       
        /// <summary>
        /// 激励广告额外赠送物品
        /// </summary>
        public  int  appearanceskin {get { return m_Appearanceskin; } }
       

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
                    m_Numberofcuts = dataR.ReadInt();
                    break;
                case 2:
                    m_Appearanceskin = dataR.ReadInt();
                    break;
                default:
                    //TableHelper.CacheNewField(dataR, schemeNames[col], m_DataCacheNoGenerate);
                    break;
            }
          }

        }
        
        public static Dictionary<string, int> GetFieldHeadIndex()
        {
          Dictionary<string, int> ret = new Dictionary<string, int>(3);
          
          ret.Add("ID", 0);
          ret.Add("Numberofcuts", 1);
          ret.Add("Appearanceskin", 2);
          return ret;
        }
    } 
}//namespace LR