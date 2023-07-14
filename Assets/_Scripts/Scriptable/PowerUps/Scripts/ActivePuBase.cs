using UnityEngine;
using _Scripts.Scriptables;

namespace _Scripts.PowerUp
{
    public abstract class ActivePuBase : MonoBehaviour
    {
        public ActivePuSO activePuSO;
        protected float coolDownSeconds;
        public bool IsCoolingDown;
        private void Start()
        {
            coolDownSeconds = activePuSO.activePuData.CoolDownDelay;
        }
        public virtual void RefreshCoolDown()
        {
            if (!IsCoolingDown) return;           
            coolDownSeconds--;
            if (coolDownSeconds == 0) EndCoolDown();
        }
        public abstract void PowerUpAction();
        public virtual void StartCoolDown()
        {
            coolDownSeconds = activePuSO.activePuData.CoolDownDelay;
            IsCoolingDown = true;
        }
        public virtual void EndCoolDown()
        {
            IsCoolingDown = false;
        }
    }
}