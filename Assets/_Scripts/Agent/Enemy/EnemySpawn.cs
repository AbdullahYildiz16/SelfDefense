using System.Collections;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemySpawn : MonoBehaviour
    {
        public GameObject character;
        public CharacterTarget characterTarget;
        [SerializeField] float spawnDuration;
        [SerializeField] EnemyMove[] enemyPrefabs;
        [SerializeField] int[] enemyPrefabAmounts;
        [SerializeField] Vector3[] spawnPoints;
        [HideInInspector] public ObjectPool<EnemyMove> EnemyPool = new ObjectPool<EnemyMove>();
        private bool _canSpawn;
        private void Start()
        {
            _canSpawn = true;
            for(var i = 0; i < enemyPrefabs.Length; i++)
            {
                EnemyPool.StartPool(enemyPrefabs[i], enemyPrefabAmounts[i]);
            }                       
            StartCoroutine(SpawnRandomEnemyLoop());
        }        
        IEnumerator SpawnRandomEnemyLoop()
        {
            while (_canSpawn)
            {
                EnemyMove _currentObject = EnemyPool.GetFromPool(true);
                _currentObject.InitTarget(character);
                _currentObject.gameObject.SetActive(true);              
                _currentObject.gameObject.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
                characterTarget.ActiveEnemiesList.Add(_currentObject.gameObject.transform);
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
        public void OnEnemyDeactivated(EnemyMove enemyMove)
        {
            EnemyPool.AddToPool(enemyMove);
            characterTarget.ActiveEnemiesList.Remove(transform);
            enemyMove.gameObject.SetActive(false);
        }
    }
}

