using System;
using ChestSystem.Event;
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
            SetChestStatusText();
        }
        public void ProcessButtonClicked()
        {
            if (_chestController._chestModel._chestState == ChestState.LOCKED || _chestController._chestModel._chestState == ChestState.UNLOCKING)
            {
                _chestController.ChestButtonPressedInLockedState();
            }else if (_chestController._chestModel._chestState == ChestState.UNLOCKED)
            {
                _chestController.ChestButtonPressedInUnlockedState();
            }else if (_chestController._chestModel._chestState == ChestState.OPENED)
            {
                _chestController.ChestButtonPressedInOpenState();
            }
        }

        public void SetChestStatusText()
        {
            _chestStatusText.text = _chestController._chestModel._chestState.ToString();
        }
    }
}
