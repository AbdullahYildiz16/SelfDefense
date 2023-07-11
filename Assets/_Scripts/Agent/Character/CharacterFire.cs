using System.Collections;
using UnityEngine;
using _Scripts.Scriptables;
using _Scripts.Bullet;
namespace _Scripts.Character
{
    public class CharacterFire : MonoBehaviour
    {
        [SerializeField] BulletSpawner bulletSpawner;
        [SerializeField] ShootSettingsSO shootSettings;
        [SerializeField] float ammoSpeed;
        [SerializeField] Transform bulletSpawn;
        private int _multpFireCheck;
        private float _currentFireFreq;
        private bool _canFire;
        
        private void Start()
        {           
            
            _canFire = true;
            _currentFireFreq = shootSettings.FireFrequency;
            _multpFireCheck = 0;
        }
        public IEnumerator FireCoolDown()
        {
            yield return new WaitForSeconds(shootSettings.FireFrequency);        
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
            var _currentBullet = bulletSpawner.bulletPool.GetFromPool(false);
            _currentBullet.gameObject.SetActive(true);
            _currentBullet.gameObject.transform.position = bulletSpawn.transform.position;
            _currentBullet.gameObject.transform.rotation = bulletSpawn.transform.rotation;
            var _dir = Quaternion.AngleAxis(angle, Vector3.up) * bulletSpawn.forward;
            _currentBullet.rb.AddForce(_dir* ammoSpeed, ForceMode.Impulse);            
        }
        
    }
}

