using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllScript : MonoBehaviour
{

    public GameObject soupParticleConsumedPrefab;

    public Animator animator;

    // Use this for initialization
    public float speed;
    public float jumpForce;
    public float moveInput;

    public Text countText;


    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius; 
    public LayerMask whatIsGround;

    public int maxJumps;
    private int extraJumps;

    private int soupCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soupCount = 0;
        SetCountText();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");

        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("SpeedX", Mathf.Abs(moveInput));
        animator.SetFloat("SpeedY", rb.velocity.y);

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            Flip();
        } else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
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

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            soupCount += 1;
            GameObject soupObject = Instantiate(soupParticleConsumedPrefab, other.transform.position, Quaternion.identity);
            soupObject.GetComponent<ParticleSystem>().Play();
            Destroy(soupObject, 1f);
            SetCountText();
        }    
    }

    void SetCountText() {
        countText.text = "SOUPS: " + soupCount.ToString();
    }
}
