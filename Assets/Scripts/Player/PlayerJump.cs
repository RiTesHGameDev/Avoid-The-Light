using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] private float jumpForce;
    [SerializeField] private int maxJumps;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    private int jumpsRemaining;

    private void Start()
    {
        jumpsRemaining = maxJumps;
    }
    private void Update()
    {
        // Reset jumps when player touches the ground
        if (IsGrounded() && jumpsRemaining != maxJumps)
        {
            jumpsRemaining = maxJumps;
        }
        animator.SetBool("IsJumping", !IsGrounded());
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && jumpsRemaining > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpsRemaining--;
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
}
