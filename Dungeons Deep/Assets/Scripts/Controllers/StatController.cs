using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatController : MonoBehaviour {

    public static float Stamina;
    public static float MaxStamina;
    private float regenSpace = 0.1f; //esentially a little bit of buffer time for when the stamina bar hits zero so the calculations can be done.
    private float effectStamina; //a float used to visually show that your stamina is regenerating once you have run out. 

    public static float damage;


    public static float playerMaxHealth;
    public static float playerHealth;

    public Slider staminaSilder;
    public Slider staminaRefillSlider;
    public Slider healthSlider;

    private bool canRegen;
    private bool canRegenCooldown;
    private bool canEffectRegen;

    void Start()
    {
        MaxStamina = 10;
        effectStamina = 0;

        damage = 15;

        playerMaxHealth = 100;
        
        Stamina = MaxStamina;
        playerHealth = playerMaxHealth;
        canRegen = true;
        canRegenCooldown = true;
        canEffectRegen = false;
    }

    void Update()
    {
        
        if (Stamina < MaxStamina && canRegen == true && Stamina > 0 + regenSpace) //cheks if your Stamina is 1. Less than Max, 2. Able to be regenerated that frame, 3. not zero'ed out.
        {
            StartCoroutine(regen());

        } else if (Stamina < 0 + regenSpace && canRegenCooldown == true) //if you are Zero'ed out, then wait for full bar to recharge before you can use it again. 
        {
            StartCoroutine(regenCooldown());
            canRegenCooldown = false;
            canRegen = false;
        }

        if (canEffectRegen == true && effectStamina < MaxStamina) //fils up the effect slider to represent that stamina is refillinf after it has zero'ed out.
        {
            StartCoroutine(effectRegen());
        }


        staminaSilder.maxValue = MaxStamina;
        staminaRefillSlider.maxValue = MaxStamina;
        staminaSilder.value = Stamina;
        staminaRefillSlider.value = effectStamina;

        healthSlider.maxValue = playerMaxHealth;
        healthSlider.value = playerHealth;

        if (playerHealth > playerMaxHealth) //makes it so that you cannot heal above your maximum health value.
        {
            playerHealth = playerMaxHealth;
        }
    }

    IEnumerator regen() //regens stamina every frame. (WIP)
    {
        canRegen = false;
        Stamina = Stamina + 0.1f;
        yield return new WaitForSeconds(0.01f);
        canRegen = true;
    }

    IEnumerator effectRegen() // regens the effect stamina every frame.
    {
        canEffectRegen = false;
        effectStamina = effectStamina + 0.1f;
        yield return new WaitForSeconds(0.01f);
        canEffectRegen = true;

    }

    IEnumerator regenCooldown() //makes the player wait until there stamina is full before they are able to use it again.
    {
        effectStamina = 0;
        canEffectRegen = true;
        yield return new WaitForSeconds(MaxStamina / 2f);
        Stamina = MaxStamina;
        effectStamina = 0;
        canRegenCooldown = true;
        canRegen = true;
        canEffectRegen = false;
    }
}
