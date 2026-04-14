using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour, IPatrol
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float waitTime = 1f;

    private int currentIndex = 0;
    private float waitCounter;

    private void Start()
    {
        waitCounter = waitTime;
    }

    private void Update()
    {
        Patrol();
    }

    public void Patrol()
    {
        if (patrolPoints == null || patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[currentIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            if (waitCounter <= 0)
            {
                currentIndex = (currentIndex + 1) % patrolPoints.Length;
                waitCounter = waitTime;
            }
            else
            {
                waitCounter -= Time.deltaTime;
            }
        }
    }
}
