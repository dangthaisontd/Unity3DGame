using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public Transform[] wayPoint;
    public Transform player;
    public float detectionRadius= 9f;
    public float fiedOfViewAngle = 120f;
    public float attackRange = 2;
    private int currentWaypointIndext = 0;
    private NavMeshAgent agent;
    private bool playerInSight;
    private bool playerInRange;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextWayPoint();
    }

    // Update is called once per frame
    void Update()
    {
        DetectedPlayer();
        if (playerInSight)
        {
            ChaserPlayer();
        }
        else if (playerInRange)
        {
            Attack();
        }
        else
        {
            Paltrol();
        }    
    }
    private void Attack()
    {
        Debug.Log("attack");
    }

    private void ChaserPlayer()
    {
        agent.destination = player.position;
    }

    void Paltrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.3f)
        {
            GoToNextWayPoint();
        }
    }
    void GoToNextWayPoint()
    {
        if (wayPoint.Length == 0) return;
        agent.destination = wayPoint[currentWaypointIndext].position;
        currentWaypointIndext = (currentWaypointIndext+1)%wayPoint.Length;
    }
    void DetectedPlayer()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        if((angle <fiedOfViewAngle*0.5f)&&(direction.magnitude < detectionRadius))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, direction.normalized, out hit,detectionRadius))
            {
                if(hit.collider.transform == player)
                {
                    playerInSight = true;
                }
                else
                {
                    playerInSight = false;
                }
            }
        }
        if(Vector3.Distance(transform.position,player.position) < attackRange)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange=false;
        }
    }
}
