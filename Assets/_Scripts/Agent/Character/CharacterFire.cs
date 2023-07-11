using System.Collections;
using UnityEngine;
using _Scripts.Scriptables;
namespace _Scripts
{
    public class CharacterFire : MonoBehaviour
    {
        [SerializeField] ObjectPool bulletPool;
        [SerializeField] ShootSettingsSO shootSettings;
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] float ammoSpeed;
        [SerializeField] Transform bulletSpawn;
        private WaitForSeconds _fireCoolDownWait;
        private int _multpFireCheck;
        private float _currentFireFreq;
        private bool _canFire;
        
        private void Start()
        {
            bulletPool.StartPool(bulletPrefab, 10);
            _fireCoolDownWait = new WaitForSeconds(shootSettings.FireFrequency);
            _canFire = true;
            _currentFireFreq = shootSettings.FireFrequency;
            _multpFireCheck = 0;
        }
        public IEnumerator FireCoolDown()
        {

            yield return _fireCoolDownWait;        
            if (!shootSettings.IsFastShot)
            {
                shootSettings.FireFrequency = 0.1f;
                if (_multpFireCheck < shootSettings.MultipleFire - 1)
                {
                    _multpFireCheck++;
                    Fire();
                }
                else
                {
                    shootSettings.FireFrequency = _currentFireFreq;

                    _multpFireCheck = 0;
                }
            }
            
            _canFire = true;
            
        }
        public void Fire()
        {
            if (_canFire)
            {          
                _canFire = false;             
                FireWithAngel(0);
                if (shootSettings.CanDiagonalFire)
                {
                    FireWithAngel(30);
                    FireWithAngel(-30);
                }
                StartCoroutine(FireCoolDown());   
            }         
        }
        void FireWithAngel(float angle)
        {
            var _currentBullet = bulletPool.GetFromPool(false);
            _currentBullet.transform.position = bulletSpawn.transform.position;
            _currentBullet.transform.rotation = bulletSpawn.transform.rotation;
            var _dir = Quaternion.AngleAxis(angle, Vector3.up) * bulletSpawn.forward;
            _currentBullet.GetComponent<Rigidbody>().AddForce(_dir* ammoSpeed, ForceMode.Impulse);
            
        }
        
    }
}

