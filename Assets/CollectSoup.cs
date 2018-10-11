using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSoup : MonoBehaviour {

	public float speed;

	private Rigidbody2D rigidbody2D;
	private int count;

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
	}
}
