using UnityEngine;
using TMPro;
using _Scripts.Scriptables;
namespace _Scripts.UI
{
    public class MoneyUI : MonoBehaviour
    {
        [SerializeField] EconomySO economySO;
        [SerializeField] TMP_Text text;

        private void Start()
        {
            UpdateUI();            
        }
        public void UpdateUI()
        {
            text.text = economySO.EconomyData.Money.ToString();
            Debug.Log("Money UI is updated");
        }
    }
}

