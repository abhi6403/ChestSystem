using ChestSystem.Chest;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ChestSystem.UI
{
    namespace ChestStateUI
    {
        public class OpenedChestUIController : MonoBehaviour
        {
            [SerializeField] private Image _openedChestImage;
            [SerializeField] private Button _cancelButton;
            [SerializeField] private TextMeshProUGUI _coinsText;
            [SerializeField] private TextMeshProUGUI _gemsText;

            public void Start() => SubscribeToEvent();

            private void SubscribeToEvent()
            {
                _cancelButton.onClick.AddListener(DisableUI);
            }

            private void DisableUI()
            {
                gameObject.SetActive(false);
            }

            private void SetCoinsAndGemsText(int coins,int gems)
            {
                
            }
        }
    }
}
