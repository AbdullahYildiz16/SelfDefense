using UnityEngine;
using UnityEngine.UI;
using _Scripts.UI;
namespace _Scripts
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] Image fillImg;
        public float health;
        float _currentTime;
        private void OnEnable()
        {
            health = 100;
            RefreshHealthBar();

        }
        private void FixedUpdate()
        {
            if (health < 100)
            {
                if (Time.time - _currentTime > 1f)
                {
                    _currentTime++;
                    health += 4f;
                    RefreshHealthBar();
                }
            }
            else
            {
                _currentTime = Time.time;
            }
            
        }
        public void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                // Play Die Animation
                health = 0;
                Money.Instance.SetGold(100);
                CharacterTarget.Instance.ActiveEnemiesList.Remove(gameObject);
                EnemySpawn.Instance.EnemyPool.AddToPool(gameObject);
                
            }
            RefreshHealthBar();
        }
        void RefreshHealthBar()
        {
            fillImg.fillAmount = Mathf.Lerp(fillImg.fillAmount, health/100, 3);
        }
        
    }
}

