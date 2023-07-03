using UnityEngine;
using TMPro;
using _Scripts.Scriptables;
using UnityEngine.UI;
namespace _Scripts.UI
{
    public class AddDiagShotsPU : MonoBehaviour
    {
        public PassivePuSO passivePuSO;
        [SerializeField] TMP_Text levelText;
        [SerializeField] TMP_Text priceText;
        Button _btn;

        void Start()
        {
            _btn = GetComponent<Button>();
            _btn.onClick.AddListener(AddDiagShotClicked);
            PassivePUs.Instance.RefreshPLTexts(passivePuSO, levelText, priceText, _btn);
        }
        void AddDiagShotClicked()
        {
            if (Money.Instance.BuyIfCanAfford(passivePuSO.Price))
            {
                CharacterFire.Instance.CanDiagonalFire = true;
                PlayerPrefs.SetInt("can_diagonal", 1);
                PassivePUs.Instance.IncrLevelAndPrice(passivePuSO, levelText, priceText, _btn);
            }
        }
    }
}

