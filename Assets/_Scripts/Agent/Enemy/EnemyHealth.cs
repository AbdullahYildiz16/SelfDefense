using UnityEngine;
using _Scripts.Scriptables;

namespace _Scripts.Enemy
{
    public class EnemyHealth : AgentHealthBase
    {
        [SerializeField] EnemySpawn enemySpawner;
        [SerializeField] GameEvent onEnemyHasDamaged;
        [SerializeField] GameEvent onEnemyDied;
        [SerializeField] EconomySO money;
        [SerializeField] int dieMoney;
        public override void TakeDamage()
        {
            base.TakeDamage();
            onEnemyHasDamaged.Raise();
        }
        public override void Died()
        {
            money.Value += dieMoney;
            enemySpawner.EnemyPool.AddToPool(gameObject);
           // onEnemyDied.Raise();
        }
        
    }
}

