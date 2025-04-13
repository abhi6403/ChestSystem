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

        public void Start()
        {
            _unlockChestUIController.gameObject.SetActive(false);
            _unlockedChestUIController.gameObject.SetActive(false);
            EventSubscriber();
        }

        public void EventSubscriber()
        {
            EventService.Instance.OnChestButtonPressedInLockedState.AddListener(OnChestButtonClicked);
        }

        public void OnChestButtonClicked(ChestModel chestModel)
        {
            _unlockChestUIController.InitializeImage(chestModel);
            _unlockChestUIController.SetChestController(chestModel._chestController);
            _unlockChestUIController.gameObject.SetActive(true);
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
