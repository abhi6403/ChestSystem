using ChestSystem.Commands;
using ChestSystem.Event;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestController 
    {
        public ChestView _chestView { get; set; }
        public ChestModel _chestModel { get; set; }
        
        private ChestStateMachine _chestStateMachine;
        private ICommand _unlockChest;

        private Transform _chestContainer;
        
        public ChestController(ChestSO chestSO,Transform chestTransform)
        {
            _chestContainer = chestTransform;
            _chestModel = new ChestModel(chestSO);
            _chestModel.SetController(this);
            IntializeChestView();
            _chestView.SetController(this);
            
            
            CreateChestStateMachine();
            GenerateRandomGems();
            GenerateRandomCoins();
            
            _chestStateMachine.ChangeState(ChestState.LOCKED);
            _unlockChest = new UnlockChestWithGems();
        }
        
        private void IntializeChestView()
        {
            _chestView = Object.Instantiate(_chestModel._chestPrefab, _chestContainer);
            _chestView._chestClosedSprite.sprite = _chestModel._chestClosedSprite;
            _chestView._chestOpenSprite.sprite = _chestModel._chestOpenSprite;
            _chestView._chestStatusText.text = _chestModel._chestState.ToString();
        }
        
        public void Update()
        {
            CheckForTimeLeft();
           _chestStateMachine.Update();
        }
        
        private void CreateChestStateMachine() => _chestStateMachine = new ChestStateMachine(this);
       
        public void ChestButtonPressedInLockedState()
        {
            EventService.Instance.OnChestButtonClickedInLockedState.InvokeEvent(_chestModel);
        }
        public void ChestButtonPressedInUnlockedState()
        {
            EventService.Instance.OnChestButtonClickedInUnlockedState.InvokeEvent(_chestModel);
        }

        public void ChestButtonPressedInOpenState()
        {
            EventService.Instance.OnChestButtonClickedInOpenedState.InvokeEvent(_chestModel);
        }
        public void UnlockChest()
        {
            SetStateMachineState(ChestState.UNLOCKING);
        }

        private void CheckForTimeLeft()
        {
            if (_chestModel._chestTimer <= 0 && _chestModel._chestState == ChestState.UNLOCKING)
            {
                SetStateMachineState(ChestState.UNLOCKED);
                EventService.Instance.UnlockChest.InvokeEvent(this,_unlockChest);
            }
        }

        public void UnlockWithGems()
        {
            EventService.Instance.UnlockChest.InvokeEvent(this, _unlockChest);
        }

        public void UndoUnlockWithGems() => EventService.Instance.UndoButtonClicked.InvokeEvent(this);
        public void SetStateMachineState(ChestState state)
        {
            _chestStateMachine.ChangeState(state);
        }
        private void GenerateRandomCoins()
        {
            _chestModel._chestCurrentCoins = Random.Range(_chestModel._chestMaxCoins, _chestModel._chestMinCoins);
        }

        private void GenerateRandomGems()
        {
            _chestModel._chestCurrentGems = Random.Range(_chestModel._chestMaxGems, _chestModel._chestMinGems);
        }
    }
}
