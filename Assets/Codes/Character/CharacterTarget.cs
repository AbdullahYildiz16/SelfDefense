using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class CharacterTarget : MonoBehaviour
    {
        [SerializeField] float turningSpeed;
        [HideInInspector] public List<GameObject> ActiveEnemiesList;
        #region Singleton
        public static CharacterTarget Instance;
        private void Awake()
        {
            Instance = this;
        }
        #endregion
        private void Start()
        {
            List<GameObject> ActiveTargetsList = new List<GameObject>();
        }
        void Update()
        {
            GameObject target = GetNearestTarget(EnemySpawn.Instance.EnemyPool.PoolList, 10);
            if (target != null)
            {
                RotateTowards(gameObject.transform, target.transform.position, turningSpeed);
                CharacterFire.Instance.Fire();
            }

        }
        private GameObject GetNearestTarget(List<GameObject> targetList, float limit)
        {
            
            GameObject _nearestObject = null;
            float _nearestDistance = float.MaxValue;
            foreach (var target in ActiveEnemiesList)
            {
                float distance = Mathf.Abs(target.transform.position.x - gameObject.transform.position.x) + 
                    Mathf.Abs(target.transform.position.z - gameObject.transform.position.z);
                if (distance < _nearestDistance)
                {
                    _nearestDistance = distance;
                    _nearestObject = target.gameObject;
                }
            }
            if (_nearestDistance >= limit)
            {
                _nearestObject = null;
                _nearestDistance = float.MaxValue;
            }
            return _nearestObject; 
        }
        public void RotateTowards(Transform _selfTransform, Vector3 _target, float _turningSpeed)
        {
            
            Quaternion _lookRotation = Quaternion.LookRotation((_target - _selfTransform.position).normalized);
            _selfTransform.rotation =  Quaternion.Slerp(_selfTransform.rotation, _lookRotation, turningSpeed *Time.deltaTime);
        }
       
    }
}

