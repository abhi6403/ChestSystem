using System.Collections;
using ChestSystem.Event;
using Unity.VisualScripting;
using UnityEngine;
using IState = ChestSystem.StateMachine.IState;

namespace ChestSystem.Chest
{
    namespace ChestStates
    {
        public class OpenedState : IState 
        {
            public ChestController Owner { get; set; }
            private ChestStateMachine stateMachine;

            public OpenedState(ChestStateMachine stateMachine, ChestController controller)
            {
                Owner = controller;
                this.stateMachine = stateMachine;
            }

            public void OnStateEnter()
            {
                SoundManager.Instance.Play(Sounds.COLLECTED);
                AddGemsToPlayer();
                AddCoinsToPlayer();
                
            }

            public void Update()
            {
                
            }

            public void OnStateExit()
            {
                
            }

            private void AddGemsToPlayer()
            {
                int temp = Owner._chestModel._chestCurrentGems;
                EventService.Instance.OnGemsCollected.InvokeEvent(temp);
            }

            private void AddCoinsToPlayer()
            {
                int temp = Owner._chestModel._chestCurrentCoins;
                EventService.Instance.OnCoinsCollected.InvokeEvent(temp);
            }
        }
    }
}