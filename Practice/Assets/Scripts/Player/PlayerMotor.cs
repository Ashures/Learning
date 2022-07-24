using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public float jumpForce;

    private float moveDirection;
    private int jumps;

    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");
        transform.Translate(moveDirection * speed * Time.deltaTime, 0, 0);

        if(Input.GetKeyDown(KeyCode.W) && jumps < 2)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumps += 1;
        }
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            jumps = 0;
        }
    }
}
