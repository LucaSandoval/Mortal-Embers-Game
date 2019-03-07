using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilityController : MonoBehaviour {

    private CameraShake cam;

    private Transform playerPos;

    private WeaponManager manager;

    private bool canUse;

    void Start () {
        playerPos = GetComponent<Transform>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();

        canUse = true;
        manager = WeaponManager.instance;
    }
	
	void Update () {
		
        if (Input.GetMouseButtonDown(1))
        {
            if (InventoryUI.inventoryOpen == true)
            {
                if (manager.currentWeapon != null)
                {
                    if (canUse == true)
                    {
                        StartCoroutine(cam.Shake(.1f, manager.currentWeapon.recoil * 5));
                        StartCoroutine(use());

                        Instantiate(manager.currentWeapon.abilityPrefab, playerPos.position, Quaternion.identity);

                        //manager.currentWeapon.abilityPrefab.transform.parent = playerPos.transform;

                    }
                }

            }
        }
	}

    IEnumerator use()
    {
        canUse = false;
        yield return new WaitForSeconds(manager.currentWeapon.abilityCoolDown);
        canUse = true;
    }
}
