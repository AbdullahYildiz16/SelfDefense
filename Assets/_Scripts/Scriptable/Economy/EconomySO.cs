using UnityEngine;
using _Scripts.Data;
namespace _Scripts.Scriptables
{
    [CreateAssetMenu(menuName ="Economy")]
    public class EconomySO : ScriptableObject, ISavable
    {
        public EconomyData EconomyData;
        public bool BuyIfCanAfford(int prize)
        {           
            if (prize > EconomyData.Money)
            {
                return false;
            }
            else
            {
                EconomyData.Money -= prize;
                return true;
            }
        }

        public void Load()
        {
            EconomyData.Load();
        }

        public void Save()
        {
            EconomyData.Save();
        }        
    }
}

