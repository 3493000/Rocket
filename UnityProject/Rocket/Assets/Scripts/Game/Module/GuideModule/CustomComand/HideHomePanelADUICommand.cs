using UnityEngine;

using System;

namespace Hunter
{
    public class HideHomePanelADUICommand : AbstractGuideCommand
    {
        //private IUINodeFinder m_Finder;
        //private bool m_NeedClose = true;
        //private Vector3 m_Offset;

        public override void SetParam(object[] pv)
        {
            //if (pv.Length == 0)
            //{
            //    Log.w("GuideHandCommand Init With Invalid Param.");
            //    return;
            //}

            //try
            //{
            //    m_Finder = pv[0] as IUINodeFinder;

            //    if (pv.Length > 1)
            //    {
            //        m_NeedClose = Helper.String2Bool((string)pv[1]);
            //    }

            //    if (pv.Length > 2)
            //    {
            //        m_Offset = Helper.String2Vector3((string)pv[2], '|');
            //    }

            //}
            //catch (Exception e)
            //{
            //    Log.e(e);
            //}
        }

        protected override void OnStart()
        {
            //RectTransform targetNode = m_Finder.FindNode(false) as RectTransform;
            //if (targetNode == null)
            //{
            //    return;
            //}


         
            //CheckFirstFruit();        
        }

        protected override void OnFinish(bool forceClean)
        {
            //PlayerInfoMgr.data.SetPlayerState();
            //EventSystem.S.Send(EventID.OnHideHomePanelSliderUI, false);//显示升级条UI

            //UIMgr.S.ClosePanelAsUIID(UIID.TapHandPanel);
        }

        private void CheckFirstFruit(int key, params object[] param)
        {
            //等待水果到达刀正下方，

            //再打开mask手势引导面板，时间暂停引导玩家切割
            //Time.timeScale = 0;
            //  UIMgr.S.OpenTopPanel(UIID.TapHandPanel,null);
        }

        private void OnTapToCut(int key, params object[] param)
        {
            FinishStep();
        }


    }
}
