﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public float backgroundSize;
	public float parallaxSpeedX;
	public float parallaxSpeedY;
	private Transform cameraTransform;
	private Transform[] layers;
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;
	private float lastCameraX;

	private float lastCameraY;

	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		lastCameraX = cameraTransform.position.x;
		lastCameraY = cameraTransform.position.y;
		layers = new Transform[transform.childCount];
		Debug.Log(layers);
		for (int i=0; i<transform.childCount; i++) {
			layers[i] = transform.GetChild(i);
		}

		leftIndex = 0;
		rightIndex = layers.Length-1;
	}

	private void ScrollLeft() {
		int lastRight = rightIndex;
		layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
		leftIndex = rightIndex;
		rightIndex++;
		if(rightIndex < 0) {
			rightIndex = layers.Length-1;
		}
	}

	private void ScrollRight() {
		int lastLeft = leftIndex;
		layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
		rightIndex = leftIndex;
		leftIndex--;
		if(leftIndex < 0) {
			leftIndex = layers.Length-1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = cameraTransform.position.x - lastCameraX;
		float deltaY = cameraTransform.position.y - lastCameraY;
		transform.position += Vector3.right * (deltaX * parallaxSpeedX);
		transform.position += Vector3.up * (deltaY * parallaxSpeedY);
		lastCameraX = cameraTransform.position.x;
		lastCameraY = cameraTransform.position.y;

		if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone)) {
			ScrollLeft();
		}

		if (cameraTransform.position.x > (layers[leftIndex].transform.position.x - viewZone)) {
			ScrollRight();
		}
	}
}
