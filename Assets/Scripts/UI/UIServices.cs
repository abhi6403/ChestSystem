using System;
using ChestSystem.Chest;
using ChestSystem.Event;
using ChestSystem.StateMachine;
using ChestSystem.UI.ChestStateUI;
using UnityEngine;

namespace ChestSystem.UI
{
    public class UIServices : MonoBehaviour
    {
        public ChestService _chestService;

        [SerializeField] public UnlockChestUIController _unlockChestUIController;
        [SerializeField] public UnlockedChestUIController _unlockedChestUIController;
        [SerializeField] public OpenedChestUIController _openedChestUIController;

        public void Start()
        {
            _unlockChestUIController.gameObject.SetActive(false);
            _unlockedChestUIController.gameObject.SetActive(false);
            _openedChestUIController.gameObject.SetActive(false);
            EventSubscriber();
        }

        public void EventSubscriber()
        {
            EventService.Instance.OnChestButtonClickedInLockedState.AddListener(OnChestButtonClickedInLockedState);
            EventService.Instance.OnChestButtonClickedInUnlockedState.AddListener(OnChestButtonClickedInUnlockedState);
            EventService.Instance.OnChestButtonClickedInOpenedState.AddListener(OnChestButtonClickedInOpenedState);
        }

        public void OnChestButtonClickedInLockedState(ChestModel chestModel)
        {
            _unlockChestUIController.InitializeImage(chestModel);
            _unlockChestUIController.SetChestController(chestModel._chestController);
            _unlockChestUIController.gameObject.SetActive(true);
        }

        public void OnChestButtonClickedInOpenedState(ChestModel chestModel)
        {
            _openedChestUIController.SetChestController(chestModel._chestController);
            _openedChestUIController.Initialize(chestModel);
            _openedChestUIController.gameObject.SetActive(true);
        }

        public void OnChestButtonClickedInUnlockedState(ChestModel chestModel)
        {
            _unlockedChestUIController.SetChestController(chestModel._chestController);
            _unlockedChestUIController.InitializeImage(chestModel);
            _unlockedChestUIController.gameObject.SetActive(true);
        }
        public void Initialize(ChestService chestService)
        {
            _chestService = chestService;
        }
        public UIServices(ChestService chestService)
        {
            _chestService = chestService;
        }
        public void CreateChest()
        {
            _chestService.CreateChest();
        }

        
    }
}
