using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public class SimulationMgr : TMonoSingleton<SimulationMgr>
    {
        private ISimulateControl[] m_SimulateControlList;        
        public void StartSimulate()
        {
            if (m_SimulateControlList == null)
            {
                m_SimulateControlList = GetComponentsInChildren<ISimulateControl>();
            }

            for (int i = 0; i < m_SimulateControlList.Length; ++i)
            {
                m_SimulateControlList[i].StartSimulate();
            }
        }
    }
}
