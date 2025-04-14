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

            public void SetChestController(ChestController chestController)
            {
                _chestController = chestController;
            }
            
            private void OnUndoButtonClicked()
            {
                _chestController.UndoUnlockWithGems();
            }
            public void InitializeImage(ChestModel chestModel)
            {
                _chestImage.sprite = chestModel._chestClosedSprite;
            }
            private void DisableUI()
            {
                gameObject.SetActive(false);
            }

            private void OnCollectButtonClicked()
            {
                _chestController._chestModel.SetChestState(ChestState.OPENED);
                _chestController.SetStateMachineState(ChestState.OPENED);
                _chestController.IntializeChestViewOnOpenedState();
                _chestController.ChestButtonPressedInOpenState();
                DisableUI();
            }
        }
    }
}
