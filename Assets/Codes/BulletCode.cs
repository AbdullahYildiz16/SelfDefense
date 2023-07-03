using System.Collections;
using UnityEngine;

namespace _Scripts
{
    public class BulletCode : MonoBehaviour
    {
        public float FireDamage;
        #region Singleton
        public static BulletCode Instance;
        private void Awake()
        {
            Instance = this;
        }
        #endregion
        private void Start()
        {
            FireDamage = PlayerPrefs.GetInt("fire_damage", 30);
            StartCoroutine(DeactiveBullet());
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyHealth>().TakeDamage(FireDamage);
                gameObject.SetActive(false);

            }
            
        }
        IEnumerator DeactiveBullet()
        {
            yield return new WaitForSeconds(3);
            gameObject.SetActive(false);
        }
        public void MultpFireDamage(float multpAmount)
        {
            FireDamage *= multpAmount;
            PlayerPrefs.SetFloat("fire_damage", FireDamage);
        }
    }
}

