using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;
    InventorySlot[] slots;
    public GameObject Invetory_UI;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.ItemisChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            Invetory_UI.SetActive(!Invetory_UI.activeSelf);
        }
    }
    void UpdateUI() {

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
