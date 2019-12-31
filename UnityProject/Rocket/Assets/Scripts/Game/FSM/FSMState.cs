using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter;

namespace Hunter
{
    public enum Transition
    {  
        //状态转换的条件
        NullTransition =0,
        InitState,
        StartGameState,
        GamingState,
        GameOverState,
    } 
    public enum StateID
    { 
        //状态ID
        NullStateID =0,
        InitState,
        StartGameState,
        GamingState,
        GameOverState,
    }

    public abstract class FSMState
    {
        protected StateID stateID;
        protected FSMSystem fsm;
        public StateID State
        {
            get { return stateID; }
        }
        public FSMState(FSMSystem fsm)
        {
            this.fsm = fsm;
        }
        protected Dictionary<Transition,StateID> map=new Dictionary<Transition, StateID>();
        public void AddTransition(Transition trans, StateID id)
        {
            if (trans == Transition.NullTransition || id == StateID.NullStateID)
            {
                Debug.LogError("Transition or stateid is null");
                return;
            }
            if (map.ContainsKey(trans))
            {
                Debug.LogError("State:"+stateID+" is already has transition:"+trans);
                return;
            }
            map.Add(trans,id);
        }
        public void DeleteTransition(Transition trans)
        {
            if (map.ContainsKey(trans) == false)
            {
                Debug.LogWarning("The transition:"+trans+" you want to delete is not exist in map");
                return;
            }
            map.Remove(trans);
        }
        public StateID GetOutputState(Transition trans)
        {
            //根据传递过来的转换条件，判断一下是否可以发生转换
            if (map.ContainsKey(trans))
            {
                return map[trans];
            }
            return StateID.NullStateID;
        }
        public virtual void DoBeforeEntering()
        {
            //在进入当前状态之前，需要做的事情
        }
        public virtual void DoBeforeLeaving()
        {
            //在离开当前状态之前，需要做的事情
        }
        public abstract void Act();// 这个方法决定在当前状态的执行
        public abstract void Reason();// 这个方法决定状态是否应该转换到列表中的另一个状态
    }
}

