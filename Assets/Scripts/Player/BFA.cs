using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// BFA stands for Big Fucking Algorithm


public class BFA : MonoBehaviour
{
	private WeaponAttack attack;
	private bool wasHeld;
	
	public void PerformAttack(PlayerStat currentStats, WeaponAttack attack, bool wasHeld)
	{
		CalculateStats(currentStats, attack);
		this.wasHeld = wasHeld;
		ActuallyDoAttack(wasHeld);
	}
	
	private void CalculateStats(PlayerStat stats, WeaponAttack attack)
	{
		this.attack = new WeaponAttack(attack);
		this.attack.MeleeRange += stats.MeleeRange;
		this.attack.MeleeReach += stats.MeleeReach;
		
		this.attack.MultipleNumber += stats.MultipleNumber;
		this.attack.MultipleRange += stats.MultipleRange;
		this.attack.AreaOfEffect += stats.AreaOfEffect;
		
		this.attack.AddHoldDamage += stats.AddHoldDamage;
		
		this.attack.CritChance += stats.CritChance;
		this.attack.AddCritDamage += stats.AddCritDamage;
		this.attack.Recharge += stats.Recharge;
	} 
	
	private void ActuallyDoAttack(bool wasHeld)
	{
		 if (attack.Type == AttackType.MELEE)
		 {
		 	Melee(wasHeld);
		 }
		if (attack.Type == AttackType.RANGE_SINGLE)
		{
			RangeSingle(wasHeld);
		}
		if (attack.Type == AttackType.RANGE_MULTIPLE)
		{
			RangeMultiple(wasHeld);
		}
	}
	
	private void Melee(bool wasHeld)
	{
		 
	}
	
	private void RangeSingle(bool wasHeld)
	{
		
	}
	
	private void RangeMultiple(bool wasHeld)
	{
		
	}
	
}