using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.UI
{
    namespace ChestStateUI
    {
        public class UnlockedChestUIController : MonoBehaviour
        {
            [SerializeField] private Image _chestImage;
            [SerializeField] private Button _cancelButton;
            [SerializeField] private Button _undoButton;
            [SerializeField] private Button _collectButton;

            public void Start() => SubscribeToEvents();

            private void SubscribeToEvents()
            {
                _cancelButton.onClick.AddListener(DisableUI);
                _undoButton.onClick.AddListener(OnUndoButtonClicked);
                _collectButton.onClick.AddListener(OnCollectButtonClicked);
            }

            private void DisableUI()
            {
                gameObject.SetActive(false);
            }

            private void EnableUI()
            {
                gameObject.SetActive(true);
            }

            private void OnUndoButtonClicked()
            {
                
            }

            private void OnCollectButtonClicked()
            {
                
            }
        }
    }
}
