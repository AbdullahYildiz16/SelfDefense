using UnityEngine;
using TMPro;
using UnityEngine.UI;
using _Scripts.PowerUp;
namespace _Scripts.UI
{
    public class PassivePuUI : MonoBehaviour
    {
        [SerializeField] PassivePuBase passivePuBase;
        [SerializeField] TMP_Text levelText, priceText;
        [SerializeField] Button btn;
        private void Start()
        {
            btn.onClick.AddListener(passivePuBase.PowerUpAction);
            btn.onClick.AddListener(UpdateUI);
            UpdateUI();

        }
        public void UpdateUI()
        {
            if (passivePuBase.passivePuSO.CurrentLevel == passivePuBase.passivePuSO.MaxLevel)
            {
                levelText.text = "Max Level";
                priceText.text = "Max";
                btn.interactable = false;

            }
            else
            {
                levelText.text = "Level " + passivePuBase.passivePuSO.CurrentLevel;
                priceText.text = passivePuBase.passivePuSO.Price + "";
            }
        }
    }
}

