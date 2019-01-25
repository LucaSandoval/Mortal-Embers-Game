using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour {

    #region singleton
    public static WeaponManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public Weapon currentWeapon;

    public Image weaponImage;
    public Image abilityImage;


    void Start()
    {
        weaponImage.enabled = false;
        abilityImage.enabled = false;

    }

    public void Equip(Weapon newWeapon)
    {
        Weapon oldWeapon = null;

        if(currentWeapon != null)
        {
            oldWeapon = currentWeapon;
            Inventory.instance.Add(oldWeapon);

        }

        currentWeapon = newWeapon;
    }

    void Update()
    {
        if (currentWeapon != null && currentWeapon.icon != null)
        {
            weaponImage.enabled = true;
            abilityImage.enabled = true;
            abilityImage.sprite = currentWeapon.abilityIcon;
            weaponImage.sprite = currentWeapon.icon;
        }
    }
}
