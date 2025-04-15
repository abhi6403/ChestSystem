using ChestSystem.Chest;
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
            [SerializeField] private GameObject warningUI;
            [SerializeField] private Button _warningButton;
            
            private ChestController _chestController;
            private void Start() => SubscribeToEvents();
            private void SubscribeToEvents()
            {
                _cancelButton.onClick.AddListener(DisableUI);
                _unlockButton.onClick.AddListener(OnUnlockButtonClicked);
                _unlockWithGemsButton.onClick.AddListener(OnUnlockWithGemsButtonClicked);
                _warningButton.onClick.AddListener(OnWarningButtonClicked);
                
                EventService.Instance.UnableToUnlockChest.AddListener(WarningUI);
            }
            
            public void Initialize(ChestModel chestModel)
            {
                _chestImage.sprite = chestModel._chestClosedSprite;
                _chestController = chestModel._chestController;
            }
            private void OnUnlockWithGemsButtonClicked()
            {
                SoundManager.Instance.Play(Sounds.BUTTONCLICK);
               _chestController.UnlockWithGems();
            }
            public void ShowUnlockWithGemsButton()
            {
                _unlockWithgemsText.text = "Use "+ _chestController._chestModel._gemsRequiredToUnlock + " Gems";
            }

            private void WarningUI()
            {
                warningUI.SetActive(true);
            }

            private void OnWarningButtonClicked()
            {
                SoundManager.Instance.Play(Sounds.BUTTONCLICK);
                warningUI.SetActive(false);
            }
            private void DisableUI()
            {
                SoundManager.Instance.Play(Sounds.BUTTONCLICK);
                gameObject.SetActive(false);
            }

            private void OnUnlockButtonClicked()
            { 
                SoundManager.Instance.Play(Sounds.BUTTONCLICK);
                _chestController.UnlockChest();
                DisableUI();
            }
        }
    }
}
