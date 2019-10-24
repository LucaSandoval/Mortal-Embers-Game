using UnityEngine;

public class InventoryUI : MonoBehaviour {


    public Transform itemsParent;
    public  GameObject inventoryUI;
    public GameObject displayUI;
    public static bool inventoryOpen;


    Inventory inventory;

    InventorySlot[] slots;

	// Use this for initialization
	void Start () {

        inventoryOpen = false;

        
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        //inventoryOpen = !inventoryUI.activeSelf;

    }

    // Update is called once per frame
    void Update () {

        if (DiolaugeManager.inDiolauge == false && pauseController.gamePaused == false)
        {
            
            if (Input.GetKeyDown(KeyCode.Q) && DisplayUI.isDisplayWindowOpen == true) //alows the player to open their inventory using the Q key.
            {
                DisplayUI.isDisplayWindowOpen = false;
                displayUI.SetActive(false);
                inventoryUI.SetActive(!inventoryUI.activeSelf);
                inventoryOpen = !inventoryOpen;


            } else if (Input.GetKeyDown(KeyCode.Q))
            {
                
                inventoryUI.SetActive(!inventoryUI.activeSelf);
                inventoryOpen = !inventoryOpen;


            }
            

        }
		
	}

    public void triggerInventory(){


        DisplayUI.isDisplayWindowOpen = false;
        inventoryUI.SetActive(false);
        inventoryOpen = false;
             
        
    }

    void UpdateUI() // a for loop that runs through your total inventory slots and sets the slot to display the item or not.
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            } else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
