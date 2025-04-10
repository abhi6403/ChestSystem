using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestController
    {
        private ChestView _chestView;
        private ChestModel _chestModel;

        private Transform _chestContainer;
        public ChestController(ChestSO chestSO,Transform chestTransform)
        {
            _chestModel = new ChestModel(chestSO);
            _chestModel.SetController(this);
            _chestContainer = chestTransform;
            IntializeChestView();
            _chestView.SetController(this);
        }

        private void IntializeChestView()
        {
            _chestView = Object.Instantiate(_chestModel._chestPrefab, _chestContainer);
            _chestView._chestClosedSprite.sprite = _chestModel._chestClosedSprite;
            _chestView._chestOpenSprite.sprite = _chestModel._chestOpenSprite;
            _chestView._chestTimerText.text = _chestModel._chestTimer.ToString();
            _chestView._chestStatusText.text = _chestModel._chestState.ToString();
        }
    }
}
