using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abilityController : MonoBehaviour
{

    private CameraShake cam;

    private Transform playerPos;

    private WeaponManager manager;

    private GameObject cooldownText;
    private Text cooldownUIText;

    private bool canUse;

    private float localCoolDownTimer;

    private Animator anim;

    void Start()
    {
        playerPos = GetComponent<Transform>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        cooldownText = GameObject.FindGameObjectWithTag("cooldownText");
        cooldownUIText = cooldownText.GetComponent<Text>();
        anim = GameObject.FindGameObjectWithTag("abilityBox").GetComponent<Animator>();

        canUse = true;
        manager = WeaponManager.instance;
        cooldownText.SetActive(false);
        anim.SetBool("hasUsed", false);


    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            if (InventoryUI.inventoryOpen == false)
            {
                if (manager.currentWeapon != null)
                {
                    if (canUse == true)
                    {
                        StartCoroutine(cam.Shake(.1f, manager.currentWeapon.recoil * 5));
                        StartCoroutine(use());

                        Instantiate(manager.currentWeapon.abilityPrefab, playerPos.position, Quaternion.identity);


                    }
                }

            }
        }

        if (localCoolDownTimer > 0)
        {
            localCoolDownTimer = localCoolDownTimer - Time.deltaTime;
        }

        cooldownUIText.text = Mathf.Round(localCoolDownTimer).ToString();

    }

    IEnumerator use()
    {

        cooldownText.SetActive(true);
        anim.SetBool("hasUsed", true);
        localCoolDownTimer = manager.currentWeapon.abilityCoolDown;
        cooldownUIText.text = manager.currentWeapon.abilityCoolDown.ToString();

        canUse = false;
        yield return new WaitForSeconds(manager.currentWeapon.abilityCoolDown);
        canUse = true;
        cooldownText.SetActive(false);
        anim.SetBool("hasUsed", false);


    }
}
