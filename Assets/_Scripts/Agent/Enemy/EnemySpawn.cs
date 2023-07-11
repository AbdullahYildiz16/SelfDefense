using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] CharacterTarget characterTarget;
        [SerializeField] float spawnDuration;
        [SerializeField] GameObject enemyPrefab1, enemyPrefab2;
        [SerializeField] Vector3[] spawnPoints;
        public ObjectPool EnemyPool;
        private bool _canSpawn;
        private void Start()
        {
            _canSpawn = true;
            EnemyPool.StartPool(enemyPrefab1, 15);
            EnemyPool.StartPool(enemyPrefab2, 15);
            
            StartCoroutine(SpawnRandomEnemyLoop());
        }        
        IEnumerator SpawnRandomEnemyLoop()
        {
            while (_canSpawn)
            {
                GameObject _currentObject = EnemyPool.GetFromPool(true);
                _currentObject.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
                characterTarget.ActiveEnemiesList.Add(_currentObject.transform);
                yield return new WaitForSeconds(spawnDuration);
            }
            
            
        }
        public void StopSpawner()
        {
            _canSpawn = false;
        }
        [ContextMenu("SetSpawnPoints")]
        private void SetSpawnPoints()
        {
            spawnPoints = new Vector3[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                spawnPoints[i] = transform.GetChild(i).transform.position;
            }
        }
    }
}

