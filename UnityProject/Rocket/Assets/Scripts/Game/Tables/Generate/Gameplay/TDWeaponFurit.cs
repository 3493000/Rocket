//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public partial class TDWeaponFurit
    {
        
       
        private EInt m_ID = 0;   
        private EInt m_Index = 0;   
        private bool m_NeedGold = false;   
        private string m_GoldCost;   
        private bool m_NeedDiamond = false;   
        private EInt m_ADCost = 0;   
        private EInt m_Group = 0;   
        private string m_PrefabName;   
        private string m_JuiceEffect;   
        private string m_SpargingEffect;   
        private string m_ClasticEffect;   
        private string m_UiName;   
        private string m_TitleName;   
        private string m_GetUiName;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  iD {get { return m_ID; } }
       
        /// <summary>
        /// Index
        /// </summary>
        public  int  index {get { return m_Index; } }
       
        /// <summary>
        /// 是否需要金币解锁
        /// </summary>
        public  bool  needGold {get { return m_NeedGold; } }
       
        /// <summary>
        /// 解锁所需金钱
        /// </summary>
        public  string  goldCost {get { return m_GoldCost; } }
       
        /// <summary>
        /// 解锁需要钻石
        /// </summary>
        public  bool  needDiamond {get { return m_NeedDiamond; } }
       
        /// <summary>
        /// 解锁需要看广告数量
        /// </summary>
        public  int  aDCost {get { return m_ADCost; } }
       
        /// <summary>
        /// 分类
        /// </summary>
        public  int  group {get { return m_Group; } }
       
        /// <summary>
        /// 预设物名称
        /// </summary>
        public  string  prefabName {get { return m_PrefabName; } }
       
        /// <summary>
        /// 爆汁特效
        /// </summary>
        public  string  juiceEffect {get { return m_JuiceEffect; } }
       
        /// <summary>
        /// 黏着物特效
        /// </summary>
        public  string  spargingEffect {get { return m_SpargingEffect; } }
       
        /// <summary>
        /// 碎片特效
        /// </summary>
        public  string  clasticEffect {get { return m_ClasticEffect; } }
       
        /// <summary>
        /// UI图片
        /// </summary>
        public  string  uiName {get { return m_UiName; } }
       
        /// <summary>
        /// 名称
        /// </summary>
        public  string  titleName {get { return m_TitleName; } }
       
        /// <summary>
        /// 获得奖励
        /// </summary>
        public  string  getUiName {get { return m_GetUiName; } }
       

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
                    m_Index = dataR.ReadInt();
                    break;
                case 2:
                    m_NeedGold = dataR.ReadBool();
                    break;
                case 3:
                    m_GoldCost = dataR.ReadString();
                    break;
                case 4:
                    m_NeedDiamond = dataR.ReadBool();
                    break;
                case 5:
                    m_ADCost = dataR.ReadInt();
                    break;
                case 6:
                    m_Group = dataR.ReadInt();
                    break;
                case 7:
                    m_PrefabName = dataR.ReadString();
                    break;
                case 8:
                    m_JuiceEffect = dataR.ReadString();
                    break;
                case 9:
                    m_SpargingEffect = dataR.ReadString();
                    break;
                case 10:
                    m_ClasticEffect = dataR.ReadString();
                    break;
                case 11:
                    m_UiName = dataR.ReadString();
                    break;
                case 12:
                    m_TitleName = dataR.ReadString();
                    break;
                case 13:
                    m_GetUiName = dataR.ReadString();
                    break;
                default:
                    //TableHelper.CacheNewField(dataR, schemeNames[col], m_DataCacheNoGenerate);
                    break;
            }
          }

        }
        
        public static Dictionary<string, int> GetFieldHeadIndex()
        {
          Dictionary<string, int> ret = new Dictionary<string, int>(14);
          
          ret.Add("ID", 0);
          ret.Add("Index", 1);
          ret.Add("NeedGold", 2);
          ret.Add("GoldCost", 3);
          ret.Add("NeedDiamond", 4);
          ret.Add("ADCost", 5);
          ret.Add("Group", 6);
          ret.Add("PrefabName", 7);
          ret.Add("JuiceEffect", 8);
          ret.Add("SpargingEffect", 9);
          ret.Add("ClasticEffect", 10);
          ret.Add("UiName", 11);
          ret.Add("TitleName", 12);
          ret.Add("GetUiName", 13);
          return ret;
        }
    } 
}//namespace LR