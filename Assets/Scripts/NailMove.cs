using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailMove : MonoBehaviour
{
    private float amplitude;
    private float frequency;

    // Use this for initialization
    void Start()
    {
        amplitude = UnityEngine.Random.Range(0, 0.5f);
        frequency = UnityEngine.Random.Range(0, 1f);
    }

    void Update()
    {
        this.transform.position = new Vector3(
            this.transform.position.x,
            this.transform.position.y + amplitude * Mathf.Sin(frequency * Time.frameCount),
            this.transform.position.z
            );
    }
}

