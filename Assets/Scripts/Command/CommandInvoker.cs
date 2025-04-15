using System.Collections.Generic;
using ChestSystem.Chest;
using ChestSystem.Event;
using ChestSystem.Player;

namespace ChestSystem.Commands
{
    public class CommandInvoker
    {
        private Dictionary<ChestController,Stack<ICommand>> _commandsHistory = new Dictionary<ChestController,Stack<ICommand>>();
        private PlayerService _playerService;

        public CommandInvoker(PlayerService playerService)
        {
            _playerService = playerService;
            Events();
        }

        private void Events()
        {
            EventService.Instance.UnlockChest.AddListener(ProcessCommand);
            EventService.Instance.UndoButtonClicked.AddListener(Undo);
        }

        ~CommandInvoker()
        {
            EventService.Instance.UnlockChest.RemoveListener(ProcessCommand);
            EventService.Instance.UndoButtonClicked.RemoveListener(Undo);
        }

        private void ProcessCommand(ChestController chestController, ICommand command)
        {
            ExecuteCommand(chestController, command);
            RegisterCommand(chestController, command);
        }

        private void ExecuteCommand(ChestController chestController, ICommand command) =>
            command.Execute(_playerService, chestController);

        private void RegisterCommand(ChestController chestController, ICommand command)
        {
            if (!_commandsHistory.ContainsKey(chestController))
            {
                _commandsHistory[chestController] = new Stack<ICommand>();
            }
            _commandsHistory[chestController].Push(command);
        }

        private void Undo(ChestController chestController)
        {
            if (_commandsHistory.ContainsKey(chestController) && _commandsHistory[chestController].Count > 0)
            {
                _commandsHistory[chestController].Pop().Undo();
            }
        }
    }
}
