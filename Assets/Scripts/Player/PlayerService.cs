namespace ChestSystem.Player
{
    public class PlayerService
    {
        private PlayerController _playerController;

        public PlayerService(PlayerView playerView)
        {
            _playerController = new PlayerController(playerView);
        }

        public PlayerController GetPlayerController()
        {
            return _playerController;
        }
    }
}
