using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter;
using System;

namespace Hunter
{
    public class PlayerInfo : IDataClass
    {

        public bool m_IsNewPlayer = true;

        public string m_GoldCountStr;
        public string m_LeaveTime;
        public int m_OfflineTime;
        public string m_LastLoginTime;//上次登录时间

        public int m_DiamondCount;

        public double m_Exp;
        public int m_Level = 1;

        private BigInteger m_GoldCount;

        public PlayerInfo()
        {
            SetDirtyRecorder(PlayerInfoMgr.dataDirtyRecorder);
        }

        public override void InitWithEmptyData()
        {



            if (string.IsNullOrEmpty(m_GoldCountStr))
            {
                m_GoldCountStr = "0";//1000000000000000000000000000000000
                //m_DiamondCount = 10000;
            }

            if (string.IsNullOrEmpty(m_LeaveTime))
            {
                m_LeaveTime = Helper.GetCurrentTimeSecond().ToString();
            }

            SetDataDirty();
        }

        public override void OnDataLoadFinish()
        {

            if (string.IsNullOrEmpty(m_LeaveTime))
            {
                m_LeaveTime = Helper.GetCurrentTimeSecond().ToString();
            }
            m_GoldCount = new BigInteger(m_GoldCountStr);

            CheckLeaveTime();

            Timer.S.Post2Really((x) =>
            {
                ResetLeaveTime();
            }, 60, -1);
            SetDataDirty();
        }

        public bool GetIsNewPlayer()
        {
            return m_IsNewPlayer;
        }

        public void SetPlayerState()
        {
            m_IsNewPlayer = false;
            SetDataDirty();
        }

        public void AddGoldCount(BigInteger count, bool IsRefreshAnime = false)
        {
            if (!IsRefreshAnime)
            {
                m_GoldCount = m_GoldCount + count;
                if (m_GoldCount <= 0)
                {
                    m_GoldCount = 0;
                }
                m_GoldCountStr = m_GoldCount.ToString();

                SetDataDirty();
            }
            else
            {
               // EventSystem.S.Send(EventID.GoldFly, count);
            }

        }

        public BigInteger GetGoldCount()
        {
            return m_GoldCount;
        }

        public void AddDiamondCount(int Diamond)
        {
            m_DiamondCount += Diamond;
            if (m_DiamondCount <= 0)
            {
                m_DiamondCount = 0;
            }

            SetDataDirty();
        }

        public int GetDiamondCount()
        {
            return m_DiamondCount;
        }

        public long CheckLeaveTime()
        {
            long TimeNow = Helper.GetCurrentTimeSecond();
            long LeaveTime = TimeNow - long.Parse(m_LeaveTime);
            m_OfflineTime = (int)LeaveTime;
            if (m_OfflineTime < 0) m_OfflineTime = 0;
            SetDataDirty();
            ResetLeaveTime();
            return LeaveTime;
        }

        public void ResetLeaveTime()
        {
            m_LeaveTime = Helper.GetCurrentTimeSecond().ToString();
            SetDataDirty();
        }

    }    
}