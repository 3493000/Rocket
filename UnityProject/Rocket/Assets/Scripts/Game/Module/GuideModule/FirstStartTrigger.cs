using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter;
using System;

namespace Hunter
{
    public class FirstStartTrigger : ITrigger
    {

		private Action<bool, ITrigger> m_Listener;
        public bool isReady 
		{
			get
			{
				if(PlayerInfoMgr.data == null)
				{
					return false;
				}
				return PlayerInfoMgr.data.GetIsNewPlayer();
			}
		}

        public void SetParam(object[] param)
        {
            
        }

        public void Start(Action<bool, ITrigger> l)
        {
			m_Listener = l;
			//EventSystem.S.Register(EventID.OnFirstStart, OnFirstStartTrigger);
			if(isReady)
			{
				m_Listener(true, this);
			}
			else
			{
				m_Listener(false, this);
			}
        }

        public void Stop()
        {
            m_Listener = null;
			//EventSystem.S.UnRegister(EventID.OnFirstStart, OnFirstStartTrigger);
			PlayerInfoMgr.data.SetPlayerState();
        }

		private void OnFirstStartTrigger(int key, params object[] param)
		{
			if(m_Listener == null)
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