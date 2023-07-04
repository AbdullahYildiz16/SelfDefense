using UnityEngine;
using UnityEngine.UI;
using TMPro;
using _Scripts.Scriptables;
namespace _Scripts.UI
{
    public class DecreaseFreqPU : MonoBehaviour
    {
        public PassivePuSO passivePuSO;
        [SerializeField] TMP_Text levelText;
        [SerializeField] TMP_Text priceText;
        Button _btn;

        void Start()
        {
            _btn = GetComponent<Button>();
            _btn.onClick.AddListener(DecreaseFreqClicked);
            PassivePUs.Instance.RefreshPLTexts(passivePuSO, levelText, priceText, _btn);
        }
        void DecreaseFreqClicked()
        {
            if (Money.Instance.BuyIfCanAfford(passivePuSO.Price))
            {
                CharacterFire.Instance.FireFrequency -= 0.1f;
                PlayerPrefs.SetFloat("fire_freq", CharacterFire.Instance.FireFrequency);
                PassivePUs.Instance.IncrLevelAndPrice(passivePuSO, levelText, priceText, _btn);
            }
        }
        

    }
}

