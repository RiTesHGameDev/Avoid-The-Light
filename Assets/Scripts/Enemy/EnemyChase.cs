using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour, IChase
{
    [SerializeField] private float chaseSpeed = 2f;

    public void ChasePlayer(Transform player)
    {
        if (player == null) return;
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }
}
