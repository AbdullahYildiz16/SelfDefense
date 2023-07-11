using UnityEngine;

namespace _Scripts.Bullet
{
    public class BulletCode : MonoBehaviour
    {
        [SerializeField] BulletSpawner bulletSpawner;
        public Rigidbody rb;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IHittable>(out IHittable hittable))
            {
                hittable.OnHit();
                
            }
            DestroyBullet();
        }
        private void OnDisable()
        {
            rb.velocity = Vector3.zero;
        }
        public void DestroyBullet()
        {
            bulletSpawner.bulletPool.AddToPool(this);
            gameObject.SetActive(false);
            //eventi tetikle ve add to pool
        }
    }
}

