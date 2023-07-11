using System.Collections;
using UnityEngine;

namespace _Scripts
{
    public class BulletCode : MonoBehaviour
    {
        [SerializeField] Rigidbody rb;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IHittable>(out IHittable hittable))
            {
                hittable.OnHit();
                
            }
            
        }
        private void OnDisable()
        {
            rb.velocity = Vector3.zero;
        }
        
        public void DestroyBullet()
        {
            gameObject.SetActive(false);
            //eventi tetikle ve add to pool
        }
    }
}

