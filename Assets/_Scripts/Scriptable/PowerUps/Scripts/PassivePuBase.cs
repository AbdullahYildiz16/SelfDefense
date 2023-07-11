using UnityEngine;
using _Scripts.Scriptables;
namespace _Scripts.PowerUp
{
    
    public abstract class PassivePuBase : MonoBehaviour
    {
        public PassivePuSO passivePuSO;
        public abstract void PowerUpAction();
    }
}

