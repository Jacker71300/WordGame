using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBackground : MonoBehaviour {

	// Instance Variables
	public float rotationSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * Time.deltaTime * rotationSpeed);
	}
}
