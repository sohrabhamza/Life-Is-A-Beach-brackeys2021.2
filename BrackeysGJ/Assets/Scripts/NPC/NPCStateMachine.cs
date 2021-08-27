using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class NPCStateMachine : MonoBehaviour
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

    enum npcType
    {
        NPC,
        Guard
    }
    [Header("Detection")]
    [SerializeField] npcType type;
    [SerializeField] float angle = 30;
    [SerializeField] float viewRadius;
    [SerializeField] LayerMask playerMask;
    [SerializeField] LayerMask obstacleMask;
    [SerializeField] Transform eyeLocation;
    [SerializeField] GameObject detectionThing;

    //private
    NavMeshAgent agent;
    Animator animator;
    private int destPoint = 0;
    bool patrolFlip;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        agent.avoidancePriority = Random.Range(50, 99);
        agent.speed = Random.Range(1, 3);
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

        FOV();
    }

    GameObject detection;
    void FOV()
    {
        Collider[] thingsNear = Physics.OverlapSphere(transform.position, viewRadius, playerMask);

        if (thingsNear.Length >= 1)
        {
            Vector3 dirToTarget = (thingsNear[0].transform.position - eyeLocation.transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) <= angle)
            {
                if (!Physics.Raycast(eyeLocation.transform.position, dirToTarget, out RaycastHit hit, 100, obstacleMask))
                {
                    if ((FindObjectOfType<InventorySystemOneObject>().alertGuard && type == npcType.Guard) || (FindObjectOfType<InventorySystemOneObject>().alertNPC && type == npcType.NPC))
                    {
                        if (!isLosing)
                        { StartCoroutine(lifeLoosing(thingsNear[0].gameObject)); }
                        isLosing = true;
                        if (detection != null)
                        {
                            detection.transform.LookAt(gameObject.transform);
                            detection.transform.position = thingsNear[0].transform.position + new Vector3(0, 4, 0);
                        }
                    }
                    else
                    {
                        isLosing = false;
                        if (detection != null)
                        {
                            Destroy(detection);
                        }
                    }
                }
                else
                {
                    isLosing = false;
                    if (detection != null)
                    {
                        Destroy(detection);
                    }
                }
            }
            else
            {
                isLosing = false;
                if (detection != null)
                {
                    Destroy(detection);
                }
            }
        }
        else
        {
            isLosing = false;
            if (detection != null)
            {
                Destroy(detection);
            }
        }
    }

    bool isLosing;
    IEnumerator lifeLoosing(GameObject player)
    {
        detection = Instantiate(detectionThing, player.transform);
        detection.transform.SetParent(player.transform);
        Debug.Log("Spawned " + detection);
        yield return new WaitForSeconds(1.5f);
        if (isLosing)
        {
            FindObjectOfType<FailState>().loseALife();
        }
        isLosing = false;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}
