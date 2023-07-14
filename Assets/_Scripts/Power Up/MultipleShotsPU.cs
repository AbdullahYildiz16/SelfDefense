namespace _Scripts.PowerUp
{ 
    public class MultipleShotsPU : PassivePuBase
    {
        public void MultpShotClicked()
        {
            if (passivePuSO.money.BuyIfCanAfford(passivePuSO.passivePuData.Price))
            {
                passivePuSO.shootSettings.ShootSettingsData.MultipleFire++;
                passivePuSO.IncrLevelAndPrice();
            }
        }
        public override void PowerUpAction()
        {
            MultpShotClicked();
        }

        
    }
    
}
