using ChestSystem.Chest;
using ChestSystem.Event;
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

            private ChestController _chestController;
            public void Start() => SubscribeToEvents();

            private void SubscribeToEvents()
            {
                _cancelButton.onClick.AddListener(DisableUI);
                _collectButton.onClick.AddListener(OnCollectButtonClicked);
                _undoButton.onClick.AddListener(OnUndoButtonClicked);
            }
            private void OnUndoButtonClicked()
            {
                SoundManager.Instance.Play(Sounds.BUTTONCLICK);
                _chestController.UndoUnlockWithGems();
                DisableUI();
            }
            public void Initialize(ChestModel chestModel)
            {
                _chestImage.sprite = chestModel._chestClosedSprite;
                _chestController = chestModel._chestController;
            }
            private void DisableUI()
            {
                SoundManager.Instance.Play(Sounds.BUTTONCLICK);
                gameObject.SetActive(false);
            }

            private void OnCollectButtonClicked()
            {
                SoundManager.Instance.Play(Sounds.BUTTONCLICK);
                _chestController._chestModel.SetChestState(ChestState.OPENED);
                _chestController.SetStateMachineState(ChestState.OPENED);
                _chestController.ChestButtonPressedInOpenState();
                DisableUI();
            }
        }
    }
}
