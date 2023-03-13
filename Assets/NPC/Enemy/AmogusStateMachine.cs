using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmogusStateMachine : StateMachine
{
    public AmogusIdleState IdleState { get; private set; }
    public AmogusMoveState MoveState { get; private set; }
    public AmogusAttackState AttackState { get; private set; }
    public AmogusDamagedState DamagedState { get; private set; }
    public AmogusDeadState DeadState { get; private set; }

    //physics stuff
    [SerializeField] public GameObject Player = null;
    [SerializeField] public Rigidbody2D RB = null;

    //path finding stuff
    [SerializeField] public AmogusPathFinding PathFinder = null;

    //Events

    //sensor stuff
    [SerializeField] public Transform AttackTransformer;
    [SerializeField] public float attackTransformerRadius;
    [SerializeField] public LayerMask PlayerLayer;

    //animation stuff
    [SerializeField] public Animator AnimationComponent = null;
    public AmogusAnimator AmogusAnimationHandler { get; private set; }

    //stats
    //consider creating timer class to handle cooldowns
    public int hp;
    public int atk;
    public float atkCoolDown;
    public float defaultAtkCoolDown;
    public float invincibility;
    public float defaultInvincibility;

    private void Awake()
    {
        Debug.Log("Awoken");
        Player = GameObject.Find("Player");//may need to move code to Start instead
        Debug.Log(Player);
        Debug.Log("start setting target");
        PathFinder.target = Player.transform;
        Debug.Log(PathFinder.target);

        AmogusAnimationHandler = new AmogusAnimator(this);
        //instantiate states
        IdleState = new AmogusIdleState(this);
        MoveState = new AmogusMoveState(this);
        AttackState = new AmogusAttackState(this);
        //DamagedState = new AmogusDamagedState(this);
        DeadState = new AmogusDeadState(this);
    }

    private void Start()
    {
        Debug.Log("Start");
        ChangeState(IdleState);
    }



    //event method here for if player dies
    public void OnPlayerDeath()
    {
        Player = null;
        ChangeState(IdleState);
    }
    public void OnInjured(int atk)
    {//if attacked, 
        invincibility = defaultInvincibility;
        RB.velocity = Vector2.zero;
        //below line needs knockback amount from player weapon or just a default knockback
        //maybe consider weight of npc against weapon
        RB.AddForce((Player.GetComponent<Rigidbody2D>().position - RB.position).normalized);

        if (hp <= 0)
            ChangeState(DeadState);
    }

    public void LaunchAttackCall()
    {
        AttackState.LaunchAttack();
    }

    public void AttackEndCall()
    {
        AttackState.AttackEnded();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackTransformer.position, attackTransformerRadius);
    }

}
