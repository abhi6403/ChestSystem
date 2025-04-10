using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestController
    {
        private ChestSO _chestSO;
        private ChestView _chestView;

        private Transform _chestContainer;
        public ChestController(ChestSO chestSO,Transform chestTransform)
        {
            _chestSO = chestSO;
            _chestContainer = chestTransform;
            IntializeChestView();
        }

        private void IntializeChestView()
        {
            _chestView = Object.Instantiate(_chestSO._chestPrefab, _chestContainer);
            _chestView._chestOpenSprite.sprite = _chestSO._chestOpenImage;
            _chestView._chestClosedSprite.sprite = _chestSO._chestClosedImage;
            _chestView._chestTimerText.text = _chestSO._chestTimer.ToString();
            _chestView._chestStatusText.text = ChestState.LOCKED.ToString();
        }
    }
}
