using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmogusSensor
{

    [SerializeField] private LayerMask PlayerLayer;
    [SerializeField] private Transform AttackArea;
    [SerializeField] private float attackRadius;
    [SerializeField] private bool PlayerInRange;

    

    public AmogusSensor(Transform AttackArea, float attackRadius, LayerMask PlayerLayer)
    {
        this.PlayerLayer = PlayerLayer;
        this.AttackArea = AttackArea;
        this.attackRadius = attackRadius;

    }

    public bool CheckRange()
    {
        Debug.Log(AttackArea.position);
        PlayerInRange = Physics2D.OverlapCircle(AttackArea.position, attackRadius, PlayerLayer);
        Debug.Log(PlayerInRange);
        return PlayerInRange;
    }

}
