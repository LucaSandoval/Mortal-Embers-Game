using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour {

    public EnemyBulletController bulletControllScript;
    public LootController lootControllerScript;

    public float Health;
    public float Attack;
    public float Defence;
    public float Luck;

    private SpriteRenderer ren;


    public void Start()
    {
        bulletControllScript.SetBulletDamage(Attack); //sets the enemies bullet damage initialy.
        ren = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        if(Health < 0)
        {
            VisualEffects.spawnDeathExplosion(transform); //creates death effect
            lootControllerScript.dropLoot(); //drops items
            Destroy(gameObject); //destorys object
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            //ren.color = new Color(5,5,5);
            //Debug.Log(ren.color);
            Health = Health - WeaponManager.instance.currentWeapon.physicalDamage;
        } else if (other.tag == "Ability")
        {
            Health = Health - WeaponManager.instance.currentWeapon.abilityPower;

        }
    }

}
