using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public Transform[] wayPoint;
    public Transform player;
    public float detectionRange = 10f;
    public float attackRange = 2f;
    public float faceSpeedPlayer = 100f;
    public float speedAgent = 2;
    public float stopDistance = 2;
    private NavMeshAgent agent;
    private Animator animator;
    private bool isAttacking = false;
    private int currentWaypointIndext = 0;
    private int IsRuningId;
    private int IsAttackId;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speedAgent;
        animator = GetComponent<Animator>();
        GoToNextWayPoint();
        IsRuningId = Animator.StringToHash("IsRuning");
        IsAttackId = Animator.StringToHash("attack");
    }
    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position,transform.position);
        if (distanceToPlayer <= attackRange)
        {
            //tan cong
            AttackPlayer(); 
        }
        else if (distanceToPlayer <= detectionRange)
        {
            //di den nguoi choi
            ChaserPlayer();
        }
        else
        {
            //tuan tra
            Patrol();
        }
    }
    private void Patrol()
    {
        if(!agent.pathPending&&agent.remainingDistance<0.3f)
        {
            GoToNextWayPoint();
        }
        animator.SetBool(IsRuningId,true);
        agent.stoppingDistance = 0;
    }
    private void ChaserPlayer()
    {
        if (!isAttacking)
        { 
            
            animator.SetBool(IsRuningId,true);
            Invoke("Run",0.5f);
        }
        FacePlayer();
    }
    void Run()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(player.position);
        FacePlayer();
        if (!isAttacking)
        {
            isAttacking = true;
            animator.SetBool(IsRuningId, false);
            animator.SetTrigger(IsAttackId);
            Invoke("ResetAttack", 1f);
        }
        agent.stoppingDistance = stopDistance;
    }
    void ResetAttack()
    {
        isAttacking= false;
    }
    void GoToNextWayPoint()
    {
        if (wayPoint.Length == 0) return;
        agent.destination = wayPoint[currentWaypointIndext].position;
        currentWaypointIndext = (currentWaypointIndext + 1) % wayPoint.Length;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
    }
    void FacePlayer()
    {
        Vector3 direction = player.position- transform.position;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*faceSpeedPlayer);
    }
}
