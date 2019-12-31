//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDEvents
    {
        
       
        private EInt m_ID = 0;   
        private EInt m_Type = 0;   
        private string m_EventObject;   
        private string m_ImgName;   
        private string m_Text;   
        private string m_Btn;   
        private string m_TimeFree;   
        private string m_TimeAD;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// 事件编号
        /// </summary>
        public  int  iD {get { return m_ID; } }
       
        /// <summary>
        /// 事件类型
        /// </summary>
        public  int  type {get { return m_Type; } }
       
        /// <summary>
        /// 触发对象
        /// </summary>
        public  string  eventObject {get { return m_EventObject; } }
       
        /// <summary>
        /// 图片名称
        /// </summary>
        public  string  imgName {get { return m_ImgName; } }
       
        /// <summary>
        /// 描述
        /// </summary>
        public  string  text {get { return m_Text; } }
       
        /// <summary>
        /// 按钮显示文字
        /// </summary>
        public  string  btn {get { return m_Btn; } }
       
        /// <summary>
        /// 免费持续时长-秒
        /// </summary>
        public  string  timeFree {get { return m_TimeFree; } }
       
        /// <summary>
        /// 广告持续时长秒
        /// </summary>
        public  string  timeAD {get { return m_TimeAD; } }
       

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
                    m_Type = dataR.ReadInt();
                    break;
                case 2:
                    m_EventObject = dataR.ReadString();
                    break;
                case 3:
                    m_ImgName = dataR.ReadString();
                    break;
                case 4:
                    m_Text = dataR.ReadString();
                    break;
                case 5:
                    m_Btn = dataR.ReadString();
                    break;
                case 6:
                    m_TimeFree = dataR.ReadString();
                    break;
                case 7:
                    m_TimeAD = dataR.ReadString();
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
          ret.Add("Type", 1);
          ret.Add("EventObject", 2);
          ret.Add("ImgName", 3);
          ret.Add("Text", 4);
          ret.Add("Btn", 5);
          ret.Add("TimeFree", 6);
          ret.Add("TimeAD", 7);
          return ret;
        }
    } 
}//namespace LR