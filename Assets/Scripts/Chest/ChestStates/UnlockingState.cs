using UnityEngine;
using IState = ChestSystem.StateMachine.IState;

namespace ChestSystem.Chest
{
    namespace ChestStates
    {
        public class UnlockingState : IState 
        {
            public ChestController Owner { get; set; }
            private ChestStateMachine stateMachine;

            private float _chestTimer;

            public UnlockingState(ChestStateMachine stateMachine, ChestController controller)
            {
                this.stateMachine = stateMachine;
                Owner = controller;
            }

            public void OnStateEnter()
            {
                _chestTimer = Owner._chestModel._chestTimer;
                Owner._chestModel.SetChestState(ChestState.UNLOCKING);
                Owner._chestView._chestStatusText.text = Owner._chestModel._chestState.ToString();
            }

            public void Update()
            {
                StartTimerToUnlockTheChest();
                CalculateRequiredGems();
            }

            public void OnStateExit()
            {
                if (_chestTimer == 0)
                {
                    Owner._chestModel.SetChestState(ChestState.UNLOCKED);
                    Owner._chestView._chestStatusText.text = Owner._chestModel._chestState.ToString();
                }
                else
                {
                    Owner._chestModel.SetChestState(ChestState.LOCKED);
                    Owner._chestView._chestStatusText.text = Owner._chestModel._chestState.ToString();
                }
            }
            private void StartTimerToUnlockTheChest()
            {
                _chestTimer -= Time.deltaTime;
                Owner._chestModel.SetChestTimer(_chestTimer);

                int totalSeconds = Mathf.FloorToInt(_chestTimer);
                int hours = totalSeconds / 3600;
                int minutes = (totalSeconds % 3600) / 60;
                int seconds = totalSeconds % 60;

                Owner._chestView._chestTimerText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
            }

            private void CalculateRequiredGems()
            {
                float gemsNeeded = _chestTimer / 600f;
                Owner._chestModel._gemsRequiredToUnlock = Mathf.CeilToInt(gemsNeeded);
            }
        }
    }
}