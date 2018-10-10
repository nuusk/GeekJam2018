using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour, IMiniGameBonus
{
    public float BonusValue { get { return Bonus; } }

    public float Bonus = 1.0f;
    public float HitForce = 20f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void HitSpike()
    {
        rb.AddForce(new Vector2(0, -HitForce));
    }
}
