using UnityEngine;
using _Scripts.Data;
namespace _Scripts.Scriptables
{
    [CreateAssetMenu(menuName = "Skills/PowerUp/Passive")]
    public class PassivePuSO : PowerUpSO,ISavable
    {
        public PassivePuData passivePuData;
        public void IncrLevelAndPrice()
        {
            passivePuData.Price += passivePuData.PriceIncrease;
            passivePuData.CurrentLevel++;

        }

        public void Load()
        {
            passivePuData.Load();
        }

        public void Save()
        {
            passivePuData.Save();
        }
    }
}
