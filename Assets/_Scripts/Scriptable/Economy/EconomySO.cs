using UnityEngine;

namespace _Scripts.Scriptables
{
    [CreateAssetMenu(menuName ="Economy")]
    public class EconomySO : ScriptableObject
    {
        private int value;
        [SerializeField] GameEvent onMoneyIncreased;
        [SerializeField] GameEvent onMoneyDecreased;
        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                if (value > this.Value)
                {
                    onMoneyIncreased.Raise();
                }
                else if (value < this.Value)
                {
                    onMoneyDecreased.Raise();
                }
                this.value = value;

            }
        }

        public bool BuyIfCanAfford(int prize)
        {
            if (prize > Value)
            {
                return false;
            }
            else
            {
                Value -= prize;
                return true;
            }
        }
    }
}

