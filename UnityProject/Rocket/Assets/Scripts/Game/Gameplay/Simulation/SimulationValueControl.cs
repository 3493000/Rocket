using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{

    public class MultipleValueWrap
    {
        public Action On_ValueUpdateEvent;

        protected float m_MultipleValue;

        public float value
        {
            get { return m_MultipleValue; }
        }

        protected void FireValueUpdateEvent()
        {
            if (On_ValueUpdateEvent != null)
            {
                On_ValueUpdateEvent();
            }
        }

        public MultipleValueWrap(float multipleValue)
        {
            m_MultipleValue = multipleValue;
        }

        public void AddMultipleValue(float value)
        {
            m_MultipleValue += value;
            FireValueUpdateEvent();
        }

        public void SetMultipleValue(float value)
        {
            m_MultipleValue = value;
            FireValueUpdateEvent();
        }
    }

    public class SimulationValueControl : TSingleton<SimulationValueControl>
    {

        public MultipleValueWrap starPrice = new MultipleValueWrap(1);
        public MultipleValueWrap BultgangValue = new MultipleValueWrap(1);
        public MultipleValueWrap hammerSpeed = new MultipleValueWrap(1);

        public MultipleValueWrap tapMultiple = new MultipleValueWrap(1);
        public MultipleValueWrap noteSpeed = new MultipleValueWrap(1);
         
    }
}
