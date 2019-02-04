using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour {



    public Item[] drops;
    public float[] chance;

    public float stardustDrop;

    private float dice;

    private ItemPickup lootBag;

    private Vector3 thisPos;

    public float dropRadius;

    public void dropLoot()
    {
        stardustController.addedAmount = stardustController.addedAmount + stardustDrop + Random.Range(-3, 3);

        for (int i = 0; i < drops.Length; i++)
        {
            thisPos = new Vector3(transform.position.x + Random.Range(-dropRadius,dropRadius), transform.position.y + Random.Range(-dropRadius, dropRadius), transform.position.z);

            if (drops[i] != null) //checks if the item in the array is actually there.
            {
               

                if(chance[i] != 0) //checks if the drop chance is > 0.
                {
                    dice = Random.Range(0, 100); //rolls dice for drop.

                    if (dice <= chance[i]) //checks if it landed in the chance range.
                    {                        
                        lootBag = Resources.Load<ItemPickup>("drops/DroppedItem");

                        lootBag.setItem(drops[i]);

                        Instantiate(lootBag, thisPos, transform.rotation);
                    }

                } else
                {
                    Debug.Log(drops[i].name + "'s drop chance is zero. Why did you do that?"); //prints if the items chance is zero.
                }              
            } 
        }      
    }



}
