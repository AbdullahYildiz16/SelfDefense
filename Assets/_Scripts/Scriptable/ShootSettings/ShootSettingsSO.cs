using UnityEngine;

namespace _Scripts.Scriptables
{
    [CreateAssetMenu(menuName = "ShootSettings")]
    public class ShootSettingsSO : ScriptableObject
    {
        public float FireFrequency;
        public float CharacterDamage;
        public int MultipleFire;
        public bool IsFastShot;
        public bool CanDiagonalFire;

    }
}