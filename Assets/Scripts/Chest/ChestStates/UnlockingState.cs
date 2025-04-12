using ChestSystem.Chest;
using ChestSystem.StateMachine;
using UnityEngine;

namespace ChestSystem.Chest
{
    namespace ChestStates
    {
        public class UnlockingState<T> : IState where T : ChestController
        {
            public ChestController Owner { get; set; }
            private GenericStateMachine<T> stateMachine;

            private float _chestTimer;

            public UnlockingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

            public void OnStateEnter()
            {
                _chestTimer = Owner._chestModel._chestTimer;
            }

            public void Update()
            {
                StartTimerToUnlockTheChest();
            }

            public void OnStateExit()
            {

            }

            private void StartTimerToUnlockTheChest()
            {
                _chestTimer -= Time.deltaTime;
                Owner._chestModel.SetChestTimer(_chestTimer);

                int totalSeconds = Mathf.FloorToInt(_chestTimer);
                int hours = totalSeconds / 3600;
                int minutes = (totalSeconds % 3600) / 60;
                int seconds = totalSeconds % 60;

                Owner._chestView._chestTimerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
            }
        }
    }
}