using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class SecurityGuardStateMachine : MonoBehaviour
{
    enum guardState
    {
        idle,
        patrolling,
        spotted
    }

    [SerializeField] guardState state = guardState.patrolling;

    [Header("Patrolling")]
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] bool flipFlopPatrol;

    //private
    NavMeshAgent agent;
    Animator animator;
    private int destPoint = 0;
    bool patrolFlip;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Vertical", Mathf.Clamp(agent.velocity.magnitude, 0, 1));
        switch (state)
        {
            case guardState.patrolling:
                Patrolling();
                break;
            case guardState.idle:
                break;
            case guardState.spotted:
                break;
        }
    }

    void Patrolling()
    {
        if (!agent.pathPending && agent.remainingDistance <= 0.5f)   //If distance to next point is short
        {
            if (patrolPoints.Length == 0)   //If no patrol points quit current method
            {
                return;
            }

            agent.destination = patrolPoints[destPoint].position;   //Set patrol destination

            if (flipFlopPatrol)
            {
                destPoint = patrolFlip ? destPoint - 1 : destPoint + 1;
                if (destPoint == patrolPoints.Length - 1 || destPoint == 0)
                {
                    patrolFlip = !patrolFlip;
                }
            }
            else
            {
                destPoint = (destPoint + 1) % patrolPoints.Length;
            }

        }
    }
}
