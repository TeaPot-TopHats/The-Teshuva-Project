using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDrops : MonoBehaviour
{
    // Enum to define the different types of items that can be dropped
    public enum ItemType
    {
        HealthPotion,
        MagicPotion,
        EXP
    }
    
    // Dictionary to store the prefabs and probabilities for each item type
     
    public Dictionary<ItemType, (GameObject prefab, float probability)> itemDropTable =
        new Dictionary<ItemType, (GameObject prefab, float probability)>
        {
            { ItemType.HealthPotion, (null, 0.3f) },
            { ItemType.MagicPotion, (null, 0.3f) },
            { ItemType.EXP, (null, 1f) }
        };

    private void OnDestroy()
    {
        // Choose a random item type from the enum
        ItemType itemType = (ItemType)Random.Range(0, 3);

        // Get the prefab and probability for the chosen item type from the dictionary
        (GameObject prefab, float probability) = itemDropTable[itemType];

        // Generate a random number between 0 and 1
        float randomValue = Random.Range(0f, 1f);

        // If the random value is less than the probability,
        // instantiate an instance of the prefab
        if (randomValue < probability)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }// end of OnDestory
}