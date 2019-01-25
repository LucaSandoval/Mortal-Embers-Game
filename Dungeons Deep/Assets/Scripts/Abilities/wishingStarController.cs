using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wishingStarController : MonoBehaviour {

    private float uses;
    private float maxUses = 20;
    private float healingPower = 50;
    public static bool isHealing = false;

    private float healingTime = 0.9f;

    public Text usesText;
    private GameObject healEffect;
    private Animator anim;
    public Image starIcon;
    public Sprite[] frames;

    void Start()
    {
        healEffect = Resources.Load<GameObject>("hitEffects/healEffect");

        uses = maxUses;

        anim = GameObject.FindGameObjectWithTag("wishingStarBase").GetComponent<Animator>();

        anim.SetBool("isHealing", false);
        starIcon.sprite = frames[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isHealing == false) //checks if the R key is pressed and if you have any uses left.
        {
            if (StatController.playerHealth < StatController.playerMaxHealth) //checks if the player has full health or not.
            {
                if (uses > 0)
                {
                    StartCoroutine(heal());
                }

            }
        }

        usesText.text = uses.ToString();

        if (uses / maxUses * 100 > 90) //checks the percentage of your total uses that have been used and changes the star image acordingly. 
        {
            starIcon.sprite = frames[0];

        } else if (uses / maxUses * 100 > 70)
        {
            starIcon.sprite = frames[1];
        }
        else if (uses / maxUses * 100 > 50)
        {
            starIcon.sprite = frames[2];
        }
        else if (uses / maxUses * 100 > 30)
        {
            starIcon.sprite = frames[3];
        }
        else if (uses / maxUses * 100 > 1)
        {
            starIcon.sprite = frames[4];
        }
        else
        {
            starIcon.sprite = frames[5];
        }



    }

    IEnumerator heal() //Heals the player while also doing the various animations.
    {
        isHealing = true;
        anim.SetBool("isHealing", true);

        DamageTextController.CreateDamageText(healingPower.ToString(), PlayerController.globalPLayerPosition, "Green");
        StatController.playerHealth = StatController.playerHealth + healingPower;
        uses = uses - 1;
        healEffect = Resources.Load<GameObject>("hitEffects/healEffect");

        var thisHealEffect = Instantiate(healEffect);
        thisHealEffect.transform.position = PlayerController.globalPLayerPosition.position;


        yield return new WaitForSeconds(healingTime);
        isHealing = false;
        anim.SetBool("isHealing", false);


    }

}
