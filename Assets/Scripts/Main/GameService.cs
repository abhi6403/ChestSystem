using UnityEngine;
using System.Collections.Generic;
using ChestSystem.Sound;
using ChestSystem.Chest;
using ChestSystem.Commands;
using ChestSystem.Event;
using ChestSystem.Player;
using ChestSystem.UI;
using ChestSystem.Utilities;

namespace ChestSystem.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        public SoundService SoundService { get; private set; }
        public PlayerService PlayerService { get; private set; }
        public ChestService ChestService { get; private set; }
        public CommandInvoker CommandInvoker { get; private set; }
        
        [SerializeField] private UIServices uiServices;
        public UIServices UIServices => uiServices;

        [SerializeField] private List<ChestSO> chests;
        [SerializeField] private Transform _chestContainer;
        [SerializeField] private PlayerView _playerView;
        protected override void Awake()
        {
            CreateService();
            InjectDependencies();
        }

        private void CreateService()
        {
            SoundService = new SoundService();
            PlayerService = new PlayerService(_playerView);
            ChestService = new ChestService();
            CommandInvoker = new CommandInvoker(PlayerService);
        }

        private void InjectDependencies()
        {
            ChestService.Initialize(chests,_chestContainer);
            UIServices.Initialize(ChestService);
        }
    }
}
