using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour {


    public float speed;
    private float damage;

    public float turnSpeed;

    public float bulletLife;


    Vector3 moveDirection;

    private Transform playerPos;


    // Use this for initialization
    void Start () {

        StartCoroutine(destroyAfterTime());

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {


        transform.position = transform.position + moveDirection * speed * Time.deltaTime;

        Quaternion rotation = Quaternion.LookRotation(playerPos.transform.position - transform.position, transform.TransformDirection(Vector3.down));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    IEnumerator destroyAfterTime()
    {
        yield return new WaitForSeconds(bulletLife);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "wall")
        {

            VisualEffects.spawnHitEffect(transform);
            Destroy(gameObject);

        } else if (other.tag == "Player"){

            if (PlayerController.invincible == false)
            {

            damage = damage + Random.Range(-3, 3);
            DamageTextController.CreateDamageText(damage.ToString(), transform, "Red");
            StatController.playerHealth = StatController.playerHealth - damage;
            VisualEffects.spawnHitEffect(transform);
            Destroy(gameObject);
            }


        }
    }

    public void setDamage(float damageAmount)
    {
        damage = damageAmount;
    }

    public void setDirection(string dir)
    {

        if (dir == "chase")
        {
            moveDirection = (playerPos.position - transform.position);
            moveDirection.z = 0;
        } else if (dir == "up")
        {
            moveDirection = new Vector3(0, 1);
        }
        else if (dir == "down")
        {
            moveDirection = new Vector3(0, -1);
        }
        else if (dir == "right")
        {
            moveDirection = new Vector3(-1, 0);
        }
        else if (dir == "left")
        {
            moveDirection = new Vector3(1, 0);
        }

        moveDirection.Normalize();

    }
}
