using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory instance;
    void Awake()
    {
        instance = this;
    }
    public List<Item> items = new List<Item>();
    public int space = 10;


    //creating call back method for listenening any changes for updateing gui;
    public delegate void ItemisChanged(); //<===
    public ItemisChanged ItemisChangedCallback;


    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space) 
            {
                Debug.Log("You don't have a empty space.");
                return false;
            }
            
            items.Add(item);
            if(ItemisChangedCallback != null)ItemisChangedCallback.Invoke();  //trigered callback function for updating inventory gui.
        }
        return true;
    }

    public void remove(Item item)
    {
        items.Remove(item);
        if (ItemisChangedCallback != null) ItemisChangedCallback.Invoke();
    }

}
