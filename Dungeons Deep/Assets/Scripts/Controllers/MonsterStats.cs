using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour {

    private EnemyBulletController bulletControllScript;
    private LootController lootControllerScript;

    public float Health;
    public float Attack;
    public float Defence;
    public float Luck;

    private SpriteRenderer ren;

    private float damage;

    private bool canTakeDamage;

    public void Start()
    {
        bulletControllScript = this.GetComponent<EnemyBulletController>();
        lootControllerScript = this.GetComponent<LootController>();
        bulletControllScript.SetBulletDamage(Attack); //sets the enemies bullet damage initialy.
        ren = GetComponent<SpriteRenderer>();
        canTakeDamage = true;
        
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
        if (canTakeDamage == true)
        {

            if (other.tag == "Bullet")
            {
                canTakeDamage = false;

                StartCoroutine(damageBuff());

                damage = WeaponManager.instance.currentWeapon.physicalDamage + Random.Range(-3, 3);

                DamageTextController.CreateDamageText(damage.ToString(), transform, "Gray");

                Health = Health - damage;


            } else if (other.tag == "Ability")
            {
                canTakeDamage = false;

                StartCoroutine(damageBuff());

                damage = WeaponManager.instance.currentWeapon.abilityDamage + Random.Range(-3, 3);

                DamageTextController.CreateDamageText(damage.ToString(), transform, "Yellow");

                Health = Health - damage;

            }
        }
    }

    IEnumerator damageBuff()
    {
        yield return new WaitForSeconds(0.1f);
        canTakeDamage = true;
    }

}
