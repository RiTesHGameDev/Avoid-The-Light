using UnityEngine;
using System;
using UnityEngine.Rendering.Universal;

public class LightDetection : MonoBehaviour,IDetection
{
    [Header("Rotation Settings")]
    [SerializeField] private Transform lightTransform;
    [SerializeField] private float rotationSpeed = 30f;
    [SerializeField] private float leftAngle = 135f;
    [SerializeField] private float rightAngle = 225f;

    [Header("Detection Settings")]
    [SerializeField] private float detectionDistance = 5f;
    [SerializeField] private LayerMask obstacleMask;
    [SerializeField] private LayerMask playerMask;

    [Header("Visual Feedback")]
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color alertColor = Color.red;

    [SerializeField] private Light2D spotlight;

    private bool rotatingRight = true;
    private Transform player;
    private bool detecting = true;
    private bool playerInsideCone = false;

    public event Action OnPlayerDetected;
    public void StartDetection()
    {
        detecting = true;
    }

    public void StopDetection()
    {
        detecting = false;
        playerInsideCone = false;
        player = null;
    }
    private void Update()
    {
        if (!detecting || lightTransform == null) return;

        RotateLight();

        if (playerInsideCone && player != null && HasLineOfSight())
        {
            SetLightColor(alertColor);
            OnPlayerDetected?.Invoke();
        }
        else
        {
            SetLightColor(normalColor);
        }
    }

    private void RotateLight()
    {
        float currentAngle = lightTransform.localEulerAngles.z;

        if (rotatingRight)
        {
            lightTransform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            if (currentAngle >= rightAngle)
                rotatingRight = false;
        }
        else
        {
            lightTransform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
            if (currentAngle <= leftAngle)
                rotatingRight = true;
        }
    }

    private bool HasLineOfSight()
    {
        if (player == null) return false;

        Vector2 direction = (player.position - lightTransform.position).normalized;
        float distance = Vector2.Distance(lightTransform.position, player.position);

        if (distance > detectionDistance) return false;

        RaycastHit2D hit = Physics2D.Raycast(lightTransform.position, direction, detectionDistance, obstacleMask | playerMask);
        Debug.DrawRay(lightTransform.position, direction * detectionDistance, Color.yellow);

        return hit.collider != null && hit.collider.CompareTag("Player");
    }

    private void SetLightColor(Color color)
    {
        if (spotlight != null) spotlight.color = color;
    }

    // Called by LightTrigger
    public void SetPlayerInside(bool inside, Transform playerTransform)
    {
        playerInsideCone = inside;
        player = inside ? playerTransform : null;
    }
}