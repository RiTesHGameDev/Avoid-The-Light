using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private IPatrol patrol;
    private IDetection detection;
    private IChase chase;

    [SerializeField] private Transform player;
    [SerializeField] private float chaseTime = 3f;

    private float chaseTimer;
    private bool isChasing;

    public void Initialize(IPatrol patrol, IDetection detection, IChase chase)
    {
        this.patrol = patrol;
        this.detection = detection;
        this.chase = chase;

        detection.OnPlayerDetected += HandlePlayerDetected;
    }

    private void Start()
    {
        var context = GetComponent<EnemyContext>();
        Initialize(context.Patrol, context.Detection, context.Chase);
    }

    private void Update()
    {
        if (isChasing)
        {
            chase.ChasePlayer(player);
            chaseTimer -= Time.deltaTime;
            if (chaseTimer <= 0)
            {
                isChasing = false;
                detection.StartDetection(); // resume scanning
            }
        }
        else
        {
            patrol.Patrol();
        }
    }

    private void HandlePlayerDetected()
    {
        isChasing = true;
        chaseTimer = chaseTime;
        detection.StopDetection(); // pause scanning while chasing
    }

    private void OnDestroy()
    {
        if (detection != null)
            detection.OnPlayerDetected -= HandlePlayerDetected;
    }
}
