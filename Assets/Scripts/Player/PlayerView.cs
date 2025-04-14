using System;
using TMPro;
using UnityEngine;

namespace ChestSystem.Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController _playerController;
        
        public TextMeshProUGUI _gemsText ;
        public TextMeshProUGUI _coinText ;
        
        public void SetPlayerController(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void Start()
        {
            _playerController.Start();
        }
    }
}
