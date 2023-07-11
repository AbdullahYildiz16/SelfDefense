using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class ObjectPool<T> where T : Object
    {
        private readonly List<T> PoolList = new List<T>();
        T _poolPrefab;
        public void StartPool(T _objectPrefab, int _startAmount)
        {
            _poolPrefab = _objectPrefab;
            for (int i = 0; i< _startAmount;i++)
            {                
                PoolList.Add(Object.Instantiate(_poolPrefab));
            }
        }
        public T GetFromPool(bool isRandom)
        {         
            int objInx = 0;
            if (PoolList.Count == 0) PoolList.Add(Object.Instantiate(_poolPrefab));
            objInx = isRandom ? Random.Range(0, PoolList.Count - 1) : PoolList.Count - 1;
            var _getObj = PoolList[objInx];
            //_getObj.SetActive(true);
            PoolList.RemoveAt(objInx);
            return _getObj;
        }
        public void AddToPool(T _addObject)
        {
            //_addObject.SetActive(false);
            PoolList.Add(_addObject);
        }
       
        
    }
}

