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

    private float damage;



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

        if (other.tag == "Bullet")
        {

            damage = WeaponManager.instance.currentWeapon.physicalDamage + Random.Range(-3, 3);

            DamageTextController.CreateDamageText(damage.ToString(), transform, "Gray");

            Health = Health - damage;


        } else if (other.tag == "Ability")
        {
            damage = WeaponManager.instance.currentWeapon.abilityDamage + Random.Range(-3, 3);

            DamageTextController.CreateDamageText(damage.ToString(), transform, "Yellow");

            Health = Health - damage;

        }
    }

}
