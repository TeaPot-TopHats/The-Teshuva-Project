using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    
    NPCStates CS;
    event Action CA;
    [SerializeField] float speed;
    [SerializeField] float defaultSpeed;
    [SerializeField] float timer;
    [SerializeField] float attackTime;
    [SerializeField] float idleTime;
    [SerializeField] float chaseTime;
    [SerializeField] float deathTime;
    [SerializeField] bool hasAttacked;
    [SerializeField] Rigidbody2D RB;
    [SerializeField] Vector2 CP;
    
    
    //at some point, look into animation to time actions appropriately


    void Start()
    {
        CS = NPCStates.IDLE;
        CA = Idle;
    }

    void Update()
    {
        CA();
        

    }

    private void FixedUpdate()
    {
        NPCActions.Move(RB, CP, speed);
    }

    public void Idle()
    {
        speed = 0;
    }

    public void Chase()
    {
        speed = defaultSpeed;
    }

    public void Attack()
    {
        speed = 0;
        if (timer >= attackTime)
        {

        }
        //NPCSensors.Player.GetComponent<PlayerController>().Attacked();
    }
}
