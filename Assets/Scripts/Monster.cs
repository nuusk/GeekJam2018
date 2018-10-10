using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IMiniGameBonus
{
    public int SpawnerIndex = -1;

    public float BonusValue
    {
        get { return Bonus; }
    }

    public GameObject KillableArea;
    public float Bonus = 1f;
    public float Speed = -10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(-Speed, 0);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
