using ChestSystem.StateMachine;
using UnityEngine;

namespace ChestSystem.Chest
{
    namespace ChestStates
    {
        public class UnlockedState : IState
        {
            public ChestController Owner { get; set; }
            private ChestStateMachine stateMachine;

            public UnlockedState(ChestStateMachine stateMachine) => this.stateMachine = stateMachine;

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
