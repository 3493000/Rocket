using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hunter;

namespace Hunter
{
    public class GuideModule : AbstractModule
    {
        public void StartGuide()
        {
            if (!AppConfig.S.isGuideActive)
            {
                return;
            }
            InitCustomTrigger();
            InitCustomCommand();
            GuideMgr.S.StartGuideTrack();
        }

        private void InitCustomCommand()
        {
            //GuideMgr.S.RegisterGuideCommand(typeof(HideHomePanelADUICommand));
            //GuideMgr.S.RegisterGuideCommand(typeof(HandGuideCommand));
            //GuideMgr.S.RegisterGuideCommand(typeof(ButtonActiveSkillCommand));
        }

        protected override void OnComAwake()
        {
                
        }

        protected void InitCustomTrigger()
        {
            //GuideMgr.S.RegisterGuideTrigger(typeof(FirstStartTrigger));
            //GuideMgr.S.RegisterGuideTrigger(typeof(MoneyTrigger));
        }

        
    }
}
