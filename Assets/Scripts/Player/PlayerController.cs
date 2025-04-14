using System;
using ChestSystem.Event;
using TMPro;
using UnityEngine;

namespace ChestSystem.Player
{
    public class PlayerController
    {
        public PlayerModel _playerModel { get; private set; }
        public PlayerView _playerView { get; private set; }

        public PlayerController(PlayerView playerView)
        {
            _playerModel = new PlayerModel();
            _playerView = playerView;
            
            _playerModel.SetPlayerController(this);
            _playerView.SetPlayerController(this);
        }

        public void Start()
        {
            _playerModel._coins = 0;
            _playerModel._gems = 0;
            
            InitializeText();
            Events();
        }

        private void InitializeText()
        {
            _playerView._gemsText.text = _playerModel._gems.ToString();
            _playerView._coinText.text = _playerModel._coins.ToString();
        }
        private void Events()
        {
            EventService.Instance.OnGemsUsed.AddListener(OnGemsUsed);
            EventService.Instance.OnCoinsUsed.AddListener(OnCoinsUsed);
            EventService.Instance.OnGemsCollected.AddListener(OnGemsCollected);
            EventService.Instance.OnCoinsCollected.AddListener(OnCoinsCollected);
        }

        private void OnGemsUsed(int gems)
        {
            _playerModel._gems -= gems;
        }

        private void OnCoinsUsed(int coins)
        {
            _playerModel._coins -= coins;
        }

        public void UpdateGems(int gems)
        {
            _playerModel._gems = gems;
            _playerView._gemsText.text = _playerModel._gems.ToString();
        }
        private void OnGemsCollected(int gems)
        {
            _playerModel._gems += gems;
            _playerView._gemsText.text = _playerModel._gems.ToString();
        }

        private void OnCoinsCollected(int coins)
        {
            _playerModel._coins += coins;
            _playerView._coinText.text = _playerModel._coins.ToString();
        }
    }
}
