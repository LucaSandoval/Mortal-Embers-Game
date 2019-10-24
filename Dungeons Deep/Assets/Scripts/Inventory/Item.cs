using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {



    new public string name = "New Item";
    [TextArea]
    public string description = "";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public ItemUse useText;


    public virtual void Use() //item is used, something might happen.
    {
        Debug.Log("used item! (It doesn't do anything, so get on that.)");
    }

}

public enum ItemUse { Use, Drink, Equip, Inspect}
