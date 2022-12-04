using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] NPCSensors Sensors;
    public NPCStates CS { get; private set; }
    event Action CA;
    [SerializeField] int health;
    [SerializeField] float speed;
    [SerializeField] float defaultSpeed;
    [SerializeField] float timer;
    [SerializeField] float attackTime;
    [SerializeField] float idleTime;
    [SerializeField] float chaseTime;
    [SerializeField] float hurtTime;
    [SerializeField] float deathTime;
    [SerializeField] float initialCoolDown;
    [SerializeField] float coolDown;
    [SerializeField] bool hasAttacked;
    [SerializeField] Rigidbody2D RB;
    [SerializeField] Vector2 CP;
    
    
    //at some point, look into animation to time actions appropriately


    void Start()
    {
        CS = NPCStates.IDLE;
        CA = Idling;
    }

    void Update()
    {
        CanAttack();
        CA();
        

    }

    private void FixedUpdate()
    {
        NPCActions.Move(RB, CP, speed);
    }

    public void Idling()
    {
        Count();
        if (timer>idleTime)
        {
            SetState(NPCStates.MOVING, Chasing, 0, defaultSpeed);
        }
    }

    public void Chasing()
    {


    }

    public void Attacking()
    {
        if (coolDown > 0)
        {
            SetState(NPCStates.IDLE, Idling, 0, 0);
        }
        
    }

    public void Hurting()
    {
        Count();
        if(timer >= hurtTime)
        {
            if(health > 0)
                SetState(NPCStates.IDLE, Idling, 0, 0);
            else
                SetState(NPCStates.DEAD, Dying, 0, 0);
        }
    }
    public void Dying()
    {
        Count();
        if (timer >= deathTime)
            Destroy(this);

    }

    public void AttackThrown()
    {
        if (Sensors.withinRange)
        {
            //NPCSensors.Player.GetComponent<PlayerController>().Attacked();
        }
    }

    public void AttackEnded()
    {
        coolDown = initialCoolDown;
    }

    //if cool down is up and in range then set to attack
    public void CanAttack()
    {
        if (coolDown <= 0 && Sensors.withinRange)
        {
            
            SetState(NPCStates.ATTACKING, Attacking, 0, 0);
        }
        
    }

    public void SetState( NPCStates state, Action action, float timer, float speed)
    {
        CS = state;
        CA = action;
        this.timer = timer;
        this.speed = speed;
    }

    public void Count()
    {
        timer += Time.deltaTime;
    }

    public void Damaged()
    {
        health--;
        SetState(NPCStates.HURT, Hurting, 0, 0);
    }
}
