using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllScript : MonoBehaviour
{
    public GameObject soupParticleConsumedPrefab;

    public AudioClip jumpSound;
    public AudioClip ghastSound;

    public int soupsToEnterForge = 3;

    public AudioClip eatSoup1;
    public AudioClip eatSoup2;
    public AudioClip eatSoup3;

    public AudioClip land1;
    public AudioClip land2;

    public AudioClip forge;


    public Animator animator;

    // Use this for initialization
    public float speed;
    public float jumpForce;
    private float outsideEffects;
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

    private float slowDownTime = 3;
    private float remainingTime = 5;
    private float slowDownRate = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soupCount = 0;
        outsideEffects = 1f;
        remainingTime = 0;
        SetCountText();
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.StageType != StageType.Forge) {
            bool lastIsGrounded = isGrounded;
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
            if (!lastIsGrounded && isGrounded) {
                SoundManager.instance.RandomizeSfx(land1, land2);
            }

            moveInput = Input.GetAxis("Horizontal");

            animator.SetBool("isGrounded", isGrounded);
            animator.SetFloat("SpeedX", Mathf.Abs(moveInput));
            animator.SetFloat("SpeedY", rb.velocity.y);

            rb.velocity = new Vector2(moveInput * speed * outsideEffects, rb.velocity.y);

            if(facingRight == false && moveInput > 0)
            {
                Flip();
            } else if(facingRight == true && moveInput < 0)
            {
                Flip();
            }
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
        if (GameManager.instance.StageType != StageType.Forge) {

            if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }

            // Slowing down after enemy 
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                outsideEffects = slowDownRate;
            }
            else
            {
                outsideEffects = 1;
            }

            if (isGrounded == true)
            {
                extraJumps = maxJumps;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            soupCount += 1;
            GameObject soupObject = Instantiate(soupParticleConsumedPrefab, other.transform.position, Quaternion.identity);
            soupObject.GetComponent<ParticleSystem>().Play();
            Destroy(soupObject, 1f);
            SoundManager.instance.RandomizeSfx(eatSoup1, eatSoup2, eatSoup3);
            if (soupCount >= soupsToEnterForge) {
                SoundManager.instance.enterForge();
                GameManager.instance.ChangeStageToForge();
                soupCount = 0;
            }
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            if (remainingTime <= 0) {
                SoundManager.instance.ghastScream(ghastSound);
            }
            remainingTime = slowDownTime;
        }
    }

    void SetCountText() {
        countText.text = "SOUPS: " + soupCount.ToString();
    }
}
