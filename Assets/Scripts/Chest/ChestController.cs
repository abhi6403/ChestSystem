using ChestSystem.StateMachine;
using ChestSystem.Event;
using ChestSystem.Main;
using ChestSystem.UI.ChestStateUI;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestController 
    {
        public ChestView _chestView { get; set; }
        public ChestModel _chestModel { get; set; }
        
        private ChestStateMachine _chestStateMachine;

        private Transform _chestContainer;

        
        public ChestController(ChestSO chestSO,Transform chestTransform)
        {
            _chestContainer = chestTransform;
            _chestModel = new ChestModel(chestSO);
            _chestModel.SetController(this);
            IntializeChestView();
            _chestView.SetController(this);
            CreateChestStateMachine();
            _chestStateMachine.ChangeState(ChestState.LOCKED);
            GenerateRandomGems();
            GenerateRandomCoins();
            Events();
        }

        private void Events()
        {
            
        }
        
        private void IntializeChestView()
        {
            _chestView = Object.Instantiate(_chestModel._chestPrefab, _chestContainer);
            _chestView._chestClosedSprite.sprite = _chestModel._chestClosedSprite;
            _chestView._chestOpenSprite.sprite = _chestModel._chestOpenSprite;
            _chestView._chestTimerText.text = _chestModel._chestTimer.ToString();
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
            _chestStateMachine.ChangeState(ChestState.UNLOCKING);
        }

        private void CheckForTimeLeft()
        {
            if (_chestModel._chestTimer <= 0 && _chestModel._chestState == ChestState.UNLOCKING)
            {
                _chestStateMachine.ChangeState(ChestState.UNLOCKED);
            }
        }

        
        public void GenerateRandomCoins()
        {
            _chestModel._chestCurrentCoins = UnityEngine.Random.Range(_chestModel._chestMaxCoins, _chestModel._chestMinCoins);
        }

        public void GenerateRandomGems()
        {
            _chestModel._chestCurrentGems = UnityEngine.Random.Range(_chestModel._chestMaxGems, _chestModel._chestMinGems);
        }
    }
}
