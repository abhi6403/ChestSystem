using ChestSystem.Chest;
using TMPro;
using UnityEngine;
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
            
            private ChestController _chestController;
            public void Start() => SubscribeToEvent();

            private void SubscribeToEvent()
            {
                _cancelButton.onClick.AddListener(DisableUI);
            }
            
            public void Initialize(ChestModel chestModel)
            {
                _openedChestImage.sprite = chestModel._chestOpenSprite;
                _chestController = chestModel._chestController;
                SetCoinsText();
                SetGemsText();
            }
            
            private void DisableUI()
            {
                SoundManager.Instance.Play(Sounds.BUTTONCLICK);
                gameObject.SetActive(false);
            }

            private void SetCoinsText()
            {
                _coinsText.text = _chestController._chestModel._chestCurrentCoins.ToString();
            }

            private void SetGemsText()
            {
                _gemsText.text = _chestController._chestModel._chestCurrentGems.ToString();
            }
        }
    }
}
