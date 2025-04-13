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
        public EventController<ChestModel> OnChestButtonPressed { get; private set; }
        public EventController<ChestController> OnUnlockClicked { get; private set; }
        
        public EventController<int> SetCoinsOnChestOpened { get; private set; }
        public EventController<int> SetGemsOnChestOpened { get; private set; }

        public EventService()
        {
            OnUnlockButtonClicked = new EventController();
            OnChestButtonPressed = new EventController<ChestModel>();
            OnUnlockClicked = new EventController<ChestController>();
            SetCoinsOnChestOpened = new EventController<int>();
            SetGemsOnChestOpened = new EventController<int>();
        }
    }
}
