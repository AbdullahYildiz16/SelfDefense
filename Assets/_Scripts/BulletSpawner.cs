using UnityEngine;

namespace _Scripts.Bullet
{
    public class BulletSpawner : MonoBehaviour
    {
        [HideInInspector] public ObjectPool<BulletCode> bulletPool = new ObjectPool<BulletCode>();
        [SerializeField] BulletCode bulletCode;
        [SerializeField] int startAmount;  
        private void Start()
        {
            bulletPool.StartPool(bulletCode, startAmount);
        }
    }
}