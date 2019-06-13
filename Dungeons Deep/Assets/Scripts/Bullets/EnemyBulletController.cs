using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

    public fireType fireType;

    public enemyProjectile bulletPrefab;
    private CameraShake cam;
    private float bulletDamage;

    public float shootSpeed;
    public float maxBullets;
    public float burstSpeed;
    private float bullets;

    private bool CanShoot;
    private bool Restoring;

    private bool inRange;
    public Transform rangeCheck;
    public float checkRadius;
    public LayerMask whatisPlayer;

    private void Start()
    {

        CanShoot = true;

        bullets = 0;

        Restoring = false;

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();

    }

    public void fireBullet(float damage) //function for instantiating and then firing bullets.
    {

        if (fireType.ToString() == "chase") //if the bullet that will be spawned is of the chasing type
        {
            enemyProjectile instance = Instantiate(bulletPrefab);
            instance.setDamage(damage);
            instance.setDirection("chase", transform.position);
            instance.transform.position = this.transform.position;  
        }

        if (fireType.ToString() == "fourspread") // if the bullet that will be spawned is of the directional type.
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == 1)
                {
                    enemyProjectile instance = Instantiate(bulletPrefab);
                    instance.setDamage(damage);
                    instance.setDirection("up", transform.position);
                    instance.transform.position = this.transform.position;
                } else if (i == 2)
                {
                    enemyProjectile instance = Instantiate(bulletPrefab);
                    instance.setDamage(damage);
                    instance.setDirection("down", transform.position);
                    instance.transform.position = this.transform.position;
                }
                else if (i == 3)
                {
                    enemyProjectile instance = Instantiate(bulletPrefab);
                    instance.setDamage(damage);
                    instance.setDirection("left", transform.position);
                    instance.transform.position = this.transform.position;
                }
                else if (i == 4)
                {
                    enemyProjectile instance = Instantiate(bulletPrefab);
                    instance.setDamage(damage);
                    instance.setDirection("right", transform.position);
                    instance.transform.position = this.transform.position;
                }
            }
        }

        if (fireType.ToString() == "eightspread") // if the bullet that will be spawned is of the directional type.
        {
            for (int i = 0; i < 9; i++)
            {
                if (i == 1)
                {
                    enemyProjectile instance = Instantiate(bulletPrefab);
                    instance.setDamage(damage);
                    instance.setDirection("up", transform.position);
                    instance.transform.position = this.transform.position;
                }
                else if (i == 2)
                {
                    enemyProjectile instance = Instantiate(bulletPrefab);
                    instance.setDamage(damage);
                    instance.setDirection("upleft", transform.position);
                    instance.transform.position = this.transform.position;
                }
                else if (i == 3)
                {
                    enemyProjectile instance = Instantiate(bulletPrefab);
                    instance.setDamage(damage);
                    instance.setDirection("left", transform.position);
                    instance.transform.position = this.transform.position;
                }
                else if (i == 4)
                {
                    enemyProjectile instance = Instantiate(bulletPrefab);
                    instance.setDamage(damage);
                    instance.setDirection("downleft", transform.position);
                    instance.transform.position = this.transform.position;
                }

                else if (i == 5)
                {
                    enemyProjectile instance = Instantiate(bulletPrefab);
                    instance.setDamage(damage);
                    instance.setDirection("down", transform.position);
                    instance.transform.position = this.transform.position;
                }

                else if (i == 6)
                {
                    enemyProjectile instance = Instantiate(bulletPrefab);
                    instance.setDamage(damage);
                    instance.setDirection("downright", transform.position);
                    instance.transform.position = this.transform.position;
                }

                else if (i == 7)
                {
                    enemyProjectile instance = Instantiate(bulletPrefab);
                    instance.setDamage(damage);
                    instance.setDirection("right", transform.position);
                    instance.transform.position = this.transform.position;
                }

                else if (i == 8)
                {
                    enemyProjectile instance = Instantiate(bulletPrefab);
                    instance.setDamage(damage);
                    instance.setDirection("rightup", transform.position);
                    instance.transform.position = this.transform.position;
                }
            }
        }
    }

    private void Update()
    {
        inRange = Physics2D.OverlapCircle(rangeCheck.position, checkRadius, whatisPlayer);

        if (inRange == true)
        {

            if (CanShoot == true && bullets > 0)
            {
                CanShoot = false;
                bullets = bullets - 1;
                fireBullet(bulletDamage);
                StartCoroutine(reload());
            }

        }

        if (bullets < 1 && Restoring == false)
        {
            Restoring = true;
            StartCoroutine(restoreBullets());
        }
    }

    IEnumerator reload() // the amount of time in between each shot
    {
        yield return new WaitForSeconds(shootSpeed);
        CanShoot = true;
    }

    IEnumerator restoreBullets() // the class that reloads the bullets once they run out
    {


        yield return new WaitForSeconds(burstSpeed);
        Restoring = false;

        bullets = maxBullets;

    }

    public void SetBulletDamage(float Attack) //alows damage to be set from another script.
    {
        bulletDamage = Attack;
    }
}

public enum fireType { chase, fourspread, eightspread}
