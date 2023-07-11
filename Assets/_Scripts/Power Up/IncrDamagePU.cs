namespace _Scripts.PowerUp
{
    
    public class IncrDamagePU : PassivePuBase
    {
        public void IncrDamageClicked()
        {
            if (passivePuSO.money.BuyIfCanAfford(passivePuSO.Price))
            {
                passivePuSO.shootSettings.CharacterDamage *= 1.1f;
                passivePuSO.IncrLevelAndPrice();
            }
        }

        public override void PowerUpAction()
        {
            IncrDamageClicked();
        }
    }
}

