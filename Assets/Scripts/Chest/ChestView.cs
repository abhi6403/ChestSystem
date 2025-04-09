using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Chest
{
    public class ChestView : MonoBehaviour
    {
        public ChestController _chestController { get; private set; }
        
        [SerializeField]
        private Image _chestClosedSprite;
        [SerializeField]
        private Image _chestOpenSprite;
        [SerializeField]
        private TextMeshProUGUI _chestTimerText;
        [SerializeField]
        private TextMeshProUGUI _chestStatusText;
        [SerializeField]
        private Button _chestButton;
        
        public void SetController(ChestController controllerToSet) => _chestController = controllerToSet;
    }
}
