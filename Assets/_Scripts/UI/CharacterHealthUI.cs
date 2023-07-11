using UnityEngine;
using UnityEngine.UI;
namespace _Scripts.Character
{
    public class CharacterHealthUI : MonoBehaviour
    {
        [SerializeField] CharacterHealth characterHealth;
        [SerializeField] Image fillImg;
        private void Start()
        {
            RefreshHealthBar();
        }
        public void RefreshHealthBar()
        {
            fillImg.fillAmount = Mathf.Lerp(fillImg.fillAmount, characterHealth.health / 100, 3);
        }
        
    }
}

