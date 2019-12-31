using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter;
using System;
using UnityEngine.UI;
using DG.Tweening;

namespace Hunter
{
    public class GameplayMgr : AbstractModule
    {
        public static GameplayMgr S = null;
        private GameplayRoot m_PlayRoot;

        protected override void OnComAwake()
        {
            S = this;
            LoadGamePlayRoot();
        }

        private void LoadGamePlayRoot()
        {
            if (m_PlayRoot == null)
            {
                GameplayRoot root = GameObject.FindObjectOfType<GameplayRoot>();
                if (root == null)
                {
                    root = LoadRootFromRes();
                }
                m_PlayRoot = root;

                if(m_PlayRoot == null)
                {
                    Log.e("Error : GamePlay root  is Null");
                    return;
                }
            }
        }

        private GameplayRoot LoadRootFromRes()
        {
            string name = "GamePlayRoot";
            ResLoader loader = ResLoader.Allocate("GameplayMgr",null);
            loader.Add2Load(name);
            loader.LoadSync();

            IRes res = ResMgr.S.GetRes(name, false);
            if (res == null || res.asset == null)
            {
                loader.Recycle2Cache();
                return null;
            }

            GameObject prefab = res.asset as GameObject;
            if(prefab == null)
            {
                loader.Recycle2Cache();
                return null;
            }

            GameObject root = GameObject.Instantiate(prefab);
            //loader.Recycle2Cache();
            return root.GetComponent<GameplayRoot>();
        }

        private void OnApplicationFocusChange(int key, params object[] args)
        {
            bool focusState = (bool)args[0];

            if (focusState)
            {
                return;
            }

        }

        public void StartGame()
        {
            //1.Load Info
            PlayerInfoMgr mgr = new PlayerInfoMgr();
            PurchaseModule.S.Init();
            //2.启动Simulation
            SimulationMgr.S.StartSimulate();
            EffectControl.S.InitMgr();
        }

    }
}