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
                SoundManager.Instance.Play(Sounds.LOCKED);
                Owner._chestView._chestTimerText.gameObject.SetActive(true);
                _chestTimer = Owner._chestModel._constChestTimer;
                SetTimerText();
            }

            public void Update()
            {
                CalculateRequiredGems();
            }

            public void OnStateExit() {}

            private void SetTimerText()
            {
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
