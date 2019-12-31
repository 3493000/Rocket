using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunter
{
    public class SoundControl : TMonoSingleton<SoundControl>
    {   
        public const string AddGold = "GetGold";
        public const string Button_Click = "buttonSound";
        public const string Gold_Rain = "GoldRain";
        public const string Level_Up = "LevelUp";
        public const string Turntable = "TurnTable";
        public const string Counter = "CounterSound";
        public const string Launch = "LaunchSound";
        public const string BGM = "BGM";

        private int m_cutShakeTimerId = -1;
        private int m_CutIndex = 0;

        public void InitMgr()
        {

        }

        public void PlayBGM()
        {
            AudioMgr.S.PlayBg(BGM);
        }

        public void PlayGoldRainSound()
        {
            PlaySound(Gold_Rain,1f);
        }

        public void PlayCounterSound()
        {
            PlaySound(Counter, 1f);
        }

        public void PlayLaunchSound()
        {
            PlaySound(Launch, 1f);
        }

        public void PlayButtonClickSound()
        {
            PlaySound(Button_Click, 1f);
        }

        public void PlayLevelUpSound()
        {
            PlaySound(Level_Up, 1f);
        }

        public void PlayTurnTableSound()
        {
            PlaySound(Turntable, 1f);
        }

        public void PlayGoldAddSound()
        {
            PlaySound(AddGold, 0.8f);
            OnShake();
        }

        public void PlaySound(string sound, float volume = 1)
        {
            // AudioMgr.S.isSoundEnable = true;
            if (!AudioMgr.S.isSoundEnable)
            {
                return;
            }
            int id = AudioMgr.S.PlaySound(sound);
            AudioMgr.S.SetVolume(id, volume);
           // OnShake();
        }

        private void OnShake()
        {
            if (Shake)
            {
                if (m_cutShakeTimerId == -1)
                {
                    CustomVibration.Vibrate(30);
                    m_cutShakeTimerId = Timer.S.Post2Scale((V) => { m_cutShakeTimerId = -1; }, 0.1F, 1);
                }
            }
        }

        public bool Shake
        {
            get
            {
                return PlayerPrefs.GetInt("Shake", 1) == 1 ? true : false;
            }

            set
            {
                int val = value ? 1 : 0;
                PlayerPrefs.SetInt("Shake", val);
            }
        }
    }
}

