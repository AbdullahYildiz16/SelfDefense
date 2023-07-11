using UnityEngine;
using TMPro;
using _Scripts.Scriptables;
namespace _Scripts.UI
{
    public class MoneyUI : MonoBehaviour
    {
        [SerializeField] EconomySO money;
        [SerializeField] TMP_Text text;

        
        public void UpdateUI()
        {
            text.text = money.Value.ToString();
        }
    }
}

