using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Image icon;

    private GameObject displayWindow;
    private ItemPickup lootBag;
    public DisplayUI displayWindowScipt;

    private Transform playerPosition;

    public Item item;
    public Weapon weapon;

    private void Start()
    {
        displayWindow = GameObject.Find("Canvas/Inventory/InventoryDisplay/DisplayParent");
    }

    public void OnEnable(){
        GetComponentInChildren<Image>().color = new Color(0, 0, 0, 1);
    }

    public void Highlight(){
        GetComponentInChildren<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1);
    }

    public void UnHighlight(){
        GetComponentInChildren<Image>().color = new Color(0, 0, 0, 1);
    }

    public void AddItem(Item newItem)
    {
        if (newItem is Weapon)
        {
            weapon = newItem as Weapon;
            icon.sprite = weapon.icon;
            item = null;

        } else
        {
            item = newItem;
            icon.sprite = item.icon;
            weapon = null;
        }
        icon.enabled = true;
    }

    public void ClearSlot()
    {

        item = null;
        weapon = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void dropButton()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  // this gets the position of the player so the Inven.slot can use it 
        lootBag = Resources.Load<ItemPickup>("drops/DroppedItem");
        
        if (weapon != null)
        {
            lootBag.setItem(weapon);

        }
        else
        {
            lootBag.setItem(item);

        }

        Instantiate(lootBag, playerPosition.position, transform.rotation);


        item = null;
        weapon = null;
        icon.sprite = null;
        icon.enabled = false;
    }


    public void SelectItem()
    {

        if (item != null || weapon != null) //checks wether or not the slot has either an item or a weapon in it.
        {

            if (weapon == null) //if it has an item then...
            {

                displayWindow.SetActive(true);
                DisplayUI.isDisplayWindowOpen = true;
                displayWindowScipt.itemSlot = this;
                displayWindowScipt.thisItem = item;
                displayWindowScipt.displayIcon.sprite = item.icon;
                displayWindowScipt.displayText.text = item.description;
                displayWindowScipt.itemName.text = item.name;

                displayWindowScipt.damageTypes.SetActive(false);


                if (item.useText.ToString() == (string)"Equip")
                {
                    displayWindowScipt.buttonOne.text = "EQUIP";
                }
                else if (item.useText.ToString() == (string)"Drink")
                {
                    displayWindowScipt.buttonOne.text = "DRINK";

                }
                else if (item.useText.ToString() == (string)"Use")
                {
                    displayWindowScipt.buttonOne.text = "USE";
                }
                else if (item.useText.ToString() == (string)"Inspect")
                {
                    displayWindowScipt.buttonOne.text = "INSPECT";
                }
                else
                {
                    Debug.LogError("Somehow this happened, which means you screwed up really bad.");
                }

            } else { //if it has a weapon then...


                displayWindow.SetActive(true);
                DisplayUI.isDisplayWindowOpen = true;
                displayWindowScipt.itemSlot = this;
                displayWindowScipt.thisItem = weapon;
                displayWindowScipt.displayIcon.sprite = weapon.icon;
                displayWindowScipt.displayText.text = weapon.description;
                displayWindowScipt.itemName.text = weapon.name;

                displayWindowScipt.damageTypes.SetActive(true);

                if (weapon.physicalDamage > 0)
                {
                    displayWindowScipt.physicalIcon.SetActive(true);
                    displayWindowScipt.physicalText.text = weapon.physicalDamage.ToString();
                }
                else
                {
                    displayWindowScipt.physicalIcon.SetActive(false);
                }

                if (weapon.lifeDamage > 0)
                {
                    displayWindowScipt.lifeIcon.SetActive(true);
                    displayWindowScipt.lifeText.text = weapon.lifeDamage.ToString() + "%";
                }
                else
                {
                    displayWindowScipt.lifeIcon.SetActive(false);
                }

                if (weapon.chaosDamage > 0)
                {
                    displayWindowScipt.chaosIcon.SetActive(true);
                    displayWindowScipt.chaosText.text = weapon.chaosDamage.ToString() + "%";
                }
                else
                {
                    displayWindowScipt.chaosIcon.SetActive(false);
                }

                if (weapon.soulDamage > 0)
                {
                    displayWindowScipt.soulIcon.SetActive(true);
                    displayWindowScipt.soulText.text = weapon.soulDamage.ToString() + "%";
                }
                else
                {
                    displayWindowScipt.soulIcon.SetActive(false);
                }

                if (weapon.starDamage > 0)
                {
                    displayWindowScipt.starIcon.SetActive(true);
                    displayWindowScipt.starText.text = weapon.starDamage.ToString() + "%";
                }
                else
                {
                    displayWindowScipt.starIcon.SetActive(false);
                }



                if (weapon.useText.ToString() == (string)"Equip")
                {
                    displayWindowScipt.buttonOne.text = "EQUIP";
                }
                else if (weapon.useText.ToString() == (string)"Drink")
                {
                    displayWindowScipt.buttonOne.text = "DRINK";

                }
                else if (weapon.useText.ToString() == (string)"Use")
                {
                    displayWindowScipt.buttonOne.text = "USE";
                }
                else if (weapon.useText.ToString() == (string)"Inspect")
                {
                    displayWindowScipt.buttonOne.text = "INSPECT";
                }
                else
                {
                    Debug.LogError("Somehow this happened, which means you screwed up really bad.");
                }


            }
        }

    }


}
	


