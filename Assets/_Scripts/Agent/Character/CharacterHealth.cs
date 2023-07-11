using System.Collections;
using UnityEngine;
namespace _Scripts
{
    public class CharacterHealth : AgentHealthBase
    {
        [SerializeField] GameEvent onCharacterDamaged;
        [SerializeField] GameEvent onCharacterDied;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IHittable>(out IHittable hittable))
            {
                hittable.OnHit();
                other.gameObject.SetActive(false);
            }
        }
        public override void TakeDamage()
        {
            base.TakeDamage();
            onCharacterDamaged.Raise();
        }
        

        public override void Died()
        {
            onCharacterDied.Raise();
        }
    }
}

