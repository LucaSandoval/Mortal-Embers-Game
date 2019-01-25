using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item {

    public float healthHeal = 0f;
    public float staminaHeal = 0f;

    public override void Use()
    {
        DamageTextController.CreateDamageText(healthHeal.ToString(), PlayerController.globalPLayerPosition, "Green");
        StatController.playerHealth = StatController.playerHealth + healthHeal;
    }
}
