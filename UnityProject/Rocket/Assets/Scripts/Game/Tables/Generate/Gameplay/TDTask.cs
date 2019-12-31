//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDTask
    {
        
       
        private EInt m_ID = 0;   
        private string m_Description;   
        private bool m_IsLevel = false;   
        private EInt m_Trigger = 0;   
        private string m_Process;   
        private EInt m_TargetID = 0;   
        private string m_Title;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  iD {get { return m_ID; } }
       
        /// <summary>
        /// Description
        /// </summary>
        public  string  description {get { return m_Description; } }
       
        /// <summary>
        /// isLevel
        /// </summary>
        public  bool  isLevel {get { return m_IsLevel; } }
       
        /// <summary>
        /// Trigger
        /// </summary>
        public  int  trigger {get { return m_Trigger; } }
       
        /// <summary>
        /// Process
        /// </summary>
        public  string  process {get { return m_Process; } }
       
        /// <summary>
        /// TargetID
        /// </summary>
        public  int  targetID {get { return m_TargetID; } }
       
        /// <summary>
        /// Title
        /// </summary>
        public  string  title {get { return m_Title; } }
       

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
                    m_Description = dataR.ReadString();
                    break;
                case 2:
                    m_IsLevel = dataR.ReadBool();
                    break;
                case 3:
                    m_Trigger = dataR.ReadInt();
                    break;
                case 4:
                    m_Process = dataR.ReadString();
                    break;
                case 5:
                    m_TargetID = dataR.ReadInt();
                    break;
                case 6:
                    m_Title = dataR.ReadString();
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
          ret.Add("Description", 1);
          ret.Add("IsLevel", 2);
          ret.Add("Trigger", 3);
          ret.Add("Process", 4);
          ret.Add("TargetID", 5);
          ret.Add("Title", 6);
          return ret;
        }
    } 
}//namespace LR