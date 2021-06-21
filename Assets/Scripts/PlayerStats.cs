using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEqipmentChanged;
    }

    void OnEqipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.Addmodifier(newItem.armorModifier);
            damage.Addmodifier(newItem.damageModifier);
        }
        if(oldItem != null) 
        {
            armor.Removemodifier(oldItem.armorModifier);
            damage.Removemodifier(oldItem.damageModifier);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
