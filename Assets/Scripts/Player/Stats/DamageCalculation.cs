using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculation : MonoBehaviour
{
    //private PrimaryAttackState PAS;
   
    [Header("Player Damage Modifers")]
    public int baseDamage = 10; // base damage value
    [Range(1f, 2f)]
    public float holdButtonDamageModifier = 1.25f; // damage modifier for holding the attack button


    [Header("Crit Chance")]
    [Range(0f,1f)]
    public float criticalChance = 0.2f; // critical chance
    [Range(0f, 1f)]
    public float criticalThreshold = 0.9f; // an threshold critical chance need to meet to preform.
    [Range(1f, 3f)]
    public float criticalDamageModifier = 1.5f; // Critical hit modifier
   
    
    /**
     * A method that calculate player damage by first checking if the hit is critical then check
     */
    public int CalculatePlayerDamage(bool isHoldingAttackButton, float holdButtonTime)
    {
        
        int damage = baseDamage;
        
        // calculate if a hit is critical hit
        if (IsCriticalHit(criticalChance, criticalThreshold))
        {
            damage = Mathf.RoundToInt(damage * criticalDamageModifier); // 
        }

        // apply damage modifier for holding the attack button
        if (isHoldingAttackButton)
        {
            float holdButtonModifier = Mathf.Clamp01(holdButtonTime); // make sure the hold button time is between 0 and 1
            damage = Mathf.RoundToInt(damage * (holdButtonDamageModifier + holdButtonModifier)); // final damage calculation
        }

        return damage;
    }// end of calculate player damage

    /**
     *  A method that calcualte if a hit would be a critical or not by randomness + some control using
     *  a threshold that can be modified by increasing player critical chance stat. 
     *  
     *  if the random value generated is less then or equal to our critial chance then generate another roll
     *  if the critical roll is bigger than threshold then prefrom a critical hit.
     */
    public bool IsCriticalHit(float criticalChance, float criticalThreshold)
    {
        float randomValue = Random.value; //random float number between 0 to 1 
        if (randomValue <= criticalChance)
        {
            float criticalRoll = Random.value;
            if (criticalRoll >= criticalThreshold)
            {
                return true;
            }
        }
        return false;
    }// end of Is critical hit

}// end of class
