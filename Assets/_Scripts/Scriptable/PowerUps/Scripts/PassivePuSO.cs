using UnityEngine;

namespace _Scripts.Scriptables
{
    [CreateAssetMenu(menuName = "Skills/PowerUp/Passive")]
    public class PassivePuSO : PowerUpSO
    {
        public int PriceIncrease;
        public int MaxLevel;
        public int CurrentLevel;
    }
}

