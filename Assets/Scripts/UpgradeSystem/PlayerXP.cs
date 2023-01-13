using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int currentXP = 0;
    public int requiredXP = 100;
    public int playerLevel = 1;
 
    // Update is called once per frame
    void Update()
    {
        if(currentXP >= requiredXP)
        {
            // level up
            LevelUp();
        }
    }
    public void AddXP(int amount)
    {
        currentXP += amount;
    }
    private void LevelUp()
    {
        playerLevel++;
        currentXP -= requiredXP;
        requiredXP = (int)(requiredXP * 1.5f);
    }
}// end of class
