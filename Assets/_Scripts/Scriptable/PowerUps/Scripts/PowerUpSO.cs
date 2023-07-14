using UnityEngine;
using _Scripts.Data;
namespace _Scripts.Scriptables
{
    [CreateAssetMenu(menuName = "Skills/PowerUp")]
    public class PowerUpSO : ScriptableObject
    {
        public ShootSettingsSO shootSettings;
        public EconomySO money;
    }
}

