using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhastFloat : MonoBehaviour {

    public double amplitude = 0.1;
    public double frequency = 0.05;
    public int horizontalSpeed = 10;
    private int direction;
    private Rigidbody2D rb;
    
    // Use this for initialization
    void Start () {
        direction = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
        this.transform.localScale = new Vector3(
            direction,
            this.transform.localScale.y,
            this.transform.localScale.z
            );
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        // rb.velocity = new Vector2(horizontalSpeed * direction * Time.deltaTime, rb.ve);
        this.transform.position = new Vector3(
            this.transform.position.x + horizontalSpeed * Time.deltaTime * direction,
            this.transform.position.y + (float)amplitude * Mathf.Sin((float)frequency * Time.frameCount),
            this.transform.position.z
            );
	}
}
