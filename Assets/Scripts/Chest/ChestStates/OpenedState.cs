using ChestSystem.StateMachine;
using UnityEngine;

namespace ChestSystem.Chest
{
    namespace ChestStates
    {
        public class OpenedState<T> : IState where T : ChestController
        {
            public ChestController Owner { get; set; }
            private GenericStateMachine<T> stateMachine;

            public OpenedState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

            public void OnStateEnter()
            {
                
            }

            public void Update()
            {
                
            }

            public void OnStateExit()
            {
                
            }

            private int CalculateRandomCoinsFromChest()
            {
                return UnityEngine.Random.Range(Owner._chestModel._chestMaxCoins, Owner._chestModel._chestMinCoins);
            }
        }
    }
}