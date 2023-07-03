using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using _Scripts.Scriptables;
using UnityEngine.UI;
namespace _Scripts.UI
{
    public class PassivePUs : MonoBehaviour
    {
        #region Singleton
        public static PassivePUs Instance;
        private void Awake()
        {
            Instance = this;
        }
        #endregion
        public void StartGameClicked()
        {
            PlayerPrefs.SetFloat("last_time", Time.time);
            SceneManager.LoadScene(0);
            
        }
        public void IncrLevelAndPrice(PassivePuSO _passivePuSO, TMP_Text _levelText, TMP_Text _priceText, Button _btn)
        {
            _passivePuSO.Price += _passivePuSO.PriceIncrease;
            _passivePuSO.CurrentLevel++;
            RefreshPLTexts(_passivePuSO, _levelText, _priceText, _btn);
            
        }
        public void RefreshPLTexts(PassivePuSO _passivePuSO,TMP_Text _levelText, TMP_Text _priceText, Button _btn)
        {
            if (_passivePuSO.CurrentLevel == _passivePuSO.MaxLevel)
            {
                _levelText.text = "Max Level";
                _priceText.text = "Max";
                _btn.interactable = false;

            }
            else
            {
                _levelText.text = "Level " + _passivePuSO.CurrentLevel;
                _priceText.text = _passivePuSO.Price + "";
            }
        }

    }
}

