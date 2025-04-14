using ChestSystem.Chest;
using ChestSystem.Main;
using ChestSystem.Event;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.UI
{
    namespace ChestStateUI
    {
        public class UnlockChestUIController : MonoBehaviour
        {
            [SerializeField] private Image _chestImage;
            [SerializeField] private Button _cancelButton;
            [SerializeField] private Button _unlockButton;
            [SerializeField] private Button _unlockWithGemsButton;
            [SerializeField] private TextMeshProUGUI _unlockWithgemsText;
            
            private ChestController _chestController;
            private void Start() => SubscribeToEvents();
            private void SubscribeToEvents()
            {
                _cancelButton.onClick.AddListener(DisableUI);
                _unlockButton.onClick.AddListener(OnUnlockButtonClicked);
                _unlockWithGemsButton.onClick.AddListener(OnUnlockWithGemsButtonClicked);
            }
            public void SetChestController(ChestController chestController)
            {
                _chestController = chestController;
            }
            
            public void InitializeImage(ChestModel chestModel)
            {
                _chestImage.sprite = chestModel._chestClosedSprite;
            }
            private void OnUnlockWithGemsButtonClicked()
            {
               _chestController.UnlockWithGems();
            }
            public void ShowUnlockWithGemsButton()
            {
                _unlockWithgemsText.text = "Use "+ _chestController._chestModel._gemsRequiredToUnlock + " Gems";
            }
            private void DisableUI()
            {
                gameObject.SetActive(false);
            }

            private void OnUnlockButtonClicked()
            { 
                _chestController.UnlockChest();
                DisableUI();
            }
        }
    }
}
