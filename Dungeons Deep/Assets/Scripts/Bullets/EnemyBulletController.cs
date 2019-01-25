using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

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

        bullets = maxBullets;

        Restoring = false;

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();

    }

    public void fireBullet(float damage) //function for instantiating and then firing bullets.
    {
        enemyProjectile instance = Instantiate(bulletPrefab);
        instance.setDamage(damage);
        instance.transform.position = this.transform.position;  
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
                StartCoroutine(cam.Shake(.1f, 0.075f));
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
