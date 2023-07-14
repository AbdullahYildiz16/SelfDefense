using UnityEngine;

namespace _Scripts.Data
{
    [System.Serializable]
    public class PowerUpData : SaveDataBase<PowerUpData>
    {
        [SerializeField] protected string fileName;
        protected override string FileName => fileName;
        protected override PowerUpData saveObject() => this;

        public int Price;
    }
}