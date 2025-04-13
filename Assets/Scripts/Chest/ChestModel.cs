using ChestSystem.StateMachine;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestModel
    {
        public ChestController _chestController { get; private set; }
        
        public Sprite _chestClosedSprite { get; private set; }
        public Sprite _chestOpenSprite { get; private set; }
        
        public float _chestTimer { get; private set; }
        public States _chestState { get; private set; }
        public ChestView _chestPrefab { get; private set; }
        
        public int _chestMaxCoins { get; private set; }
        public int _chestMinCoins { get; private set; }
        public int _chestMaxGems { get; private set; }
        public int _chestMinGems { get; private set; }
        
        public int _chestCurrentCoins { get; set; }
        public int _chestCurrentGems { get; set; }
        public void SetController(ChestController controllerToSet) => _chestController = controllerToSet;
        
        public void SetChestState(States stateToSet) => _chestState = stateToSet;
        
        public void SetChestTimer(float chestTimerToSet) => _chestTimer = chestTimerToSet;

        public ChestModel(ChestSO chestSO)
        {
            _chestPrefab = chestSO._chestPrefab;
            _chestClosedSprite = chestSO._chestClosedImage;
            _chestOpenSprite = chestSO._chestOpenImage;
            _chestTimer = chestSO._chestTimer;
            _chestState = States.LOCKED;
            _chestMaxCoins = chestSO._chestRewards._maxCoins;
            _chestMinCoins = chestSO._chestRewards._minCoins;
            _chestMaxGems = chestSO._chestRewards._maxGems;
            _chestMinGems = chestSO._chestRewards._minGems;

            _chestCurrentCoins = 0;
            _chestCurrentGems = 0;
        }
    }
}
