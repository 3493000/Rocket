using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter;

namespace Hunter
{
    public class FSMSystem
    {
        //当前状态机下面有哪些状态
        private Dictionary<StateID, FSMState> states;
        //处于什么状态
        private FSMState currentState;
        public FSMState CurrentState
        {
            get { return currentState; }
        }
        public FSMSystem()
        {
            states = new Dictionary<StateID, FSMState>();
        }
        public void AddState(FSMState state)
        {
            //往状态机里面添加状态
            if (state == null)
            {
                Debug.LogError("The state you want to add is null");
                return;
            }
            if(states.ContainsValue(state))
            {
                Debug.LogError("The state:" + state.State + " you want to add has already been added.");
                return;
            }
            states.Add(state.State,state);
        }
        public void DeleteState(FSMState state)
        {
            //往状态机里面移除状态
            if (state == null)
            {
                Debug.LogError("The state you want to delete is null");
                return;
            }
            if (states.ContainsValue(state)==false)
            {
                Debug.LogError("The state:" + state.State + " you want to delete is not exist.");
                return;
            }
            states.Remove(state.State);
        }
        public void PerformTransition(Transition trans)
        {
            //控制状态之间的转换
            if (trans == Transition.NullTransition)
            {
                Debug.LogError("NullTransition is not allowed for a real transition.");
                return;
            }
           StateID id= currentState.GetOutputState(trans);
            if (id == StateID.NullStateID)
            {
                return;
            }
            FSMState state;
            states.TryGetValue(id,out state);
            currentState.DoBeforeLeaving();
            currentState = state;
            currentState.DoBeforeEntering();
        }
        public void Start(StateID id)
        {
            //设置默认状态，启动状态机
            FSMState state;
            bool isGet = states.TryGetValue(id, out state);
            if (isGet)
            {
                state.DoBeforeEntering();
                currentState = state;
            }
            else
            {
                Debug.LogError("The state "+ id+" is not exist in the fsm");
            }
        }
        public void Update()
        {
            if (currentState!=null)
            {
                currentState.Act();
                currentState.Reason();
            }           
        }
    }
}

