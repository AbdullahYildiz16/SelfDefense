using System.Collections;
using UnityEngine;
namespace _Scripts
{
    public class CharacterHealth : AgentHealthBase
    {
        [SerializeField] GameEvent onCharacterDamaged;
        [SerializeField] GameEvent onCharacterDied;

        public override void TakeDamage()
        {
            base.TakeDamage();
            onCharacterDamaged.Raise();
        }
        

        public override void Died()
        {
            onCharacterDied.Raise();
        }
        public void DestroyCharacter() => gameObject.SetActive(false);
    }
}

