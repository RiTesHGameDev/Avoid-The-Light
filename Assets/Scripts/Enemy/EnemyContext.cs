using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContext : MonoBehaviour
{
    public IPatrol Patrol { get; private set; }
    public IDetection Detection { get; private set; }
    public IChase Chase { get; private set; }

    [Header("Assign Implementations")]
    [SerializeField] private EnemyPatrol patrol;
    [SerializeField] private LightDetection detection;
    [SerializeField] private EnemyChase chase;

    private void Awake()
    {
        Patrol = patrol;
        Detection = detection;
        Chase = chase;
    }
}
