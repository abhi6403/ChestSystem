using ChestSystem.StateMachine;
using UnityEngine;

namespace ChestSystem.Chest
{
    namespace ChestStates
    {
        public class LockedState : IState
        {
            public ChestController Owner { get; set; }
            private ChestStateMachine stateMachine;

            public LockedState(ChestStateMachine stateMachine) => this.stateMachine = stateMachine;

            public void OnStateEnter()
            {
                
            }

            public void Update()
            {
                
            }

            public void OnStateExit()
            {
                
            }
        }
    }
}
