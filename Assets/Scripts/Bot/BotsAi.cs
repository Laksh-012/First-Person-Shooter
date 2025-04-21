using UnityEngine;
using UnityEngine.AI;

public class SimpleBotAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float detectionRange = 30f;
    public float attackRange = 10f;
    public float patrolWaitTime = 2f;

    private int currentPoint = 0;
    private float waitTimer = 0f;
    public Transform player;
    private NavMeshAgent agent;
    private bool chasingPlayer = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentPoint].position);
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            agent.SetDestination(player.position);
            chasingPlayer = true;

            if (distanceToPlayer <= attackRange)
            {
                Debug.Log("Bot is attacking the player!");
            }
        }
        else if (chasingPlayer)
        {
            chasingPlayer = false;
            GoToNextPatrolPoint();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= patrolWaitTime)
            {
                GoToNextPatrolPoint();
                waitTimer = 0f;
            }
        }
    }

    void GoToNextPatrolPoint()
    {
        currentPoint = (currentPoint + 1) % patrolPoints.Length;
        agent.SetDestination(patrolPoints[currentPoint].position);
    }
}
