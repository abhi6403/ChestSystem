using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestService
    {
        private List<ChestSO> _chests;
        private Transform _chestsContainer;
        public ChestController _chestController{get; private set;}
        
        public void Initialize(List<ChestSO> chests, Transform chestsContainer)
        {
            _chests = chests;
            _chestsContainer = chestsContainer;
        }

        public void CreateChest()
        {
            _chestController = new ChestController(GetRandomChest(), _chestsContainer);
        }
        private ChestSO GetRandomChest()
        {
            return _chests[Random.Range(0, _chests.Count)];
        }
    }
}
