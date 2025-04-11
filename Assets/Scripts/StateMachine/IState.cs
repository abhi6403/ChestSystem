using ChestSystem.Chest;
using UnityEngine;

namespace ChestSystem.StateMachine
{
    public interface IState
    {
        public ChestController Owner { get; set; }
        public void OnStateEnter();
        public void Update();
        public void OnStateExit();
    }
}
