using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailMove : MonoBehaviour
{
    public double amplitude;
    public double frequency;
    private int direction;

    // Use this for initialization
    void Start()
    {
        amplitude = UnityEngine.Random.Range(0, 0.3f);
        frequency = UnityEngine.Random.Range(0, 0.1f);
        direction = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
        this.transform.localScale = new Vector3(
            direction,
            this.transform.localScale.y,
            this.transform.localScale.z
            );
    }

    void Update()
    {
        this.transform.position = new Vector3(
            this.transform.position.x,
            this.transform.position.y + (float)amplitude * Mathf.Sin((float)frequency * Time.frameCount),
            this.transform.position.z
            );
    }
}

