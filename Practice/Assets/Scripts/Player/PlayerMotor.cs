using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public float jumpForce = 7;

    private float moveDirection;
    private bool isMoving;
    private int jumps;

    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");
        isMoving = (moveDirection != 0);
        if (isMoving)
        {
            //transform.Translate(moveDirection * speed * Time.deltaTime, 0, 0);
            rb.MovePosition(new Vector2((transform.position.x + moveDirection * speed * Time.deltaTime), transform.position.y));
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && jumps < 2)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumps += 1;
        }
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            jumps = 0;
        }
    }
}