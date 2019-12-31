using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hunter;
using System;

namespace Hunter
{
    public class WorldUIPanel : AbstractPanel
    {
        public static WorldUIPanel S;
       
        [SerializeField]
        private Transform m_EffectRoot;
        [SerializeField]
        private Transform m_TestRoot;

        private Camera m_RootCamera;
        protected override void OnUIInit()
        {            
            S = this;

            m_RootCamera = GameObject.Find("UIRoot").GetComponent<UIRoot>().uiCamera;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Input.mousePosition;
                Vector3 EffectPos = GameExtensions.GetScreenPosition2UIPosition(Camera.main, m_RootCamera, pos, m_TestRoot);

                EffectControl.S.PlayEffect(m_EffectRoot, EffectPos, "Eff_Click");
            }
        }






    }
}