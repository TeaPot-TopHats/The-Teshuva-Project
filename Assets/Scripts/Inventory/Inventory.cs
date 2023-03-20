using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


/**
 * A class that hold the player inventroy with a list of items
 */
public class Inventory : MonoBehaviour
{
    private Item item;
    public int inventorySize = 10;
    public int currentInventory;
    public Item[] items;
    List<Item> itemList = new List<Item>();
    private void Start()
    {
        
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {

            Debug.Log(currentInventory);
            
        }
        
    }
    public bool AddItem(Item itemToAdd)
    {
        if (currentInventory >= inventorySize)
        {
            Debug.LogWarning("Inventroy is full");
            return false;
        }
        else
        {
            itemList.Add(itemToAdd);
            currentInventory++;
            Debug.Log("****Item " + itemToAdd.itemName + " added to inventory****");
            Debug.Log("****Current Inventory size is: " + currentInventory + " ****");
            items = itemList.ToArray();
            return true;
        }
        // update UI here
    }// end of add item

    public bool RemoveItem(Item itemToRemove)
    {
            itemList.Remove(itemToRemove);
            currentInventory--;
            Debug.Log("Item" + itemToRemove + "reomved to inventory");
            Debug.Log("Current Inventory size is: " + currentInventory);
            items = itemList.ToArray();
        return true;
    }// end of remove item
}// end of class

