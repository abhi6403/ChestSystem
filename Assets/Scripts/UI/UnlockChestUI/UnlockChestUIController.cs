using ChestSystem.Main;
using ChestSystem.Event;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.UI
{
    namespace ChestSystem.UI.UnlockChest
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
                _cancelButton.onClick.AddListener(OnCancelButtonClicked);
                _unlockButton.onClick.AddListener(OnUnlockButtonClicked);
                _unlockWithGemsButton.onClick.AddListener(OnUnlockWithGemsButtonClicked);
            }
            
            private void OnUnlockWithGemsButtonClicked()
            {
                
            }

            private void OnCancelButtonClicked()
            {
                gameObject.SetActive(false);
            }

            public void OnChestButtonClicked()
            {
                gameObject.SetActive(true);
            }

            private void OnUnlockButtonClicked()
            {
                
            }
        }
    }
}
