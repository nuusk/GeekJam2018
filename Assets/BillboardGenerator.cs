﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardGenerator : MonoBehaviour {

    public double probability = 0.01;
    public GameObject billboardPrefab;
    public double interval = 1;
    private double tmpInterval;
    protected GameObject[] spawners;

    // Use this for initialization
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("BillboardSpawner");
        tmpInterval = interval;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tmpInterval -= Time.deltaTime;

        if (tmpInterval < 0)
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                if (UnityEngine.Random.Range(0f, 1f) < probability)
                {
                    billboardPrefab = Instantiate(
                        billboardPrefab,
                        new Vector3(spawners[i].transform.position.x, spawners[i].transform.position.y, spawners[i].transform.position.z),
                        Quaternion.identity
                    );
                }
            }

            tmpInterval = interval;
        }
    }
}
