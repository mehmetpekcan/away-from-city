using UnityEngine;

public class ItemPickup : Interactable
{

    public Item item;
    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    void Pickup()
    {
        Debug.Log("Picked up the an item " + item.name);

        //adding items in inventory

        bool addedornot=Inventory.instance.Add(item);
        if(addedornot) Destroy(gameObject);

    }
}
