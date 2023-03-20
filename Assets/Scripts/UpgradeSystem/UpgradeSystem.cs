using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * A class to choose random upgrade from out created upgrades and present them to the player in choice of 3 upgrades and apply those upgrades. 
 */
public class UpgradeSystem : MonoBehaviour
{
    private PlayerStat stat;
    public GameObject upgradeButtonPrefap;
    public GameObject upgradePanel;
    public Upgrades[] upgrades; // our created upgrades
    public int currentLevel = 0; // our level
    public int maxLevel = 9999; // max level
    private List<Upgrades> upgradeChoices; // list that hold the random generated upgrade choices for the player

    // Start is called before the first frame update
    void Start()
    {
        upgradeChoices= new List<Upgrades>(); // create a new list for random upgrades
    }

    public void LevelUp()
    {
        if(currentLevel >= maxLevel) // if max level do nothing
        {
            return;
        }

        currentLevel++; // level up
        upgradeChoices.Clear(); // Empties the list . The length of the list will be zero.

        for(int i= 0; i < 3; i++) // a loop to determine the random upgrades
        {
            Upgrades randomUpgrade = upgrades[Random.Range(0, upgrades.Length)];
            if(!upgradeChoices.Contains(randomUpgrade)) 
            {
                upgradeChoices.Add(randomUpgrade); // add upgrade if there is spot
            }
        }
        // Present the upgrade choices to the player 
        for (int i = 0; i < upgradeChoices.Count; i++)   
        {
            // creating button UI for upgrades
            GameObject button = Instantiate(upgradeButtonPrefap, upgradePanel.transform);
            button.GetComponent<Image>().sprite = upgradeChoices[i].Icon;
            int index = i;
            button.GetComponent<Button>().onClick.AddListener(() => ApplyUpgrade(upgradeChoices[index]));
        }

    }// end of level up 

    public void ApplyUpgrade(Upgrades upgrade)
    {
        // Apply the upgrade to the player's character
        Debug.Log("Player Stats before upgrades" + stat.Health + stat.Strength + stat.MoveSpeed);
        GameObject player = GameObject.Find("Player"); // find player object
        /*
         * apply Upgrades
         */
        player.GetComponent<PlayerStat>().Health += upgrade.healthIncrease;
        player.GetComponent<PlayerStat>().Strength += upgrade.damageIncrease;
        player.GetComponent<PlayerStat>().MoveSpeed += upgrade.speedIncrease;

        Debug.Log("Player Stats AFTER upgrades" + stat.Health + stat.Strength + stat.MoveSpeed);
    }
}
