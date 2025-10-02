using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private float horizontalInput;
    private bool isFacingRight = true;

    void Update()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (isFacingRight && horizontalInput < 0f)
            Flip();
        else if (!isFacingRight && horizontalInput > 0f)
            Flip();

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public bool IsFacingRight()
    {
        return isFacingRight;
    }
}
