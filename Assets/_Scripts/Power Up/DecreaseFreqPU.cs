namespace _Scripts.PowerUp
{
    public class DecreaseFreqPU : PassivePuBase
    {
        
        public void DecreaseFreqClicked()
        {
            if (passivePuSO.money.BuyIfCanAfford(passivePuSO.passivePuData.Price))
            {
                passivePuSO.shootSettings.ShootSettingsData.FireFrequency -= 0.1f;
                passivePuSO.IncrLevelAndPrice();
            }
        }

        public override void PowerUpAction()
        {
            DecreaseFreqClicked();
        }
    }
}

