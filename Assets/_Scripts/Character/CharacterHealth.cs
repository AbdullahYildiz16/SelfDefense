using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace _Scripts
{
    public class CharacterHealth : MonoBehaviour
    {
        [SerializeField] Image fillImg;
        [SerializeField] GameObject losePanel;
        public float health;
        private void Start()
        {
            health = 100;
            RefreshHealthBar();
        }
        void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                StartCoroutine(Lose());
            }
            RefreshHealthBar();
        }
        void RefreshHealthBar()
        {
            fillImg.fillAmount = Mathf.Lerp(fillImg.fillAmount, health / 100, 3);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                TakeDamage(20);
                EnemySpawn.Instance.EnemyPool.AddToPool(other.gameObject);
            }
        }
        IEnumerator Lose()
        {
            losePanel.SetActive(true);
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(1);
        }
    }
}

