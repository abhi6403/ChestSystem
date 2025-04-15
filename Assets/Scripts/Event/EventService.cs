using ChestSystem.Chest;
using ChestSystem.Commands;
using UnityEngine;

namespace ChestSystem.Event
{
    public class EventService
    {
        private static EventService _instance;

        public static EventService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventService();
                }

                return _instance;
            }
        }
        
        public EventController OnUnlockButtonClicked { get; private set; }
        public EventController UnableToUnlockChest { get; private set; }
        
        public EventController<ChestModel> OnChestButtonClickedInLockedState { get; private set; }
        public EventController<ChestModel> OnChestButtonClickedInUnlockedState { get; private set; }
        public EventController<ChestModel> OnChestButtonClickedInOpenedState { get; private set; }
        
        public EventController<ChestController> OnUnlockClicked { get; private set; }
        public EventController<ChestController> UndoButtonClicked { get; private set; }
        
        public EventController<int> OnGemsUsed { get; private set; }
        public EventController<int> OnGemsCollected { get; private set; }
        public EventController<int> OnCoinsUsed { get; private set; }
        public EventController<int> OnCoinsCollected { get; private set; }
        
        public EventController<ChestController, ICommand> UnlockChest { get; private set; }


        private EventService()
        {
            OnUnlockButtonClicked = new EventController();
            UnableToUnlockChest = new EventController();
            OnChestButtonClickedInLockedState = new EventController<ChestModel>();
            OnChestButtonClickedInUnlockedState = new EventController<ChestModel>();
            OnChestButtonClickedInOpenedState = new EventController<ChestModel>();
            OnUnlockClicked = new EventController<ChestController>();
            OnGemsUsed = new EventController<int>();
            OnCoinsUsed = new EventController<int>();
            OnCoinsCollected = new EventController<int>();
            OnGemsCollected = new EventController<int>();
            UnlockChest = new EventController<ChestController,ICommand>();
            UndoButtonClicked = new EventController<ChestController>();
        }
    }
}
