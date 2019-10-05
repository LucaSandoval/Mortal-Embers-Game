using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private CameraShake cam;

    private Transform playerPos;

    private bool CanShoot;

    public float fireRate;

    private WeaponManager manager;

	// Use this for initialization
	void Start () {
        playerPos = GetComponent<Transform>();
        CanShoot = true;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();

        manager = WeaponManager.instance;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0) && pauseController.gamePaused == false)
        {
            if (InventoryUI.inventoryOpen == false)
            {
                if(manager.currentWeapon != null){

                    if (CanShoot == true && StatController.Stamina > 0)
                    {
                        StatController.Stamina = StatController.Stamina - manager.currentWeapon.staminaCost;
                        StartCoroutine(cam.Shake(.1f, manager.currentWeapon.recoil));

                        StartCoroutine(shoot());
                        Instantiate(manager.currentWeapon.bulletPrefab, playerPos.position, Quaternion.identity);
                    }
                }

            }

        }

    }

    IEnumerator shoot()
    {
        CanShoot = false;
        yield return new WaitForSeconds(manager.currentWeapon.fireRate);
        CanShoot = true;
    }

    
}
