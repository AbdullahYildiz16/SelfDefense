namespace _Scripts.PowerUp
{ 
    public class MultipleShotsPU : PassivePuBase
    {
        public void MultpShotClicked()
        {
            if (passivePuSO.money.BuyIfCanAfford(passivePuSO.Price))
            {
                passivePuSO.shootSettings.MultipleFire++;
                passivePuSO.IncrLevelAndPrice();
            }
        }
        public override void PowerUpAction()
        {
            MultpShotClicked();
        }

        
    }
    
}
