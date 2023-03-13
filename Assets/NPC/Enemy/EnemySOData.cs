using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySOData", menuName = "Scriptable Objects/Enemy Data")]
public class EnemySOData : ScriptableObject
{
    [Header("Enums")]
    public EnemyStates InitialState;

    [Header("Stats")]
    public int maxHealthPoints;
    public int defaultSpeed;
    public int defaultAttack;

}
