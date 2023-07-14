using UnityEngine;
namespace _Scripts.Data
{
    [System.Serializable]
    public class ShootSettingsData : SaveDataBase<ShootSettingsData>
    {
        [SerializeField] string fileName;
        protected override string FileName => fileName;
        protected override ShootSettingsData saveObject() => this;
        public float FireFrequency;
        public float CharacterDamage;
        public int MultipleFire;
        public bool CanDiagonalFire;

        

    }
}