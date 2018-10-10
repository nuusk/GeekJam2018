using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerNail : MonoBehaviour, IMiniGameBonus
{
    public float BonusValue { get { return Bonus; } }

    public float Bonus = 1.0f;
    public float HitForce = 20f;

    private Rigidbody2D rb;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            HitSpike();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void HitSpike()
    {
        rb.AddForce(new Vector2(0, -20));
        _audioSource.Play();
    }
}
