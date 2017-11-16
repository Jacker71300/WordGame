using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewText : MonoBehaviour {

	// Instance Variables
	public float speed = 1.0f;
	public float finalScale = 1.0f;
	public float maxSize = 1.5f;
	public Transform thisTransform;

	private bool hitMaxSize = false;
	// Use this for initialization
	void Start () {
		
		thisTransform.localScale.Set (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if(!hitMaxSize && !thisTransform.localScale.Equals(new Vector3(maxSize, maxSize, maxSize))){
			thisTransform.localScale.Set (thisTransform.localScale.x + (.01f * speed), thisTransform.localScale.x + (.01f * speed), thisTransform.localScale.x + (.01f * speed));
		}
		else if(hitMaxSize && !thisTransform.localScale.Equals(new Vector3(finalScale, finalScale, finalScale))){
			thisTransform.localScale.Set (thisTransform.localScale.x - (.01f * speed), thisTransform.localScale.x - (.01f * speed), thisTransform.localScale.x - (.01f * speed));
		}
	}
}
