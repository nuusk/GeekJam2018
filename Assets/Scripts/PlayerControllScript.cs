using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllScript : MonoBehaviour
{

    // Use this for initializatio

    public float speed;
    public float jumpForce;
    public float moveInput;

    private Rigidbody2D rb;

    private bool facingRigth = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius; 
    public LayerMask whatIsGround;

    public int maxJumps;
    private int extraJumps;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRigth == false && moveInput > 0)
        {
            Flip();
        } else if(facingRigth == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRigth = !facingRigth;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }

        if(isGrounded == true)
        {
            extraJumps = maxJumps;
        }
    }
}
