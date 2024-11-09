using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    private Vector2 movement;
    private float x0, y0;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        x0 = Input.GetAxis("HORIZONTAL0");
        y0 = Input.GetAxis("VERTICAL0");

        
        movement = Vector2.zero;

        
        if (Mathf.Abs(x0) > Mathf.Abs(y0))
        {
            movement.x = x0;
            movement.y = 0;
        }
        else
        {
            movement.x = 0;
            movement.y = y0;
        }

        
        animator.SetFloat("x", movement.x);
        animator.SetFloat("y", movement.y);
        animator.SetBool("Moving", movement.magnitude > 0);

        
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
