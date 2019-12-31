//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDAchievement
    {
        
       
        private EInt m_Id = 0;   
        private EInt m_Group = 0;   
        private EInt m_Reward = 0;   
        private string m_Describe;   
        private EInt m_Condition1 = 0;   
        private string m_Title;   
        private EInt m_Condition2 = 0;   
        private EInt m_Initvalue = 0;   
        private EInt m_StepValue = 0;   
        private EInt m_MaxLevel = 0;   
        private string m_StringKey;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  id {get { return m_Id; } }
       
        /// <summary>
        /// Type
        /// </summary>
        public  int  group {get { return m_Group; } }
       
        /// <summary>
        /// Reward
        /// </summary>
        public  int  reward {get { return m_Reward; } }
       
        /// <summary>
        /// 描述性的
        /// </summary>
        public  string  describe {get { return m_Describe; } }
       
        /// <summary>
        /// Condition1
        /// </summary>
        public  int  condition1 {get { return m_Condition1; } }
       
        /// <summary>
        /// Title
        /// </summary>
        public  string  title {get { return m_Title; } }
       
        /// <summary>
        /// Condition2
        /// </summary>
        public  int  condition2 {get { return m_Condition2; } }
       
        /// <summary>
        /// Initvalue
        /// </summary>
        public  int  initvalue {get { return m_Initvalue; } }
       
        /// <summary>
        /// StepValue
        /// </summary>
        public  int  stepValue {get { return m_StepValue; } }
       
        /// <summary>
        /// MaxLevel
        /// </summary>
        public  int  maxLevel {get { return m_MaxLevel; } }
       
        /// <summary>
        /// StringKey
        /// </summary>
        public  string  stringKey {get { return m_StringKey; } }
       

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
                    m_Group = dataR.ReadInt();
                    break;
                case 2:
                    m_Reward = dataR.ReadInt();
                    break;
                case 3:
                    m_Describe = dataR.ReadString();
                    break;
                case 4:
                    m_Condition1 = dataR.ReadInt();
                    break;
                case 5:
                    m_Title = dataR.ReadString();
                    break;
                case 6:
                    m_Condition2 = dataR.ReadInt();
                    break;
                case 7:
                    m_Initvalue = dataR.ReadInt();
                    break;
                case 8:
                    m_StepValue = dataR.ReadInt();
                    break;
                case 9:
                    m_MaxLevel = dataR.ReadInt();
                    break;
                case 10:
                    m_StringKey = dataR.ReadString();
                    break;
                default:
                    //TableHelper.CacheNewField(dataR, schemeNames[col], m_DataCacheNoGenerate);
                    break;
            }
          }

        }
        
        public static Dictionary<string, int> GetFieldHeadIndex()
        {
          Dictionary<string, int> ret = new Dictionary<string, int>(11);
          
          ret.Add("Id", 0);
          ret.Add("Group", 1);
          ret.Add("Reward", 2);
          ret.Add("Describe", 3);
          ret.Add("Condition1", 4);
          ret.Add("Title", 5);
          ret.Add("Condition2", 6);
          ret.Add("Initvalue", 7);
          ret.Add("StepValue", 8);
          ret.Add("MaxLevel", 9);
          ret.Add("StringKey", 10);
          return ret;
        }
    } 
}//namespace LR