using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] GameObject character;
        NavMeshAgent _agent;
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();         
        }
        void FixedUpdate()
        {
            var angle = character.transform.position - transform.position;
            _agent.destination = character.transform.position;
        }
        
    }
}

