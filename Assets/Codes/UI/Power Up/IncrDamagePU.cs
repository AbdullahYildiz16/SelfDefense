using UnityEngine;
using TMPro;
using _Scripts.Scriptables;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class IncrDamagePU : MonoBehaviour
    {
        public PassivePuSO passivePuSO;
        [SerializeField] TMP_Text levelText;
        [SerializeField] TMP_Text priceText;
        Button _btn;


        void Start()
        {
            _btn = GetComponent<Button>();
            _btn.onClick.AddListener(IncrDamageClicked);
            PassivePUs.Instance.RefreshPLTexts(passivePuSO, levelText, priceText, _btn);
        }
        void IncrDamageClicked()
        {
            if (Money.Instance.BuyIfCanAfford(passivePuSO.Price))
            {
                BulletCode.Instance.FireDamage *= 1.1f;
                PlayerPrefs.SetFloat("fire_damage", BulletCode.Instance.FireDamage);
                PassivePUs.Instance.IncrLevelAndPrice(passivePuSO, levelText, priceText, _btn);
            }
        }
    }
}

