using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chest : Interactable
{
    public bool locked;
    private bool playerIsInRange;
    private bool opened;
    public Item[] items;
    private Animator animator;
    private ItemPickup lootBag;
    private Vector3 thisPos;
    public float dropRadius;

    public void Start(){
        animator = GetComponent<Animator>();
        animator.SetBool("opened", false);
    }
    public void Update(){
        if (Input.GetKeyDown(KeyCode.E) && playerIsInRange == true && opened == false){
            Interact();
        }
    }

    public override void Interact()
    {
        base.Interact();

        Open();
    }

    public void Open(){
        opened = true;
        animator.SetBool("opened", true);

        
        for (int i = 0; i < items.Length; i++){

            if (items[i] != null){
                
                thisPos = new Vector3(transform.position.x + Random.Range(-dropRadius,dropRadius), transform.position.y + Random.Range(0, -dropRadius), transform.position.z);

                lootBag = Resources.Load<ItemPickup>("drops/DroppedItem");

                lootBag.setItem(items[i]);

                Instantiate(lootBag, thisPos, transform.rotation);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && opened == false){
            playerIsInRange = true;
            InitializeController.promptText.text = "Open";
            InitializeController.promptBox.SetActive(true);        }

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
