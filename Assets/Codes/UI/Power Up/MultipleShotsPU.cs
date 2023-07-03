using UnityEngine;
using UnityEngine.UI;
using TMPro;
using _Scripts.Scriptables;

namespace _Scripts.UI
{
    public class MultipleShotsPU : MonoBehaviour
    {
        public PassivePuSO passivePuSO;
        [SerializeField] TMP_Text levelText;
        [SerializeField] TMP_Text priceText;
        Button _btn;

        void Start()
        {
            _btn = GetComponent<Button>();
            _btn.onClick.AddListener(MultpShotClicked);
            PassivePUs.Instance.RefreshPLTexts(passivePuSO, levelText, priceText, _btn);
        }
        void MultpShotClicked()
        {
            if (Money.Instance.BuyIfCanAfford(passivePuSO.Price))
            {
                CharacterFire.Instance.MultipleFireAmount++;
                PlayerPrefs.SetInt("multiple_fire", CharacterFire.Instance.MultipleFireAmount);
                PassivePUs.Instance.IncrLevelAndPrice(passivePuSO, levelText, priceText, _btn);
            }
        }
    }

}
