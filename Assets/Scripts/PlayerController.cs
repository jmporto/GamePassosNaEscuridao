using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum ECardinalDirection { Left, Right, Up, Down}
    private ECardinalDirection cardinalDirection = ECardinalDirection.Down;
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    private Vector2 movement;
    private float x0, y0;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private DuckCollector duckCollector;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        duckCollector = FindObjectOfType<DuckCollector>();
    }

    void Update()
    {
        if (duckCollector != null && duckCollector.canMove)
        {
            x0 = Input.GetAxis("HORIZONTAL0");
            y0 = Input.GetAxis("VERTICAL0");

            Vector2 mov = new Vector2(x0, y0);
            movement = Vector2.zero;


            if (Mathf.Abs(x0) > Mathf.Abs(y0) && mov.sqrMagnitude != 0)
            {
                movement.x = x0;
                movement.y = 0;

                if (x0 > 0)
                    cardinalDirection = ECardinalDirection.Left;
                else
                    cardinalDirection = ECardinalDirection.Right;
            }
            else if (mov.sqrMagnitude != 0)
            {
                movement.x = 0;
                movement.y = y0;

                if (y0 > 0)
                    cardinalDirection = ECardinalDirection.Up;
                else
                    cardinalDirection = ECardinalDirection.Down;
            }

            animator.SetFloat("CardinalDir", (int)cardinalDirection);
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
        else
        {
            movement = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        if (duckCollector != null && duckCollector.canMove)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}