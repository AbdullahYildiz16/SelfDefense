using UnityEngine;

namespace _Scripts.Data
{
    [System.Serializable]
    public class EconomyData : SaveDataBase<EconomyData>
    {
        [SerializeField] string fileName;
        [SerializeField] GameEvent onMoneyIncreased;
        [SerializeField] GameEvent onMoneyDecreased;
        private int money;
        protected override string FileName => fileName;
        protected override EconomyData saveObject() => this;

        public int Money
        {
            get
            {
                return money;
            }
            set
            {
                var oldMoney = money;
                money = value;
                if (value > oldMoney) { onMoneyIncreased.Raise(); Debug.Log("Money is increased"); }
                else if (value < oldMoney) { onMoneyDecreased.Raise(); Debug.Log("Money is decreased"); }
                Debug.Log("Money is updated");                
            }
        }
    }
}