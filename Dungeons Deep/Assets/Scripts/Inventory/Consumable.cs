using UnityEngine;


[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item {

    public float healthHeal = 0f;
    public float staminaHeal = 0f;

    public healingType healingType;

    public float healingInterval;

    public override void Use()
    {
        if (healingType.ToString() == (string)"instant")
        {
            if (healthHeal > 0)
            {
                DamageTextController.CreateDamageText(healthHeal.ToString(), PlayerController.globalPLayerPosition, "Green");
                StatController.playerHealth = StatController.playerHealth + healthHeal;
            }

            if (staminaHeal > 0)
            {
                DamageTextController.CreateDamageText(staminaHeal.ToString(), PlayerController.globalPLayerPosition, "Blue");
                StatController.Stamina = StatController.Stamina + staminaHeal;
            }

        } else if (healingType.ToString() == (string)"passive")
        {

        }
    }

}

public enum healingType {instant, passive}
