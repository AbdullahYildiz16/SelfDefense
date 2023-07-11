using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Enemy
{
    public class EnemyHealthUI: MonoBehaviour
    {
        [SerializeField] EnemyHealth enemyHealth;
        [SerializeField] Image fillImg;
        public void RefreshHealthBar()
        {
            fillImg.fillAmount = Mathf.Lerp(fillImg.fillAmount, enemyHealth.health / 100, 3);
        }
    }
}