using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    
    public float bulletLife;

    public float turnSpeed;

    Vector3 moveDirection;

    

    void Start()
    {
        StartCoroutine(destroyAfterTime());


        moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        moveDirection.z = 0;
        moveDirection.Normalize();
    }

    private void Update()   
    {

        transform.position = transform.position + moveDirection * WeaponManager.instance.currentWeapon.shootSpeed * Time.deltaTime;


        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

    }


    void OnTriggerEnter2D(Collider2D other)
    { 

        if (other.tag == "wall")
        {

            VisualEffects.spawnHitEffect(transform);
            Destroy(gameObject);
         
        } else if (other.tag == "enemy")
        {

            VisualEffects.spawnHitEffect(transform);
            Destroy(gameObject);
        }
    }



    IEnumerator destroyAfterTime()
    {
        yield return new WaitForSeconds(bulletLife);
        Destroy(gameObject);
    }

}
