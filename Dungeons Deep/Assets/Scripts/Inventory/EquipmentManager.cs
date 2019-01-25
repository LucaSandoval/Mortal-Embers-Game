using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour {

    #region singleton
    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion


    public Equipment[] currentEquipment;

    public Image Head;
    public Image Body;
    public Image Legs;
    public Image Charm;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];

        Head.enabled = false;
        Body.enabled = false;
        Legs.enabled = false;
        Charm.enabled = false;

    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;


        if(currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        currentEquipment[slotIndex] = newItem;
    }

    void Update()
    {
        if (currentEquipment[0] != null && currentEquipment[0].icon != null)
        {
            Head.enabled = true;
            Head.sprite = currentEquipment[0].icon;
        }
        else
        {
            Head.sprite = null;
            Head.enabled = false;
        }

        if (currentEquipment[1] != null && currentEquipment[1].icon != null)
        {
            Body.enabled = true;
            Body.sprite = currentEquipment[1].icon;
        }
        else
        {
            Body.sprite = null;
            Body.enabled = false;
        }
        if (currentEquipment[2] != null && currentEquipment[2].icon != null)
        {
            Legs.enabled = true;
            Legs.sprite = currentEquipment[2].icon;
        }
        else
        {
            Legs.sprite = null;
            Legs.enabled = false;
        }
        if (currentEquipment[3] != null && currentEquipment[3].icon != null)
        {
            Charm.enabled = true;
            Charm.sprite = currentEquipment[3].icon;
        }
        else
        {
            Charm.sprite = null;
            Charm.enabled = false;
        }

    }
}
