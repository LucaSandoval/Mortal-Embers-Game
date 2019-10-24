using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour {

    public Image displayIcon;
    public Text displayText;
    public Text buttonOne;
    public Text itemName;

    public Item thisItem;

    public static bool isDisplayWindowOpen;

    public InventorySlot itemSlot;

    public GameObject damageTypes; //types of damage in UI.

    public GameObject physicalIcon;
    public Text physicalText;

    public Text lifeText;
    public GameObject lifeIcon;

    public Text chaosText;
    public GameObject chaosIcon;

    public Text soulText;
    public GameObject soulIcon;

    public Text starText;
    public GameObject starIcon;

    private void Awake()
    {
        physicalIcon.SetActive(false);
        lifeIcon.SetActive(false);
        chaosIcon.SetActive(false);
        soulIcon.SetActive(false);
        starIcon.SetActive(false);

    }



    public void ItemUseButton()
    {
        thisItem.Use();
        itemSlot.ClearSlot();
        Inventory.instance.Remove(thisItem);
        isDisplayWindowOpen = false;
    }

    public void ItemDropButton()
    {
        itemSlot.dropButton();
        Inventory.instance.Remove(thisItem);
        isDisplayWindowOpen = false;
    }


    public void Update()
    {
        if (thisItem == null){
            gameObject.SetActive(false);
        }
    }

}
