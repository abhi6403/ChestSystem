using ChestSystem.Chest;
using UnityEngine;

namespace ChestSystem.Event
{
    public class EventService
    {
        private static EventService instance;

        public static EventService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventService();
                }

                return instance;
            }
        }
        
        public EventController OnUnlockButtonClicked { get; private set; }
        public EventController<ChestModel> OnChestButtonClickedInLockedState { get; private set; }
        public EventController<ChestModel> OnChestButtonClickedInUnlockedState { get; private set; }
        public EventController<ChestModel> OnChestButtonClickedInOpenedState { get; private set; }
        public EventController<ChestController> OnUnlockClicked { get; private set; }
        public EventController<int> OnGemsUsed { get; private set; }
        public EventController<int> OnGemsCollected { get; private set; }
        public EventController<int> OnCoinsUsed { get; private set; }
        public EventController<int> OnCoinsCollected { get; private set; }


        public EventService()
        {
            OnUnlockButtonClicked = new EventController();
            OnChestButtonClickedInLockedState = new EventController<ChestModel>();
            OnChestButtonClickedInUnlockedState = new EventController<ChestModel>();
            OnChestButtonClickedInOpenedState = new EventController<ChestModel>();
            OnUnlockClicked = new EventController<ChestController>();
            OnGemsUsed = new EventController<int>();
            OnCoinsUsed = new EventController<int>();
            OnCoinsCollected = new EventController<int>();
            OnGemsCollected = new EventController<int>();
        }
    }
}
