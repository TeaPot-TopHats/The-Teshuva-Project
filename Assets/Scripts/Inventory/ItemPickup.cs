using UnityEngine;
using UnityEngine.UI;



/**
 * A class that help the player to pick up items in the world by collideing with them.
 */
public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory inventory = collision.GetComponent<Inventory>();
            if (inventory != null)
            {
                bool itemAdded = inventory.AddItem(item);
               
                if(itemAdded)
                {
                    Destroy(gameObject);
                    Debug.Log("****Item pick up " + item.itemName + " and destroyed****");
                }
            }
           
           
        }
    }// end of On Trigger enter 2d
}// end of class

