using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestController
    {
        private ChestView _chestView;
        private ChestModel _chestModel;

        private Transform _chestContainer;

        private float _chestTimer;
        public ChestController(ChestSO chestSO,Transform chestTransform)
        {
            _chestContainer = chestTransform;
            _chestModel = new ChestModel(chestSO);
            _chestModel.SetController(this);
            IntializeChestView();
            _chestView.SetController(this);
            _chestTimer = _chestModel._chestTimer;
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
            StartTimerToUnlockTheChest();
        }

        private void StartTimerToUnlockTheChest()
        {
            _chestTimer -= Time.deltaTime;
            _chestModel.SetChestTimer(_chestTimer);

            int totalSeconds = Mathf.FloorToInt(_chestTimer);
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;
            
            _chestView._chestTimerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }
    }
}
