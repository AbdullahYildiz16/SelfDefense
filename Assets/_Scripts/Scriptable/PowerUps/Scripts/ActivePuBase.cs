using System.Collections;
using System.Collections.Generic;
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
            coolDownSeconds = activePuSO.CoolDownDelay;
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
            coolDownSeconds = activePuSO.CoolDownDelay;
            IsCoolingDown = true;
        }
        public virtual void EndCoolDown()
        {
            IsCoolingDown = false;
        }
    }
}