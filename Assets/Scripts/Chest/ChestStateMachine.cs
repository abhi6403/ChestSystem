using System.Collections.Generic;
using ChestSystem.Chest.ChestStates;
using ChestSystem.StateMachine;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestStateMachine
    {
        private IState currentState;
        public Dictionary<ChestState, IState> states;
        private ChestState currentChestState;
        public ChestStateMachine(ChestController Owner)
        {
            CreateStates(Owner);
        }

        private void CreateStates(ChestController Owner)
        {
            states = new Dictionary<ChestState, IState>()
            {
                { ChestState.LOCKED, new LockedState(this) },
                { ChestState.UNLOCKING, new UnlockingState(this, Owner) },
                { ChestState.UNLOCKED, new UnlockedState(this) },
                { ChestState.OPENED, new OpenedState(this) }
            };
        }
        
        public void ChangeState(ChestState newState)
        {
            if (states.ContainsKey(newState))
                ChangeState(states[newState]);
        }

        private void ChangeState(IState newState)
        {
            currentState?.OnStateExit();
            currentState = newState;
            currentState?.OnStateEnter();
        }

        public void Update() => currentState?.Update();

        public IState GetCurrentState() => currentState;

        public Dictionary<ChestState, IState> GetStates() => states;
    }
}
