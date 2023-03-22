using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
	! This script:
	BFA stands for Big Fucking Algorithm
	This script performs attacks
*/



public class BFA : MonoBehaviour
{
	private WeaponAttack attack;
	private bool isStrong;
	// private PlayerCombat combat;
	
	private void Start() {
		// combat = GetComponent<PlayerCombat>();
	}
	
	public void PerformAttack(PlayerStat currentStats, WeaponAttack attack, bool isStrong)
	{
		CalculateStats(currentStats, attack);
		this.isStrong = isStrong;
		Attack();
	}
	
	// this is temporary
	private void CalculateStats(PlayerStat stats, WeaponAttack attack)
	{
		this.attack = new WeaponAttack(attack);
		this.attack.MeleeRange += stats.MeleeRange;
		this.attack.MeleeReach += stats.MeleeReach;
		
		this.attack.MultipleNumber += stats.MultipleNumber;
		this.attack.MultipleRange += stats.MultipleRange;
		this.attack.AreaOfEffect += stats.AreaOfEffect;
		
		this.attack.AddHoldDamage += stats.AddHoldDamage;
		
		this.attack.Knockback += stats.Knockback;
		this.attack.CritChance += stats.CritChance;
		this.attack.AddCritDamage += stats.AddCritDamage;
		this.attack.Recharge += stats.Recharge;
	}
	
	private void Attack()
	{
		 if (attack.Type == AttackType.MELEE)
		 {
		 	Melee();
		 }
		if (attack.Type == AttackType.RANGE_SINGLE)
		{
			RangeSingle();
		}
		if (attack.Type == AttackType.RANGE_MULTIPLE)
		{
			RangeMultiple();
		}
	}
	
	private void Melee()
	{
		 
	}
	
	private void RangeSingle()
	{

	}
	
	private void RangeMultiple()
	{
		
	}

}