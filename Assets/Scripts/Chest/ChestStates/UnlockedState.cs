using ChestSystem.StateMachine;

namespace ChestSystem.Chest
{
    namespace ChestStates
    {
        public class UnlockedState : IState
        {
            public ChestController Owner { get; set; }
            private ChestStateMachine stateMachine;

            public UnlockedState(ChestStateMachine stateMachine, ChestController controller)
            {
                Owner = controller;
                this.stateMachine = stateMachine;
            }

            public void OnStateEnter()
            {
                SoundManager.Instance.Play(Sounds.UNLOCKED);
                Owner._chestView._chestTimerText.gameObject.SetActive(false);
                Owner._chestModel.SetChestState(ChestState.UNLOCKED);
                Owner._chestView._chestStatusText.text = Owner._chestModel._chestState.ToString();
            }

            public void Update() {}

            public void OnStateExit() {}
        }
    }
}
