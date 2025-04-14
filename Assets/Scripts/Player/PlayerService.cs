using UnityEngine;

namespace ChestSystem.Player
{
    public class PlayerService
    {
        public PlayerController _playerController;

        public PlayerService()
        {
            _playerController = new PlayerController();
        }
    }
}
