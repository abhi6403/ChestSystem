using ChestSystem.Chest;
using UnityEngine;

namespace ChestSystem.UI
{
    public class UIServices : MonoBehaviour
    {
        public ChestService _chestService;

        public void Initialize(ChestService chestService)
        {
            _chestService = chestService;
        }
        public UIServices(ChestService chestService)
        {
            _chestService = chestService;
        }
        public void CreateChest()
        {
            _chestService.CreateChest();
        }
    }
}
