using System;
using ChestSystem.Chest;
using ChestSystem.Event;
using ChestSystem.UI.ChestStateUI;
using UnityEngine;

namespace ChestSystem.UI
{
    public class UIServices : MonoBehaviour
    {
        private ChestService _chestService;

        [SerializeField] private UnlockChestUIController _unlockChestUIController;
        [SerializeField] private UnlockedChestUIController _unlockedChestUIController;
        [SerializeField] private OpenedChestUIController _openedChestUIController;

        public UIServices(ChestService chestService)
        {
            _chestService = chestService;
        }
        public void Start()
        {
            _unlockChestUIController.gameObject.SetActive(false);
            _unlockedChestUIController.gameObject.SetActive(false);
            _openedChestUIController.gameObject.SetActive(false);
            EventSubscriber();
        }
        
        private void EventSubscriber()
        {
            EventService.Instance.OnChestButtonClickedInLockedState.AddListener(OnChestButtonClickedInLockedState);
            EventService.Instance.OnChestButtonClickedInUnlockedState.AddListener(OnChestButtonClickedInUnlockedState);
            EventService.Instance.OnChestButtonClickedInOpenedState.AddListener(OnChestButtonClickedInOpenedState);
        }

        ~UIServices()
        {
            EventService.Instance.OnChestButtonClickedInLockedState.RemoveListener(OnChestButtonClickedInLockedState);
            EventService.Instance.OnChestButtonClickedInUnlockedState.RemoveListener(OnChestButtonClickedInUnlockedState);
            EventService.Instance.OnChestButtonClickedInOpenedState.RemoveListener(OnChestButtonClickedInOpenedState);
        }
        
        public void Initialize(ChestService chestService)
        {
            _chestService = chestService;
        }
        
        public void CreateChest()
        {
            SoundManager.Instance.Play(Sounds.BUTTONCLICK);
            _chestService.CreateChest();
        }
        
        private void OnChestButtonClickedInLockedState(ChestModel chestModel)
        {
            _unlockChestUIController.Initialize(chestModel);
            _unlockChestUIController.ShowUnlockWithGemsButton();
            _unlockChestUIController.gameObject.SetActive(true);
        }

        private void OnChestButtonClickedInOpenedState(ChestModel chestModel)
        {
            _openedChestUIController.Initialize(chestModel);
            _openedChestUIController.gameObject.SetActive(true);
        }

        private void OnChestButtonClickedInUnlockedState(ChestModel chestModel)
        {
            _unlockedChestUIController.Initialize(chestModel);
            _unlockedChestUIController.gameObject.SetActive(true);
        }
    }
}
