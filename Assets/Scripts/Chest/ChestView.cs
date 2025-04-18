using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Chest
{
    public class ChestView : MonoBehaviour
    {
        private ChestController _chestController;
        
        public Image _chestClosedSprite;
        public Image _chestOpenSprite;
        public TextMeshProUGUI _chestTimerText;
        public TextMeshProUGUI _chestStatusText;
        
        public Button _chestButton;
        
        public void SetController(ChestController controllerToSet) => _chestController = controllerToSet;
        
        public void Update()
        {
            _chestController.Update();
            SetChestStatusText();
            if (_chestController._chestModel._chestState == ChestState.OPENED)
            {
                StartCoroutine(DestroyChest());
            }
        }
        
        public void ProcessButtonClicked()
        {
            SoundManager.Instance.Play(Sounds.BUTTONCLICK);
            if (_chestController._chestModel._chestState == ChestState.LOCKED || _chestController._chestModel._chestState == ChestState.UNLOCKING)
            {
                _chestController.ChestButtonPressedInLockedState();
            }else if (_chestController._chestModel._chestState == ChestState.UNLOCKED)
            {
                _chestController.ChestButtonPressedInUnlockedState();
            }else if (_chestController._chestModel._chestState == ChestState.OPENED)
            {
                _chestController.ChestButtonPressedInOpenState();
            }
        }

        private void SetChestStatusText()
        {
            _chestStatusText.text = _chestController._chestModel._chestState.ToString();
        }

        private IEnumerator DestroyChest()
        {
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }
        
        public void InitializeChestViewOnOpenedState()
        {
            _chestOpenSprite.sprite = _chestController._chestModel._chestOpenSprite;
            _chestOpenSprite.gameObject.SetActive(true);
            _chestTimerText.gameObject.SetActive(false);
            _chestClosedSprite.gameObject.SetActive(false);
            _chestStatusText.gameObject.SetActive(false);
        }
    }
}
