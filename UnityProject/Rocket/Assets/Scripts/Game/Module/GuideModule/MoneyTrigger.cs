using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hunter
{
    public class MoneyTrigger : ITrigger
    {

        private BigInteger m_TriggerMoney = 0;
        private int m_Index = -1;

        private Action<bool, ITrigger> m_Listener;
        public bool isReady
        {
            get
            {
                if (m_TriggerMoney <= 0)
                {
                    return false;
                }
                //判断钱是否够，判断是否升级过，是否转生过
                return
                    (
                    PlayerInfoMgr.data.GetGoldCount() >= m_TriggerMoney
                    //&&
                    //PlayerInfoMgr.data.m_ReBornCount == 1
                    //&& PlayerInfoMgr.data.GetInfoHelper().GetUpgradeInfoIsLevelUpByIndex(m_Index)
                    );
                ;
            }
        }

        public void SetParam(object[] param)
        {
            m_Index = int.Parse(param[0].ToString());
          //  m_TriggerMoney = new BigInteger( PlayerInfoMgr.data.GetUpgradeInfoHelper().GetUpgradeInfoByType((UpgradeType)m_Index).GetCost());
        }

        public void Start(Action<bool, ITrigger> l)
        {
            m_Listener = l;
         //   EventSystem.S.Register(EventID.OnGoldCountUpdate, OnAddGoldTrigger);
        }

        public void Stop()
        {
            m_Listener = null;
           // EventSystem.S.UnRegister(EventID.OnGoldCountUpdate, OnAddGoldTrigger);
        }

        private void OnAddGoldTrigger(int key, params object[] param)
        {
            if (m_Listener == null)
            {
                return;
            }

            if (isReady)
            {
                m_Listener(true, this);
            }
            else
            {
                m_Listener(false, this);
            }
        }
    }
}
