using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestController
    {
        private ChestSO _chestSO;
        private ChestView _chestView;

        public ChestController(ChestSO chestSO)
        {
            _chestSO = chestSO;
            
        }

        private void IntializeChestView()
        {
            _chestView = Object.Instantiate(_chestView);
        }
    }
}
