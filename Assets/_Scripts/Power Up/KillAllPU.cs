using UnityEngine;
using _Scripts.UI;

namespace _Scripts.PowerUp
{
    public class KillAllPU : ActivePuBase
    {
        [SerializeField] CharacterTarget characterTarget;
        [SerializeField] ActivePuUI activePuUI;
        void OnKillAllBtnClicked()
        {
            if (IsCoolingDown) return;
            if (!activePuSO.money.BuyIfCanAfford(activePuSO.activePuData.Price)) return;
            StartCoolDown();
            activePuUI.StartCoolDownUI();
            characterTarget.DrawEnemyRadius(25f);
            var _activeEnemies = characterTarget.ActiveEnemiesList;
            foreach (var enemy in _activeEnemies)
            {
                if(enemy.TryGetComponent<IHittable>(out IHittable hittable))
                {
                    hittable.OnHit();
                }                    
            }           
        }
       

        public override void PowerUpAction()
        {
            OnKillAllBtnClicked();
        }
    }
}

