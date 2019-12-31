using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Hunter;
using DG.Tweening;
using HedgehogTeam.EasyTouch;


namespace Hunter
{

    public class CameraControl : ISimulateControl
    {
        private static CameraControl m_Instance;
        [SerializeField]
        private Camera m_Camera;

        public static CameraControl S
        {
            get { return m_Instance; }
        }

        public override void StartSimulate()
        {
            m_Instance = this;
        }

        void Awake()
        {
         
        }

        void FixedUpdate()
        {
           
        }

        void LateUpdate()
        {
        
        }
    }
}
