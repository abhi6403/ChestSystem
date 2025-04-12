using System;
using ChestSystem.StateMachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Chest
{
    public class ChestView : MonoBehaviour
    {
        public ChestController _chestController { get; private set; }
        

        public Image _chestClosedSprite;
        public Image _chestOpenSprite;
        public TextMeshProUGUI _chestTimerText;
        public TextMeshProUGUI _chestStatusText;
        
        public Button _chestButton;
        
        public void SetController(ChestController controllerToSet) => _chestController = controllerToSet;

        
        public void Update()
        {
            _chestController.Update();
        }
        
        public void ChestButtonPressedInLockedState()
        {
            _chestController.ChestButtonPressedInLockedState();
        }
    }
}
