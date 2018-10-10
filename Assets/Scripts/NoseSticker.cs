using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseSticker : MonoBehaviour, IMiniGameBonus
{
    public float BonusValue { get { return Bonus; } }

    public float Bonus = 0.5f;
    public float RandomFactor = 0.75f;
    public float VerticalSpeed = 50f;
    public float HorizontalSpeed = 30f;
    public bool Released = false;
    public readonly Vector2 LeftSpot = new Vector2(-3.5f, 0f);
    public readonly Vector2 RigthSpot = new Vector2(3.5f, 0f);
    public readonly Vector2 CenterSpot = new Vector2(0f, 0f);

    private Rigidbody2D rb;
    private SpotType prevSpot;
    private float step;
    private Vector2 targetPosition;
    private const float delta = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        prevSpot = SpotType.Center;
        targetPosition = GetNewTargetPosition();
    }

    void Update()
    {
        Move();
        OnKeyDown();
    }

    private void OnKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Released = true;
            rb.velocity = new Vector2(0, VerticalSpeed);
        }
    }

    private void Move()
    {
        if (Released)
            return;

        if (IsOnTargetPosition())
            targetPosition = GetNewTargetPosition();

        step = HorizontalSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
    }

    private bool IsOnTargetPosition()
    {
        return (transform.position.x >= targetPosition.x - delta && transform.position.x <= targetPosition.x + delta);
    }

    private Vector2 SelectSpotPosition()
    {
        SpotType spot;

        do
        {
            spot = (SpotType)UnityEngine.Random.Range(0, 3);
        }
        while (spot == prevSpot);

        prevSpot = spot;

        if (spot == SpotType.Left)
            return LeftSpot;
        else if (spot == SpotType.Center)
            return CenterSpot;
        else
            return RigthSpot;
    }

    private Vector2 GetRandomizedPosition(Vector2 vector)
    {
        Vector2 position = new Vector2(vector.x, vector.y);

        position.x += UnityEngine.Random.Range(-RandomFactor, RandomFactor);

        return position;
    }

    private Vector2 GetNewTargetPosition()
    {
        return GetRandomizedPosition(SelectSpotPosition());
    }

    public void Destroy()
    {
        CancelInvoke();
        Destroy(gameObject);
    }
}