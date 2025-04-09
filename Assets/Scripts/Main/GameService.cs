using UnityEngine;
using System.Collections.Generic;
using ChestSystem.Sound;
using ChestSystem.Chest;

namespace ChestSystem.Main
{
    public class GameService 
    {
        public SoundService SoundService { get; private set; }
        public EventService EventService { get; private set; }
        public PlayerService PlayerService { get; private set; }
        public ChestService ChestService { get; private set; }
        
        [SerializeField] private UIServices uiServices;
        public UIServices UIServices => uiServices;

        protected void Awake()
        {
            EventService = new EventService();
            SoundService = new SoundService();
            PlayerService = new PlayerService();
        }
    }
}
