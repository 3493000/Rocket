using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter;

namespace Hunter
{
    public class InitModuleNode : ExecuteNode
    {
        public override void OnBegin()
        {
            Log.i("ExecuteNode:" + GetType().Name);
            AdsMgr.S.InitAllAdData();
            GameMgr.S.AddCom<UIDataModule>();
            GameMgr.S.AddCom<InputModule>();
            GameMgr.S.AddCom<CommonResModule>();
            GameMgr.S.AddCom<GuideModule>();
            ColorModule.S.Init();
            GameMgr.S.AddCom<GameplayMgr>();
            //UIMgr.S.OpenTopPanel(EngineUI.GuidePanel, null);
            SignSystem.S.InitSignSystem();
            SecurityMgr.S.DoSecurityChecker();
            isFinish = true;
        }
    }
}
