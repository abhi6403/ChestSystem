using ChestSystem.StateMachine;
using UnityEngine;

namespace ChestSystem.Chest
{
    namespace ChestStates
    {
        public class UnlockedState<T> : IState where T : ChestController
        {
            public ChestController Owner { get; set; }
            private GenericStateMachine<T> stateMachine;

            public UnlockedState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

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
