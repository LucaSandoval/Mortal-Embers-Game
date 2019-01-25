using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSlot equipSlot;
    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        //meant to overidden.
        EquipmentManager.instance.Equip(this);
    }

}

public enum EquipmentSlot { Helmet, Chestplate, Boots, Charm}
