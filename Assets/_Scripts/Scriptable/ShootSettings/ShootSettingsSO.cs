using UnityEngine;
using _Scripts.Data;
namespace _Scripts.Scriptables
{
    [CreateAssetMenu(menuName = "ShootSettings")]
    public class ShootSettingsSO : ScriptableObject,ISavable
    {
        public ShootSettingsData ShootSettingsData;
        public bool IsFastShot;

        public void Load()
        {
            ShootSettingsData.Load();
        }

        public void Save()
        {
            ShootSettingsData.Save();
        }
    }
}