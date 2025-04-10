using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestModel
    {
        public ChestController _chestController { get; private set; }
        
        public Sprite _chestClosedSprite { get; private set; }
        public Sprite _chestOpenSprite { get; private set; }
        
        public float _chestTimer { get; private set; }
        public ChestState _chestState { get; private set; }
        public ChestView _chestPrefab { get; private set; }
        public void SetController(ChestController controllerToSet) => _chestController = controllerToSet;
        
        public void SetChestState(ChestState stateToSet) => _chestState = stateToSet;

        public ChestModel(ChestSO chestSO)
        {
            _chestPrefab = chestSO._chestPrefab;
            _chestClosedSprite = chestSO._chestClosedImage;
            _chestOpenSprite = chestSO._chestOpenImage;
            _chestTimer = chestSO._chestTimer;
            _chestState = ChestState.LOCKED;
        }
    }
}
