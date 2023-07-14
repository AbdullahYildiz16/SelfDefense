using UnityEngine;
using UnityEngine.UI;
using TMPro;
using _Scripts.PowerUp;

namespace _Scripts.UI
{
    public class ActivePuUI : MonoBehaviour
    {
        [SerializeField] ActivePuBase activePuBase;
        [SerializeField] TMP_Text priceText;
        [SerializeField] Button btn;
        [SerializeField] Image cooldownImg;
        private void Start()
        {
            btn.onClick.AddListener(activePuBase.PowerUpAction);
            btn.onClick.AddListener(UpdateUI);
            InitUI();

        }
        void InitUI()
        {
            priceText.text = activePuBase.activePuSO.activePuData.Price.ToString();
            cooldownImg.fillAmount = 1;
        }
        public void UpdateUI()
        { 
            if(activePuBase.IsCoolingDown) cooldownImg.fillAmount += 1 / activePuBase.activePuSO.activePuData.CoolDownDelay;
        }
        public void StartCoolDownUI()
        {
            cooldownImg.fillAmount = 0;
        }
    }
}