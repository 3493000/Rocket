using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter;
using DG.Tweening;

namespace Hunter
{
    [TMonoSingletonAttribute("[App]/ApplicationMgr")]
    public class ApplicationMgr : AbstractApplicationMgr<ApplicationMgr>
    {

        protected override void InitThirdLibConfig()
        {
           // Application.targetFrameRate = 40;
            DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
            //DOTween.defaultEaseType = Ease.Linear;
            //InitSDK();
            SDKMgr.S.Init();//sdk初始化入口
        }
        private void InitSDK()
        {
            BuglyMgr.S.Init();
            FacebookSocialAdapter.S.Init();
            DataAnalysisMgr.S.Init();
            //AdsMgr.S.Init();
            SocialMgr.S.Init();
        }
        protected override void InitAppEnvironment()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        protected override void StartGame()
        {
            GameMgr.S.InitGameMgr();
        }
    }
}
