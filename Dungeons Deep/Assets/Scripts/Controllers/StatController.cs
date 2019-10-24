using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatController : MonoBehaviour {

    float level;
    public static float currentXP;
    float xpToNextLevel;
    public static float Stamina;
    public static float MaxStamina;
    private float regenSpace = 0.1f; //esentially a little bit of buffer time for when the stamina bar hits zero so the calculations can be done.
    private float effectStamina; //a float used to visually show that your stamina is regenerating once you have run out. 

    private float tempStamina; //used to check if your stamina has changed every frame

    private float bufferCount; //used to create a delay in stamina restoration


    public static float playerMaxHealth;
    public static float playerHealth;

    public Slider staminaSilder;
    public Slider staminaRefillSlider;
    public Slider healthSlider;

    public Text healthText;
    public Text staminaText;

    public Text maxHPText;
    public Text maxStaminaText;

    public Text levelTxt;
    public Text xpText;

    private bool canRegen;
    private bool canRegenCooldown;
    private bool canEffectRegen;

    void Start()
    {
        level = 1;
        currentXP = 0;
        xpToNextLevel = 100;

        MaxStamina = 20;
        effectStamina = 0;


        playerMaxHealth = 50;
        
        Stamina = MaxStamina;

        tempStamina = Stamina;

        playerHealth = playerMaxHealth;
        canRegen = true;
        canRegenCooldown = true;
        canEffectRegen = false;
    }

    void Update()
    {

        if (bufferCount > 0) //counts down frames before your stamina can start to regen
        {
            bufferCount = bufferCount - 0.1f;
        }

        if (Stamina < tempStamina) //detects whether or not you have used stamina and if so, begin waiting for colldown to be availabe. 
        {
            bufferCount = 2.5f;
        }

        if (bufferCount < 0.1 && Stamina > 0) //if you are able to regen stamina, begin doing so
        {

            if (Stamina < MaxStamina && canRegen == true && Stamina > 0 + regenSpace) //cheks if your Stamina is: 1. Less than Max, 2. Able to be regenerated that frame, 3. not zero'ed out.
            {
                StartCoroutine(regen());
            } 

        }

        if (Stamina < 0 + regenSpace && canRegenCooldown == true) //if you are Zero'ed out, then wait for full bar to recharge before you can use it again. 
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

        healthText.text = playerHealth + "/" + playerMaxHealth;
        staminaText.text = Mathf.Round(Stamina) + "/" + MaxStamina;

        if (playerHealth > playerMaxHealth) //makes it so that you cannot heal above your maximum health value.
        {
            playerHealth = playerMaxHealth;
        }

        tempStamina = Stamina; //sets the temp stamina to your current stamina

        maxStaminaText.text = MaxStamina.ToString();
        maxHPText.text = playerMaxHealth.ToString();
        levelTxt.text = level.ToString();
        xpText.text = currentXP.ToString() + "/" + xpToNextLevel.ToString();

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
