using UnityEngine;

public class ItemPickup : Interactable {

    private bool playerIsInRange;
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp) //checking wether or not there was enough inventory space to take the new item.
        {
            DamageTextController.CreateDamageText("Obtained " + item.name, transform, "Gray");
            Destroy(gameObject);
        }
    }

    public void setItem(Item newItem)
    {
        item = newItem; //allows dropped items to set there item.
    }

    void Update() //checking for player pickup.
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsInRange == true)
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //checking if player is in range.
    {
        if (other.tag == "Player")
        {
            playerIsInRange = true;
            InitializeController.promptBox.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other) //checking if player is not in range.
    {
        if (other.tag == "Player")
        {
            playerIsInRange = false;
            InitializeController.promptBox.SetActive(false);

        }
    }
}
