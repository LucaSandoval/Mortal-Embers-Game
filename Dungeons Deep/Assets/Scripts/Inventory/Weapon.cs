using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class Weapon : Item {

    public GameObject bulletPrefab;
    public GameObject abilityPrefab;
    public Sprite abilityIcon;
    public float abilityCoolDown;
    public float abilityPower;

    public float physicalDamage;
    public float lifeDamage;
    public float chaosDamage;
    public float soulDamage;
    public float starDamage;

    public float fireRate = 0.1f;
    public float shootSpeed = 15;
    public float recoil = 0f;

    public float staminaCost;

    public override void Use()
    {
        WeaponManager.instance.Equip(this);

    }

}
