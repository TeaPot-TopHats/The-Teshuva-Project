using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public int HP {get; set;}
	public float MOVESPEED {get; set;}
	public int ATK {get; set;}
	public int DEF {get; set;}
	public int REGEN {get; set;}
	
	private void Start()
	{
		HP = 10;
		MOVESPEED = 4.5f;
		ATK = 5;
		DEF = 5;
		REGEN = 1;
	}
	
	private void GetClassStats()
	{
		
	}
}

// * Git Commit
// * I added the basic scripts for the state machine
// * Added AttackTypes and AttackActions enums
// * Added WeaponAttack class
// * Added AttacksManager game object and GameAttacks script
