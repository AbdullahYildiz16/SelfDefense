using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] EnemyHealth enemyHealth;
        [HideInInspector] public GameObject character;
        [SerializeField] NavMeshAgent _agent;
        [SerializeField] EnemySpawn enemySpawn;
        void FixedUpdate()
        {
            var angle = character.transform.position - transform.position;
            _agent.destination = character.transform.position;
        }
        public void InitTarget(GameObject character)
        {
            this.character = character;
        }
        public void OnEnemyDeactivate()
        {
            enemySpawn.OnEnemyDeactivated(this);
        }
        private void OnEnable()
        {
            enemyHealth.onEnemyDeactivate += OnEnemyDeactivate;
        }
        private void OnDisable()
        {
            enemyHealth.onEnemyDeactivate -= OnEnemyDeactivate;
        }
    }
}

