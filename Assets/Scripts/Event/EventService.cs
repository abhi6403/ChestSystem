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
        
        public EventController OnChestButtonPressedInLockedState { get; private set; }

        public EventService()
        {
            OnChestButtonPressedInLockedState = new EventController();
        }
    }
}
