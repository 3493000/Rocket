using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameObject = UnityEngine.GameObject;
using Hunter;

namespace Hunter
{

    public class GameControl : TMonoSingleton<GameControl>
    {
        [SerializeField]
        private Transform m_GameControlRoot;
        private ResLoader m_ResLoader;

        private bool m_IsGameOver = false;
       
        private bool m_IsOutOfFuel = false;
      
        private bool m_IsGameStarted = false;

        public bool IsGameOver
        {
            set { m_IsGameOver = value; }
            get { return m_IsGameOver; }
        }

        public bool IsOutOfFuel
        {
            set { m_IsOutOfFuel = value; }
            get { return m_IsOutOfFuel; }
        }

        public bool IsGameStarted
        {
            set { m_IsGameStarted = value; }
            get { return m_IsGameStarted; }
        }

        private FSMSystem fsm;
        private FSMState state;

        public void InitMgr()
        {
            m_ResLoader = ResLoader.Allocate("GameControl");
            MakeFSM();
        }

        private void MakeFSM()
        {
            //fsm = new FSMSystem();

            //state = new InitState(fsm);
            //state.AddTransition(Transition.StartGameState,StateID.StartGameState);
            //fsm.AddState(state);

            //state = new StartGameState(fsm);
            //state.AddTransition(Transition.GamingState, StateID.GamingState);
            //fsm.AddState(state);

            //state = new GamingState(fsm);
            //state.AddTransition(Transition.GameOverState, StateID.GameOverState);
            ////state.AddTransition(Transition.InitState, StateID.InitState);
            //fsm.AddState(state);

            //state = new GameOverState(fsm);
            //state.AddTransition(Transition.InitState, StateID.InitState);
            //fsm.AddState(state);

            //fsm.Start(StateID.InitState);
            
        }

        private void Update()
        {
            if (fsm != null)
            {
                fsm.CurrentState.Reason();
                fsm.CurrentState.Act();
            }
        }

        //public void ChangeStateToGameOverState()
        //{
        //    if (fsm.CurrentState.GetType() == typeof(GamingState))
        //    {
        //        fsm.PerformTransition(Transition.GameOverState);
        //    }
        //}
    }
}
