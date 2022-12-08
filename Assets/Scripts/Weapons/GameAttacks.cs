using UnityEngine;

public class GameAttacks : MonoBehaviour
{
	public WeaponAttack[] Attacks;
	
	
	// ! Use this method for Debugging only
	public int GetIndexOf(string name)
	{
		for (int index = 1; index < Attacks.Length; index++)
		{
			if(Attacks[index].Name == name)
			{
				return index;
			}
		}
		Debug.Log("WeaponAttack by name " + name + " does not exist!!!");
		return 0;
	}

}
