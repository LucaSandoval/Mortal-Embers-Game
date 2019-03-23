using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerSlash : MonoBehaviour
{

    public float abilityLife;

    private float damage;

    private Transform playerPosition;



    void Start()
    {
        damage = WeaponManager.instance.currentWeapon.physicalDamage * 3f;
        StartCoroutine(destroyAfterTime());
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


    }

    void Update()
    {

        var mouse = Input.mousePosition;
        var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position = playerPosition.position;

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "enemy")
        {
            damage = damage + Random.Range(-3, 3);
            DamageTextController.CreateDamageText(damage.ToString(), transform, "Gray");


            VisualEffects.spawnHitEffect(transform);
        }
    }

    IEnumerator destroyAfterTime()
    {
        yield return new WaitForSeconds(abilityLife);
        Destroy(gameObject);
    }
}
