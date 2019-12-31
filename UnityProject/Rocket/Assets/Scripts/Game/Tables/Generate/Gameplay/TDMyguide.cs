//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDMyguide
    {
        
       
        private EInt m_Id = 0;   
        private string m_Key;   
        private string m_GuideText;   
        private string m_GuidePanel;   
        private string m_GuideNote;   
        private string m_MyGuideHandler;   
        private EInt m_NexGuideId = 0;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  id {get { return m_Id; } }
       
        /// <summary>
        /// Key
        /// </summary>
        public  string  key {get { return m_Key; } }
       
        /// <summary>
        /// GuideText
        /// </summary>
        public  string  guideText {get { return m_GuideText; } }
       
        /// <summary>
        /// GuidePanel
        /// </summary>
        public  string  guidePanel {get { return m_GuidePanel; } }
       
        /// <summary>
        /// GuideNote
        /// </summary>
        public  string  guideNote {get { return m_GuideNote; } }
       
        /// <summary>
        /// MyGuideHandler
        /// </summary>
        public  string  myGuideHandler {get { return m_MyGuideHandler; } }
       
        /// <summary>
        /// NextGuide
        /// </summary>
        public  int  nexGuideId {get { return m_NexGuideId; } }
       

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
                    m_Key = dataR.ReadString();
                    break;
                case 2:
                    m_GuideText = dataR.ReadString();
                    break;
                case 3:
                    m_GuidePanel = dataR.ReadString();
                    break;
                case 4:
                    m_GuideNote = dataR.ReadString();
                    break;
                case 5:
                    m_MyGuideHandler = dataR.ReadString();
                    break;
                case 6:
                    m_NexGuideId = dataR.ReadInt();
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
          ret.Add("Key", 1);
          ret.Add("GuideText", 2);
          ret.Add("GuidePanel", 3);
          ret.Add("GuideNote", 4);
          ret.Add("MyGuideHandler", 5);
          ret.Add("NexGuideId", 6);
          return ret;
        }
    } 
}//namespace LR