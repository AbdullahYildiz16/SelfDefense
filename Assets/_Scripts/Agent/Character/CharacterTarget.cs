using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class CharacterTarget : MonoBehaviour
    {
        [SerializeField] GameEvent onCharacterFire;
        [SerializeField] float turningSpeed;
        [HideInInspector] public List<Transform> ActiveEnemiesList;
        Transform _target;
        private bool _canRotate = true;
        private void Start()
        {
            List<Transform> ActiveTargetsList = new List<Transform>();
        }
        void FixedUpdate()
        {
            _target = _canRotate == true ? GetNearestTarget(10) : null;
            if (!_target) return;
            RotateTowards(gameObject.transform, _target.position, turningSpeed);
            onCharacterFire.Raise();

        }
        private Transform GetNearestTarget(float limit)
        {
            
            Transform nearestTransform = null;
            float _nearestDistance = float.MaxValue;
            foreach (var target in ActiveEnemiesList)
            {
                float distance = Mathf.Abs(target.position.x - gameObject.transform.position.x) + 
                    Mathf.Abs(target.position.z - gameObject.transform.position.z);
                if (distance < _nearestDistance)
                {
                    _nearestDistance = distance;
                    nearestTransform = target;
                }
            }
            if (_nearestDistance >= limit)
            {
                nearestTransform = null;
                _nearestDistance = float.MaxValue;
            }
            return nearestTransform; 
        }
        public void RotateTowards(Transform selfTransform, Vector3 targetPos, float turningSpeed)
        {
            
            Quaternion _lookRotation = Quaternion.LookRotation((targetPos - selfTransform.position).normalized);
            selfTransform.rotation = Quaternion.Slerp(selfTransform.rotation, _lookRotation, this.turningSpeed * Time.deltaTime);
        }
       
    }
}

