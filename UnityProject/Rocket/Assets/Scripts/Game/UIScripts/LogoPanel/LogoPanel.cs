using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Hunter;
using DG.Tweening;

namespace Hunter
{
    public class LogoPanel : AbstractPanel
    {
        [SerializeField]
        private float m_ShowTime = 3;
        private Action m_Listener;
        private int m_TimeID;

        protected override void OnPanelOpen(params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                m_Listener = args[0] as Action;
            }

            if (m_TimeID > 0)
            {
                Timer.S.Cancel(m_TimeID);
            }
            m_TimeID = Timer.S.Post2Really(OnTimeReach, m_ShowTime);
        }

        private void OnTimeReach(int count)
        {
            m_TimeID = -1;

            if (m_Listener != null)
            {
                m_Listener();
                m_Listener = null;
            }
        }
    }
}
