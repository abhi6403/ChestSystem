using System.Collections.Generic;
using UnityEngine;
using ChestSystem.Chest;
using UnityEditor.VersionControl;

namespace ChestSystem.StateMachine
{
    public class GenericStateMachine<T> where T : ChestController
    {
        protected T Owner;
        protected IState currentState;
        protected Dictionary<States, IState> States = new Dictionary<States, IState>();
        
        public GenericStateMachine(T owner) => Owner = owner;
        
        public void Update() => currentState?.Update();

        protected void ChangeState(IState newState)
        {
            currentState?.OnStateExit();
            currentState = newState;
            currentState?.OnStateEnter();
        }

        public void ChangeState(States newState) => ChangeState(States[newState]);

        protected void SetOwer()
        {
            foreach (IState state in States.Values)
            {
                state.Owner = Owner;
            }
        }
    }
}
