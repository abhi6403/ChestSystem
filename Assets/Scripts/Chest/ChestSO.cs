using System;
using UnityEngine;

namespace ChestSystem.Chest
{
    [CreateAssetMenu(fileName = "Create New Chest", menuName = "Scriptable Objects/ChestScriptableObject")]

    public class ChestSO : ScriptableObject
    {
        public Sprite _chestClosedImage;
        public Sprite _chestOpenImage;
        public ChestType _chestType;
        public ChestRewards _chestRewards;
        public float _chestTimer;
        public ChestView _chestPrefab;

        [Serializable]
        public class ChestRewards
        {
            public int _minCoins;
            public int _maxCoins;
            public int _minGems;
            public int _maxGems;
        }

        [Serializable]
        public enum ChestType
        {
            COMMON,
            RARE,
            EPIC,
            LEGENDARY
        }
    }
}
