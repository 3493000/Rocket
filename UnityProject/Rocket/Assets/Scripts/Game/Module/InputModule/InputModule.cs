using UnityEngine;
using System.Collections;
using Hunter;
using UnityEngine.SceneManagement;
using System;

namespace Hunter
{
    public class InputModule : AbstractModule
    {
        private IInputter m_KeyboardInputter;
        private KeyCodeTracker m_KeyCodeTracker;

        public override void OnComLateUpdate(float dt)
        {
            m_KeyboardInputter.LateUpdate();
            m_KeyCodeTracker.LateUpdate();
        }

        protected override void OnComAwake()
        {
            m_KeyCodeTracker = new KeyCodeTracker();
            m_KeyCodeTracker.SetDefaultProcessListener(ShowBackKeydownTips);
            m_KeyboardInputter = new KeyboardInputter();
            m_KeyboardInputter.RegisterKeyCodeMonitor(KeyCode.F1, null, OnClickF1, null);
            m_KeyboardInputter.RegisterKeyCodeMonitor(KeyCode.F2, null, OnClickF2, null);
            m_KeyboardInputter.RegisterKeyCodeMonitor(KeyCode.F3, null, OnClickF3, null);
            m_KeyboardInputter.RegisterKeyCodeMonitor(KeyCode.F4, null, OnClickF4, null);
            m_KeyboardInputter.RegisterKeyCodeMonitor(KeyCode.F5, null, OnClickF5, null);
            m_KeyboardInputter.RegisterKeyCodeMonitor(KeyCode.F6, null, OnClickF6, null);
        }

        private void ShowBackKeydownTips()
        {
            FloatMessage.S.ShowMsg(TDLanguageTable.Get("Press Again to Quit"));
        }

        private void OnClickF1()
        {
           
        }

        private void OnClickF2()
        {
           
        }

        private void OnClickF3()
        {
            
        }

        private void OnClickF4()
        {
           

        }

        private void OnClickF5()
        {

        }

        private void OnClickF6()
        {
           

        }

        private void OnSceneLoadResult(string sceneName, bool result)
        {
          
        }
    }
}
