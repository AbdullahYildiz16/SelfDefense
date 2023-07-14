namespace _Scripts.PowerUp
{
    public class AddDiagShotsPU : PassivePuBase
    { 
        
        public void AddDiagShotClicked()
        {
            if (passivePuSO.money.BuyIfCanAfford(passivePuSO.passivePuData.Price))
            {
                passivePuSO.shootSettings.ShootSettingsData.CanDiagonalFire = true;
                passivePuSO.IncrLevelAndPrice();    
            }
        }

        public override void PowerUpAction()
        {
            AddDiagShotClicked();
        }
    }
}

