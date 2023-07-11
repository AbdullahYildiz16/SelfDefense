using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class ObjectPool : MonoBehaviour
    {
        [HideInInspector]public List<GameObject> PoolList;
        GameObject _poolPrefab;
        private void Awake()
        {
            PoolList = new List<GameObject>();
        }

        public void StartPool(GameObject _objectPrefab, int _startAmount)
        {
            _poolPrefab = _objectPrefab;
            for (int i = 0; i< _startAmount;i++)
            {
                
                PoolList.Add(Instantiate(_poolPrefab, transform.position, Quaternion.identity));
            }
        }
        public GameObject GetFromPool(bool isRandom)
        {         
            int objInx = 0;
            if (PoolList.Count == 0)
            {
                PoolList.Add(Instantiate(_poolPrefab,transform.position, Quaternion.identity));
            }
            if (isRandom)
            {
                objInx = Random.Range(0, PoolList.Count - 1);
            }
            else
            {
                objInx = PoolList.Count - 1;
            }
            var _getObj = PoolList[objInx].gameObject;
            _getObj.SetActive(true);
            PoolList.RemoveAt(objInx);
            return _getObj;
        }
        public void AddToPool(GameObject _addObject)
        {
            _addObject.SetActive(false);
            PoolList.Add(_addObject);
        }
    }
}

