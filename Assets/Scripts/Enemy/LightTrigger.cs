using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LightTrigger : MonoBehaviour
{
    private LightDetection lightDetection;

    private void Awake()
    {
        lightDetection = GetComponentInParent<LightDetection>();
        if (lightDetection == null)
            Debug.LogError("LightTrigger could not find LightDetection in parent!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lightDetection.SetPlayerInside(true, collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lightDetection.SetPlayerInside(false, null);
        }
    }
}
