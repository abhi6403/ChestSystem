using ChestSystem.Chest.ChestStates;
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
            States.Add(StateMachine.States.UNLOCKING, new UnlockingState<ChestController>(this,Owner));
            States.Add(StateMachine.States.LOCKED, new LockedState<ChestController>(this));
            States.Add(StateMachine.States.UNLOCKED, new UnlockedState<ChestController>(this));
            States.Add(StateMachine.States.OPENED, new OpenedState<ChestController>(this));
        }
    }
}
