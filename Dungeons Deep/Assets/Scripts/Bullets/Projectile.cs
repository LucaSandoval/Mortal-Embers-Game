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

        faceMouse();


    }

    private void Update()   
    {

        transform.position = transform.position + moveDirection * WeaponManager.instance.currentWeapon.shootSpeed * Time.deltaTime;

    }

    public void faceMouse(){

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
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
