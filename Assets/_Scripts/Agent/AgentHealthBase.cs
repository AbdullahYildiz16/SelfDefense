using UnityEngine;
namespace _Scripts
{
    public abstract class AgentHealthBase : MonoBehaviour,IHittable
    {
        [SerializeField] float healAmount;
        [SerializeField] float damageAmount;
        public float health;
        private void OnEnable()
        {
            health = 100;
        }
        public virtual void TakeDamage()
        {
            health -= damageAmount;
            if (health <= 0)
            {
                health = 0;
                Died();
            }

        }
        public void Heal()
        {
            if (health < 100)
            {
                health += (int)healAmount;
                health = health > 100 ? health = 100 : health;
            }

        }
        public abstract void Died();

        public void OnHit()
        {
            TakeDamage();
        }
    }
}