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

            private float _chestTimer;
            public LockedState(ChestStateMachine stateMachine, ChestController controller)
            {
                Owner = controller;
                this.stateMachine = stateMachine;
            }

            public void OnStateEnter()
            {
                _chestTimer = Owner._chestModel._chestTimer;
                SetTimerText();
            }

            public void Update()
            {
                CalculateRequiredGems();
            }

            public void OnStateExit()
            {
                
            }

            private void SetTimerText()
            {
                int totalSeconds = Mathf.FloorToInt(_chestTimer);
                int hours = totalSeconds / 3600;
                int minutes = (totalSeconds % 3600) / 60;
                int seconds = totalSeconds % 60;

                Owner._chestView._chestTimerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
            }
            
            private void CalculateRequiredGems()
            {
                float gemsNeeded = _chestTimer / 600f;
                Owner._chestModel._gemsRequiredToUnlock = Mathf.CeilToInt(gemsNeeded);
            }
        }
    }
}
