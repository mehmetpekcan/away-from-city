using UnityEngine;

[CreateAssetMenu(fileName = "ITEM NAME", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "ITEM NAME";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}
