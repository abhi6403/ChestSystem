using ChestSystem.Chest;
using ChestSystem.Event;
using ChestSystem.Player;
using UnityEngine;

namespace ChestSystem.Commands
{
    public class UnlockChestWithGems : ICommand
    {
        private ChestController _chestController;
        private PlayerController _playerController;
        private int _gemsRequiredToUnlock;
        private int _gemsCount;

        public void Execute(PlayerService playerService, ChestController chestController)
        {
            _playerController = playerService.GetPlayerController();
            _chestController = chestController;
            _gemsRequiredToUnlock = _chestController._chestModel._gemsRequiredToUnlock;
            _gemsCount = _playerController._playerModel._gems;

            if (_gemsRequiredToUnlock <= _gemsCount)
            {
                int _gemsLeft = _gemsCount - _gemsRequiredToUnlock;
                _chestController._chestModel.SetChestState(ChestState.UNLOCKED);
                _playerController.UpdateGems(_gemsLeft);
                _chestController.SetStateMachineState(ChestState.UNLOCKED);
            }
            else
            {
                EventService.Instance.UnableToUnlockChest.InvokeEvent();
            }
        }

        public void Undo()
        {
            _playerController.UpdateGems(_gemsCount);
            _chestController._chestModel.SetChestState(ChestState.LOCKED);
            _chestController.SetStateMachineState(ChestState.LOCKED);
        }
    }
}
