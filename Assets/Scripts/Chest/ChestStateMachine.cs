using ChestSystem.StateMachine;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestStateMachine : GenericStateMachine<ChestController>
    {
        public ChestStateMachine(ChestController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(StateMachine.States.UNLOCKING, new UnlockingState<ChestController>(this));
        }
    }
}
