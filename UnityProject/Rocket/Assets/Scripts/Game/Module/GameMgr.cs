using UnityEngine;
using System.Collections;
using Hunter;
using System;

namespace Hunter
{
    [TMonoSingletonAttribute("[Game]/GameMgr")]
    public class GameMgr : AbstractModuleMgr, ISingleton
    {
        private static GameMgr s_Instance;
        private int m_GameplayInitSchedule = 0;
        private int m_CutSpeedSkillRate=1;
        public int CutSpeedSkillRate
        {
            set { m_CutSpeedSkillRate = value; }
            get { return m_CutSpeedSkillRate; }
        }

        public static GameMgr S
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = MonoSingleton.CreateMonoSingleton<GameMgr>();
                }
                return s_Instance;
            }
        }

        public void InitGameMgr()
        {
            Log.i("Init[GameMgr]");
            
        }

        public void OnSingletonInit()
        {
            
        }

        protected override void OnActorAwake()
        {           
            ShowLogoPanel();
        }

        protected override void OnActorStart()
        {
            StartProcessModule module = AddMonoCom<StartProcessModule>();

            module.SetFinishListener(OnStartProcessFinish);            
        }

        protected void ShowLogoPanel()
        {
            UIDataModule.RegisterStaticPanel();

            Action a = OnLogoPanelFinish;

            UIMgr.S.OpenTopPanel(UIID.LogoPanel, null, a);
        }

        protected void OnLogoPanelFinish()
        {
            ++m_GameplayInitSchedule;
            TryStartGameplay();
        }

        protected void OnStartProcessFinish()
        {
            AdsMgr.S.PreloadAllAd();
            ++m_GameplayInitSchedule;
            TryStartGameplay();
            //ResUpdateMgr.S.CheckPackage()
        }

        protected void TryStartGameplay()
        {            
            if (m_GameplayInitSchedule < 2)
            {
                return;
            }

           // AdsMgr.S.PreloadAllAd();

            // 1、游戏第一次启动
            DataAnalysisMgr.S.CustomEventLifeCircleSingle("first_game_open");
           // Application.targetFrameRate =60;
            GameplayMgr.S.StartGame();

            //AdsMgr.S.ShowBannerAd(Define.AD_HOME_BANNER, AdSize.Banner, AdPosition.Top);

            UIMgr.S.ClosePanelAsUIID(UIID.LogoPanel);
            // CameraControl.S.OpenCamera();
            //UIMgr.S.OpenPanel(UIID.HomePanel);

            GameControl.S.InitMgr();
  
            GameMgr.S.GetCom<GuideModule>().StartGuide();
           

            RemoteConfigMgr.S.StartChecker(null);
        }

        private void OnApplicationQuit()
        {
            PlayerInfoMgr.data.ResetLeaveTime();
            Log.i("离开时记录时间");
        }

    }
}
