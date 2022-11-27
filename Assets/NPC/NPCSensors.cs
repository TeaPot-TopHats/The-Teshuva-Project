using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSensors : MonoBehaviour
{
    [SerializeField] public GameObject Player;
    [SerializeField] private LayerMask PlayerLayer;
    //[SerializeField] private Transform Sensor;
    [SerializeField] private Transform AttackArea;
    //[SerializeField] private float sensorRadius;
    [SerializeField] private float attackRadius;
    //[SerializeField] public Vector3 TargetPosition { get; private set; }
    //[SerializeField] public bool seePlayer { get; private set; }
    [SerializeField] public bool canAttack { get; private set; }

    private void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        canAttack = Physics2D.OverlapCircle(AttackArea.position, attackRadius, PlayerLayer);
        Debug.Log(canAttack);
    }

    /*public void SetLayer(Transform transform, SpriteRenderer renderer)
    {

        if (transform.position.y > Player.GetComponent<Transform>().position.y)
            renderer.sortingOrder = 0;
        else if (transform.position.y < Player.GetComponent<Transform>().position.y)
            renderer.sortingOrder = 3;


    }*/

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackArea.position, attackRadius);

    }
}
