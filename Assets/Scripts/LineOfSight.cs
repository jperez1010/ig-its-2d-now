using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private bool PlayerVisible;
    private float RayDistance = 10;
    private Vector3 castPoint;
    private float timer;
    private float SpotTime = 30;
    [SerializeField]
    EnemyAI AI;
    void Start()
    {
        PlayerVisible = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerVisible = SeePlayer();
        if (PlayerVisible)
        {
            this.GetComponent<EnemyAI>().SetState(AIState.HUNTING);
            timer = SpotTime;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            this.GetComponent<EnemyAI>().SetState(AIState.SCOUTING);
        }
    }

    //Shoots out five raycasts at different angles.
    private bool SeePlayer()
    {
        castPoint = this.transform.position;
        Vector3 endPosBase = castPoint + AI.GetDirection() * RayDistance;
        RaycastHit hitBase;
        RaycastHit hitFarPos;
        RaycastHit hitClosePos;
        RaycastHit hitCloseNeg;
        RaycastHit hitFarNeg;
        bool middle = Physics.Raycast(new Ray(castPoint, AI.GetDirection()), out hitBase, RayDistance, (1 << LayerMask.NameToLayer("Obstacle")) | (1 << LayerMask.NameToLayer("Player")));
        bool farPos = Physics.Raycast(new Ray(castPoint, AI.GetDirection()), out hitFarPos, RayDistance, (1 << LayerMask.NameToLayer("Obstacle")) | (1 << LayerMask.NameToLayer("Player")));
        bool closePos = Physics.Raycast(new Ray(castPoint, AI.GetDirection()), out hitClosePos, RayDistance, (1 << LayerMask.NameToLayer("Obstacle")) | (1 << LayerMask.NameToLayer("Player")));
        bool closeNeg = Physics.Raycast(new Ray(castPoint, AI.GetDirection()), out hitCloseNeg, RayDistance, (1 << LayerMask.NameToLayer("Obstacle")) | (1 << LayerMask.NameToLayer("Player")));
        bool farNeg = Physics.Raycast(new Ray(castPoint, AI.GetDirection()), out hitFarNeg, RayDistance, (1 << LayerMask.NameToLayer("Obstacle")) | (1 << LayerMask.NameToLayer("Player")));
        Debug.DrawLine(castPoint, endPosBase, Color.blue);
        if (middle || farPos || closePos|| closeNeg || farNeg)
        {
            if (hitBase.collider.gameObject.CompareTag("Player") || hitFarPos.collider.gameObject.CompareTag("Player") || hitClosePos.collider.gameObject.CompareTag("Player") || hitFarNeg.collider.gameObject.CompareTag("Player")
                || hitCloseNeg.collider.gameObject.CompareTag("Player"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
}
