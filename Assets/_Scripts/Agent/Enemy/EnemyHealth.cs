using System;
using System.Collections.Generic;
using UnityEngine;
using _Scripts.Scriptables;

namespace _Scripts.Enemy
{
    public class EnemyHealth : AgentHealthBase
    {
        public Action onEnemyDeactivate;
        [SerializeField] GameEvent onEnemyHasDamaged;
        [SerializeField] GameEvent onEnemyDied;
        [SerializeField] EconomySO economySO;
        [SerializeField] int dieMoney;
        public override void TakeDamage()
        {
            base.TakeDamage();
            onEnemyHasDamaged.Raise();
        }
        public override void Died()
        {
            economySO.EconomyData.Money += dieMoney;
            Debug.Log(economySO.EconomyData.Money + "");
            onEnemyDeactivate.Invoke();           
            // onEnemyDied.Raise();
        }
        
    }
}

