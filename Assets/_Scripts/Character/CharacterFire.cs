using System.Collections;
using UnityEngine;

namespace _Scripts
{
    public class CharacterFire : MonoBehaviour
    {
        public float FireFrequency;
        [HideInInspector]public bool CanDiagonalFire;
        [HideInInspector] public bool IsFastShot;
        public int MultipleFireAmount;
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] float ammoSpeed;
        [SerializeField] Transform bulletSpawn;
        private int _multpFireCheck;
        private float _currentFireFreq;
        private bool _canFire;
        private bool _canDiagonal()
        {
            var i = PlayerPrefs.GetInt("can_diagonal", 0);
            if (i == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #region Singleton
        public static CharacterFire Instance;
        private void Awake()
        {
            Instance = this;
        }
        #endregion

        private void Start()
        {
            _canFire = true;
            _currentFireFreq = FireFrequency;
            _multpFireCheck = 0;
            FireFrequency = PlayerPrefs.GetFloat("fire_freq", 2f);
            MultipleFireAmount = PlayerPrefs.GetInt("multiple_fire", 1);
            CanDiagonalFire = _canDiagonal();
        }
        public IEnumerator FireCoolDown()
        {
            
            yield return new WaitForSeconds(FireFrequency);          
            if (!IsFastShot)
            {
                FireFrequency = 0.1f;
                if (_multpFireCheck < MultipleFireAmount - 1)
                {
                    _multpFireCheck++;
                    Fire();
                }
                else
                {
                    FireFrequency = _currentFireFreq;

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
                FireWithAngle(0);
                if (CanDiagonalFire)
                {
                    FireWithAngle(30);
                    FireWithAngle(-30);
                }
                StartCoroutine(FireCoolDown());   
            }         
        }
        public void FireWithAngle(float angle)
        {
            var _currentBullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            var _dir = Quaternion.AngleAxis(angle, Vector3.up) * bulletSpawn.forward;
            _currentBullet.GetComponent<Rigidbody>().AddForce(_dir* ammoSpeed, ForceMode.Impulse);
        }
        
    }
}

