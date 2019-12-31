using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter;

namespace Hunter
{
    public class TableModule : AbstractModule
    {
        private bool m_IsTableLoadFinish = false;

        public bool isTableLoadFinish
        {
            get { return m_IsTableLoadFinish; }
        }

        public void SwitchLanguage(string key)
        {
            TDTableMetaData[] tables = new TDTableMetaData[]
            {
                new TDTableMetaData(TDLanguageTable.Parse, FormatTableName(TDLanguageTable.metaData.tableName, key)),
            };

            m_IsTableLoadFinish = false;
            actor.StartCoroutine(TableMgr.S.ReadAll(tables, OnLanguageSwitchLoadFinish));
        }


        public void SwitchGrassAreaTable(string name ,Action OnDataLoadFinshed)
        {
            //TDGrassAreaTable.metaData.tableName = FormatTableName(TDGrassAreaTable.metaData.tableName, name);
            TDTableMetaData[] tables = new TDTableMetaData[]
            {
                new TDTableMetaData(TDGrassAreaTable.Parse,name),
            };

            m_IsTableLoadFinish = false;
            actor.StartCoroutine(TableMgr.S.ReadAll(tables, () => {
                OnGrassTableSwitchLoadFinish();
                OnDataLoadFinshed();
            }) );
        }

        public void SwitchTrunckMoveTable(string name,Action OnDataLoadFinshed)
        {
            //TDTrunckTable.metaData.tableName = FormatTableName(TDTrunckTable.metaData.tableName, name);
            TDTableMetaData[] tables = new TDTableMetaData[]
            {
                new TDTableMetaData(TDTrunckTable.Parse,name),
            };

            m_IsTableLoadFinish = false;
            actor.StartCoroutine(TableMgr.S.ReadAll(tables, ()=> {
                OnTrunckTableSwitchLoadFinish();
                OnDataLoadFinshed();
            }));
        }

        private string FormatTableName(string rawName, string key)
        {
            return string.Format("{0}_{1}", rawName, key);
        }

        protected override void OnComAwake()
        {
            InitPreLoadTableMetaData();
            InitDelayLoadTableMetaData();

            m_IsTableLoadFinish = false;
            actor.StartCoroutine(TableMgr.S.PreReadAll(OnTableLoadFinish));
        }

        private void OnLanguageSwitchLoadFinish()
        {
            m_IsTableLoadFinish = true;
            Log.i("OnLanguageSwitchLoadFinish.");
            EventSystem.S.Send(EventID.OnLanguageTableSwitchFinish);
        }
        private void OnGrassTableSwitchLoadFinish()
        {
            m_IsTableLoadFinish = true;
           
        }
        private void OnTrunckTableSwitchLoadFinish()
        {
            m_IsTableLoadFinish = true;

        }

        private void OnTableLoadFinish()
        {
            TDConstTable.InitArrays(typeof(ConstType));

           // TDSkinTable.InitSkinTable();

            //处理所有表的重建
            m_IsTableLoadFinish = true;
        }

        private void InitPreLoadTableMetaData()
        {
            TableConfig.preLoadTableArray = new TDTableMetaData[]
            {
                TDConstTable.metaData,
                TDLanguageTable.GetLanguageMetaData(),
                TDGuideTable.metaData,
                TDGuideStepTable.metaData,
                TDSocialAdapterTable.metaData,
                TDAdConfigTable.metaData,
                TDAdPlacementTable.metaData,

                TDRemoteConfigTable.metaData,
                TDAppConfigTable.metaData,
                TDPurchaseTable.metaData,


            };
        }

        private void InitDelayLoadTableMetaData()
        {
            TableConfig.delayLoadTableArray = new TDTableMetaData[]
            {

            };
        }
    }
}
