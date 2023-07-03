using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class EnemySpawn : MonoBehaviour
    {
        public GameObject character;
        [SerializeField] float spawnDuration;
        [SerializeField] GameObject enemyPrefab1, enemyPrefab2;
        List<Vector3> _spawnPoints;
        public ObjectPool EnemyPool;
        #region Singleton
        public static EnemySpawn Instance;
        private void Awake()
        {
            Instance = this;
        }
        #endregion
        private void Start()
        {          
            EnemyPool.StartPool(enemyPrefab1, 15);
            EnemyPool.StartPool(enemyPrefab2, 15);
            _spawnPoints = new List<Vector3>();
            for(int i = 0; i< transform.childCount; i++)
            {
                _spawnPoints.Add(transform.GetChild(i).transform.position); 
            }
            StartCoroutine(SpawnRandomEnemyLoop());
        }        
        IEnumerator SpawnRandomEnemyLoop()
        {
            GameObject _currentObject = EnemyPool.GetFromPool(true);
            _currentObject.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Count - 1)];
            CharacterTarget.Instance.ActiveEnemiesList.Add(_currentObject);
            yield return new WaitForSeconds(spawnDuration);
            StartCoroutine(SpawnRandomEnemyLoop());
        }
    }
}

