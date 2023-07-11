using System.Collections;
using UnityEngine;
using _Scripts.UI;
namespace _Scripts.PowerUp
{
    public class FastShotPU : ActivePuBase
    {
        [SerializeField] ActivePuUI activePuUI;
        WaitForSeconds fastShotTime = new WaitForSeconds(3);
        void OnFastShotBtnClicked()
        {
            if (IsCoolingDown) return;                                      
            if (!activePuSO.money.BuyIfCanAfford(activePuSO.Price)) return;
            StartCoolDown();
            activePuUI.StartCoolDownUI();
            StartCoroutine(FastShot());
        }
        IEnumerator FastShot()
        {
            float _startFreq = activePuSO.shootSettings.FireFrequency;
            activePuSO.shootSettings.FireFrequency = 0.1f;
            activePuSO.shootSettings.IsFastShot = true;
            yield return fastShotTime;
            activePuSO.shootSettings.FireFrequency = _startFreq;
            activePuSO.shootSettings.IsFastShot = false;
        }
        
        public override void PowerUpAction()
        {
            OnFastShotBtnClicked();
        }
        
    }
}


