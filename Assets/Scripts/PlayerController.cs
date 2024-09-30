using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    private Vector2 movement;
    private float x0, y0;

    void Update()
    {
        x0 = Input.GetAxis("HORIZONTAL0");
		y0 = Input.GetAxis("VERTICAL0");

        movement.x = x0;
        movement.y = y0;
    }

    void FixedUpdate()
    {
       rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); 
    }
}
