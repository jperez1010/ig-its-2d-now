using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    private Transform Player;
    int waypointIndex;
    Vector3 target;
    private float timer = 0;
    private float elapsedTime = 0;
    private Vector3 Dir;
    private Vector3 Previous;
    private AIState State;
    [SerializeField]
    float Range = 3;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        Previous = this.transform.position;
        Dir = (target - Previous).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (State == AIState.SCOUTING && Vector3.Distance(transform.position, target) < 2.5)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
        else if (State == AIState.HUNTING)
        {
            Player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
            agent.SetDestination(Player.position);
            if (Vector3.Distance(this.transform.position, Player.position) <= Range && timer == 0)
            {
                EventManager.current.EnemyLightAttackCommand();
                timer = Time.time;
            }
            if (timer != 0)
            {
                elapsedTime = Time.time - timer;
            }
            if (elapsedTime >= 1)
            {
                timer = 0;
                elapsedTime = 0;
            }

        }
        if (this.transform.position != Previous)
        {
            Dir = (this.transform.position - Previous).normalized;
            Previous = this.transform.position;
        }
    }
    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }
    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
    public Vector3 GetDirection()
    {
        return Dir;
    }

    public void SetState(AIState State)
    {
        this.State = State;
    }
}
