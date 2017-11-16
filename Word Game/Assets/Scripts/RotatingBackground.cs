using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBackground : MonoBehaviour {

	// Instance Variables
	public float rotationSpeed = 1.0f;
	public float minSize = 0.7f;
	public float maxSize = 2.0f;
	public float pulseSpeed = 1.0f;

	private bool hitMaxSize = false;
	private bool hitMinSize = true;

	// Use this for initialization
	void Start () {
		transform.localScale.Set (minSize, minSize, minSize);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * Time.deltaTime * rotationSpeed);

		if (!hitMaxSize && !(transform.localScale.x > maxSize)) {
			transform.localScale = new Vector3((transform.localScale.x + (.01f * pulseSpeed)), (transform.localScale.x + (.01f * pulseSpeed)), (transform.localScale.x + (.01f * pulseSpeed)));
		} else {
			hitMaxSize = true;
			hitMinSize = false;
			if (!hitMinSize && !(transform.localScale.x < minSize)) {
				transform.localScale = new Vector3(transform.localScale.x - (.01f * pulseSpeed), transform.localScale.x - (.01f * pulseSpeed), transform.localScale.x - (.01f * pulseSpeed));
			} else {
				hitMaxSize = false;
				hitMinSize = true;
			}
		}
	}
}
