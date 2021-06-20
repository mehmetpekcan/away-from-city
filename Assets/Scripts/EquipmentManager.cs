using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    Equipment[] currentEquipment;
    Inventory inv;
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    private void Start()
    {
        inv = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem) {

        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null) 
        {
            oldItem = currentEquipment[slotIndex];
            inv.Add(oldItem);
        }
        if (onEquipmentChanged != null) {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex) {

        if(currentEquipment[slotIndex] != null)
        { 
            Equipment oldItem = currentEquipment[slotIndex];
            if (inv.Add(oldItem))
            {
                currentEquipment[slotIndex] = null;
            }

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll() {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) UnequipAll();
    }

}