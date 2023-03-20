using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UseItem : MonoBehaviour
{
    public Inventory inventory;
    public Image selectedItemIcon;
    public Text selectedItemName;

    private Item selectedItem;

    public void SelectItem(int slot)
    {
        selectedItem = inventory.items[slot];
        selectedItemIcon.sprite = selectedItem.itemIcon;
        selectedItemName.text = selectedItem.itemName;
    }

    public void UseSelectedItem()
    {
        if (selectedItem.itemType == ItemType.Potion)
        {
            // Use the potion
            Debug.Log("Potion Used");
        }
        else if (selectedItem.itemType == ItemType.Weapon)
        {
            // Equip the weapon
            Debug.Log("Weapon Used");
        }
        else if (selectedItem.itemType == ItemType.Armor)
        {
            // Equip the armor
            Debug.Log("Armor Used");
        }
    }
}
