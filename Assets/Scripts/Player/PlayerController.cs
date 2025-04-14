using System;
using ChestSystem.Event;
using TMPro;
using UnityEngine;

namespace ChestSystem.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _gemsText;
        [SerializeField] private TextMeshProUGUI _coinText;
        
        private int _gems;
        private int _coins;

        public void Start()
        {
            _gems = 0;
            _coins = 0;
            
            InitializeText();
            Events();
        }

        public PlayerController()
        {
            
        }

        private void InitializeText()
        {
            _gemsText.text = _gems.ToString();
            _coinText.text = _coins.ToString();
        }
        private void Events()
        {
            EventService.Instance.OnGemsUsed.AddListener(OnGemsUsed);
            EventService.Instance.OnCoinsUsed.AddListener(OnCoinsUsed);
            EventService.Instance.OnGemsCollected.AddListener(OnGemsCollected);
            EventService.Instance.OnCoinsCollected.AddListener(OnCoinsCollected);
        }

        private void OnGemsUsed(int gems)
        {
            _gems -= gems;
        }

        private void OnCoinsUsed(int coins)
        {
            _coins -= coins;
        }

        private void OnGemsCollected(int gems)
        {
            Debug.Log("Getting gems");
            _gems += gems;
            _gemsText.text = _gems.ToString();
        }

        private void OnCoinsCollected(int coins)
        {
            _coins += coins;
            _coinText.text = _coins.ToString();
        }
    }
}
