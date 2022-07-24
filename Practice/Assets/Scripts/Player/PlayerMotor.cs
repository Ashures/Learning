using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public float jumpHeight;

    private float moveDirection;

    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");
        transform.Translate(moveDirection * speed * Time.deltaTime, 0, 0);
    }
}
