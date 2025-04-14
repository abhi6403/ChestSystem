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
                _undoButton.onClick.AddListener(OnUndoButtonClicked);
                _collectButton.onClick.AddListener(OnCollectButtonClicked);
            }

            public void SetChestController(ChestController chestController)
            {
                _chestController = chestController;
            }
            
            public void InitializeImage(ChestModel chestModel)
            {
                _chestImage.sprite = chestModel._chestClosedSprite;
            }
            private void DisableUI()
            {
                gameObject.SetActive(false);
            }
            
            private void OnUndoButtonClicked()
            {
                _chestController.UndoUnlockWithGems();
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
