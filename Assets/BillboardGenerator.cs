using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardGenerator : MonoBehaviour {

    public double probability = 0.01;
    public GameObject billboardPrefab1;
    public GameObject billboardPrefab2;
    public GameObject billboardPrefab3;
    public GameObject billboardPrefab4;
    public double interval = 1;
    private double tmpInterval;
    protected GameObject[] spawners;
    protected GameObject[] billboards;

    // Use this for initialization
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("BillboardSpawner");
        billboards = new GameObject[] { billboardPrefab1, billboardPrefab2, billboardPrefab3, billboardPrefab4 };
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
                    int idx = UnityEngine.Random.Range(0, 4);
                    Instantiate(
                        billboards[idx],
                        new Vector3(spawners[i].transform.position.x, spawners[i].transform.position.y - 80, spawners[i].transform.position.z),
                        Quaternion.identity
                    );
                }
            }

            tmpInterval = interval;
        }
    }
}
