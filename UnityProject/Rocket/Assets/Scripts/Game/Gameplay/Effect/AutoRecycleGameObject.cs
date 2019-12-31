using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public class AutoRecycleGameObject : MonoBehaviour
    {
        [SerializeField]
        private float m_DelayTime = 1;

        private int m_Timer = -1;

        private void OnEnable()
        {
            if (m_Timer > 0)
            {
                CancelTimer();
            }

            Timer.S.Post2Scale(OnTimerTick, m_DelayTime);
        }

        private void OnTimerTick(int tick)
        {
            CancelTimer();
            GameObjectPoolMgr.S.Recycle(gameObject);
        }

        private void OnDisable()
        {
            CancelTimer();
        }

        private void CancelTimer()
        {
            if (m_Timer > 0)
            {
                Timer.S.Cancel(m_Timer);
                m_Timer = -1;
            }
        }
    }
}
