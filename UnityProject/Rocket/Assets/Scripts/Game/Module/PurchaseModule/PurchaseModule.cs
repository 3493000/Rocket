using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Hunter;
using System.Reflection;

namespace Hunter
{
    public class PurchaseModule : TSingleton<PurchaseModule>
    {
        private Type m_PurchaseServiceType;

        public Type purchaseServiceType
        {
            get
            {
                if (m_PurchaseServiceType == null)
                {
                    m_PurchaseServiceType = Type.GetType("Hunter.PurchaseModule");
                }
                return m_PurchaseServiceType;
            }
        }

        public void Init()
        {
            EventSystem.S.Register(SDKEventID.OnPurchaseSuccess, OnPurchaseSuccess);
            PurchaseMgr.S.Init();
            PurchaseMgr.S.InitPurchaseInfo();
        }

        protected void OnPurchaseSuccess(int key, params object[] args)
        {
            TDPurchase data = args[0] as TDPurchase;

            ProcessRewardByType(data);
            

            ProcessPurchaseService(data);
        }

        protected void ProcessPurchaseService(TDPurchase data)
        {
            if (data == null || string.IsNullOrEmpty(data.serviceKey))
            {
                return;
            }

            Type type = purchaseServiceType;

            if (type == null)
            {
                return;
            }

            MethodInfo servicemethod = type.GetMethod(data.serviceKey);

            if (servicemethod == null)
            {
                Log.e("Invalid Purchase Service Name:" + data.serviceKey);
                return;
            }

            try
            {
                servicemethod.Invoke(null, new object[] { data });
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }

        void ProcessRewardByType(TDPurchase data)
        {
            //获得钻石
            //PlayerInfoMgr.data.AddDiamondCount(data.itemNum);
                        
        }

        //public void ShowRewardVideo()
        //{
        //    AdDisplayer.Builder()
        //    .SetPlacementID(Define.AD_SHOP_REWARD)
        //    .SetOnAdShowResultCallback(OnRewardVideoShowResult)
        //    .Show("PurchaseRewardVideo");
        //}

        protected void OnRewardVideoShowResult(bool show, bool reward, string rewardID)
        {
            if (show && reward)
            {
                //ItemMgr.data.AddGoldCount(10);
                //MessageTipsPanel.ShowMessageTipsPanel(MessageTipsPanel.UIMode.GREED, TDLanguageTable.GetFormat("UI_BambooTips", 10), null);
                //EventSystem.S.Send(EventID.OnRewardVideoSuccess);
            }
        }

    }
}
