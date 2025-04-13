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
            Events();
        }

        private void Events()
        {
            //EventService.Instance.OnUnlockButtonClicked.AddListener(UnlockChest);
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
           _chestStateMachine.Update();
        }
        
        private void CreateChestStateMachine() => _chestStateMachine = new ChestStateMachine(this);
       
        public void ChestButtonPressedInLockedState()
        {
            EventService.Instance.OnChestButtonPressedInLockedState.InvokeEvent(_chestModel);
        }

        public void UnlockChest()
        {
            _chestStateMachine.ChangeState(ChestState.UNLOCKING);
        }
    }
}
