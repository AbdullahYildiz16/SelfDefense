using UnityEngine;
using _Scripts.Data;
namespace _Scripts.Scriptables
{
    [CreateAssetMenu(menuName = "Skills/PowerUp/Active")]
    public class ActivePuSO : PowerUpSO, ISavable
    {
        public ActivePuData activePuData;

        public void Load()
        {
            activePuData.Load();
        }

        public void Save()
        {
            activePuData.Save();
        }
    }
}