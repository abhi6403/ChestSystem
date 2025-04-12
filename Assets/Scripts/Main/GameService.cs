using UnityEngine;
using System.Collections.Generic;
using ChestSystem.Sound;
using ChestSystem.Chest;
using ChestSystem.Event;
using ChestSystem.UI;
using ChestSystem.Utilities;

namespace ChestSystem.Main
{
    public class GameService : MonoBehaviour
    {
        public SoundService SoundService { get; private set; }
        public PlayerService PlayerService { get; private set; }
        public ChestService ChestService { get; private set; }
        
        [SerializeField] private UIServices uiServices;
        public UIServices UIServices => uiServices;

        [SerializeField] private List<ChestSO> chests;
        [SerializeField] private Transform _chestContainer;
        protected void Awake()
        {
            CreateService();
            InjectDependencies();
        }

        private void CreateService()
        {
            SoundService = new SoundService();
            PlayerService = new PlayerService();
            ChestService = new ChestService();
        }

        private void InjectDependencies()
        {
            ChestService.Initialize(chests,_chestContainer);
            UIServices.Initialize(ChestService);
        }
    }
}
