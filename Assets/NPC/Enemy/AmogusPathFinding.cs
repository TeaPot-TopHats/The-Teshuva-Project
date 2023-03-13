using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AmogusPathFinding : MonoBehaviour
{
    public Transform target;

    public float speed;
    public float nextWaypointDistance;

    Path PathComponent;
    int currentWaypoint;
    bool reachedEndOfPath;

    [SerializeField] Seeker SeekerComponent;
    [SerializeField] Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdatePath", 0f, 1f);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PathComponent == null)
            return;
        if(currentWaypoint >= PathComponent.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }

        Vector2 direction = ((Vector2)PathComponent.vectorPath[currentWaypoint] - RB.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        RB.velocity = force;
        float distance = Vector2.Distance(RB.position, PathComponent.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
            currentWaypoint++;

        if (target.transform.localPosition.x < transform.localPosition.x && GetComponent<Transform>().localScale.x > 0)
            GetComponent<Transform>().localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        else if (target.transform.localPosition.x > transform.localPosition.x && GetComponent<Transform>().localScale.x < 0)
            GetComponent<Transform>().localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            PathComponent = p;
            currentWaypoint = 0;
        }
        else
            reachedEndOfPath = false;
    }

    void UpdatePath()
    {
        if (SeekerComponent.IsDone())
        {
            SeekerComponent.StartPath(RB.position, target.position, OnPathComplete);
        }
    }

    private void OnDisable()
    {
        RB.velocity = Vector2.zero;
    }
}
