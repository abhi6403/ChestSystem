using UnityEngine;

namespace ChestSystem.Player
{
    public class PlayerService
    {
        public PlayerController _playerController;

        public PlayerService(PlayerView playerView)
        {
            _playerController = new PlayerController(playerView);
        }
    }
}
