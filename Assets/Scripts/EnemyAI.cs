using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
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
    private AISubstate subState;
    [SerializeField]
    float Range = 3;
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        agent.SetDestination(Player.position);
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        Previous = this.transform.position;
        Dir = (target - Previous).normalized;
        subState = AISubstate.WALKING;
    }

    // Update is called once per frame
    void Update()
    {
        if (State == AIState.SCOUTING && Vector3.Distance(transform.position, target) < 2.5)
        {
            System.Random rand = new System.Random();
            int chance = rand.Next(0, 100);
            Debug.Log(chance);
            IterateWaypointIndex();
            UpdateDestination();
            if (chance > 80)
            {
                subState = AISubstate.IDLE;
                timer = Time.time;
            }
        }
        else if (State == AIState.HUNTING)
        {
            if (target != Player.position)
            {
                UpdateDestination();
            }
            if (Vector3.Distance(this.transform.position, Player.position) <= Range && timer == 0)
            {
                subState = AISubstate.ATTACKING;
                EventManager.current.EnemyLightAttackCommand();
                timer = Time.time;
            }
            if (timer != 0)
            {
                elapsedTime = Time.time - timer;
            }
            if (elapsedTime >= 0.5f)
            {
                timer = 0;
                elapsedTime = 0;
            }

        }
        if (subState == AISubstate.IDLE)
        {
            elapsedTime = Time.time - timer;
            if (elapsedTime < 3)
            {
                agent.speed = 0;
            } else
            {
                agent.speed = 1;
                subState = AISubstate.WALKING;
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
        if (State == AIState.SCOUTING)
        {
            target = waypoints[waypointIndex].position;
            agent.SetDestination(target);
        }
        else
        {
            Player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
            agent.SetDestination(Player.position);
        }
    }
    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
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
