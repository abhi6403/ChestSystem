using ChestSystem.Chest;
using ChestSystem.Main;
using ChestSystem.Event;
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

            private void Start() => SubscribeToEvents();
            private void SubscribeToEvents()
            {
                _cancelButton.onClick.AddListener(DisableUI);
                _unlockButton.onClick.AddListener(OnUnlockButtonClicked);
                _unlockWithGemsButton.onClick.AddListener(OnUnlockWithGemsButtonClicked);
            }
            
            public void InitializeImage(ChestModel chestModel)
            {
                _chestImage.sprite = chestModel._chestClosedSprite;
            }
            private void OnUnlockWithGemsButtonClicked()
            {
                
            }

            private void DisableUI()
            {
                gameObject.SetActive(false);
            }

            public void EnableUI()
            {
                gameObject.SetActive(true);
            }

            private void OnUnlockButtonClicked()
            {
                EventService.Instance.OnUnlockButtonClicked.InvokeEvent();
                DisableUI();
            }
        }
    }
}
