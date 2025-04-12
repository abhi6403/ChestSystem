using UnityEngine;

namespace ChestSystem.Events
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
        
        public EventController OnChestButtonPressed { get; private set; }

        public EventService()
        {
            OnChestButtonPressed = new EventController();
        }
    }
}
