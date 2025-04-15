using ChestSystem.Chest;
using ChestSystem.Player;

namespace ChestSystem.Commands
{
    public interface ICommand
    {
        public void Execute(PlayerService playerService,ChestController chestController);
        public void Undo();
    }
}
