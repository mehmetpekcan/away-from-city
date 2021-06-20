using UnityEngine;

[CreateAssetMenu(fileName = "ITEM NAME", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "ITEM NAME";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
