using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts
{
    public class EnemyMove : MonoBehaviour
    {
        GameObject _character;
        NavMeshAgent _agent;
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _character = EnemySpawn.Instance.character;
            
        }
        void FixedUpdate()
        {
            var angle = _character.transform.position - transform.position;
            _agent.destination = _character.transform.position;
        }
        
    }
}

