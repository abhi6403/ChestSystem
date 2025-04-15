namespace ChestSystem.Player
{
    public class PlayerModel
    {
        private PlayerController _playerController;
        
        public int _gems { get; set; }
        public int _coins { get; set; }

        public void SetPlayerController(PlayerController playerController)
        {
            _playerController = playerController;
        }
    }
}
