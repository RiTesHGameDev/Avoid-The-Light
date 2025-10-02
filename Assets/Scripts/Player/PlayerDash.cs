using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDash : MonoBehaviour
{
    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerMovement movementScript;

    private bool canDash = true;
    private bool isDashing = false;

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash && !isDashing)
        {
            StartCoroutine(PerformDash());
        }
    }

    private IEnumerator PerformDash()
    {
        canDash = false;
        isDashing = true;

        // Save original velocity
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2((movementScript.IsFacingRight() ? 1 : -1) * dashSpeed, 0f);

        yield return new WaitForSeconds(dashDuration);

        rb.gravityScale = originalGravity;
        isDashing = false;

        // Wait for cooldown
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
