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
        public EventController<ChestModel> OnChestButtonPressedInLockedState { get; private set; }

        public EventService()
        {
            OnUnlockButtonClicked = new EventController();
            OnChestButtonPressedInLockedState = new EventController<ChestModel>();
        }
    }
}
