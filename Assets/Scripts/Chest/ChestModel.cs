using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestModel
    {
        public ChestController _chestController { get; private set; }
        public ChestState _chestState { get; private set; }
        public ChestView _chestPrefab { get; private set; }
        
        public Sprite _chestClosedSprite { get; private set; }
        public Sprite _chestOpenSprite { get; private set; }
        
        public float _chestTimer { get; private set; }
        public float _constChestTimer { get; private set; }
        
        public int _chestMaxCoins { get; private set; }
        public int _chestMinCoins { get; private set; }
        public int _chestMaxGems { get; private set; }
        public int _chestMinGems { get; private set; }
        
        public int _chestCurrentCoins { get; set; }
        public int _chestCurrentGems { get; set; }
        public int _gemsRequiredToUnlock { get; set; }
        
        public ChestModel(ChestSO chestSO)
        {
            _chestPrefab = chestSO._chestPrefab;
            _chestClosedSprite = chestSO._chestClosedImage;
            _chestOpenSprite = chestSO._chestOpenImage;
            _chestTimer = chestSO._chestTimer;
            _constChestTimer = chestSO._chestTimer;
            
            _chestState = ChestState.LOCKED;
            
            _chestMaxCoins = chestSO._chestRewards._maxCoins;
            _chestMinCoins = chestSO._chestRewards._minCoins;
            _chestMaxGems = chestSO._chestRewards._maxGems;
            _chestMinGems = chestSO._chestRewards._minGems;

            _chestCurrentCoins = 0;
            _chestCurrentGems = 0;
        }
        
        public void SetController(ChestController controllerToSet) => _chestController = controllerToSet;
        
        public void SetChestState(ChestState stateToSet) => _chestState = stateToSet;
        
        public void SetChestTimer(float chestTimerToSet) => _chestTimer = chestTimerToSet;
    }
}
