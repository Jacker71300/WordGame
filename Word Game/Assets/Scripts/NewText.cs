using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewText : MonoBehaviour {

	// Instance Variables
	public float pulseSpeed = 1.0f;
	public float finalScale = 1.0f;
	public float maxSize = 1.5f;
    public float minSize = 1.0f;
	public Transform thisTransform;

    private bool hitMinSize = true;
	private bool hitMaxSize = false;
	// Use this for initialization
	void Start () {
		
		// Set the image size to the minimum
		thisTransform.localScale.Set (0.0f, 0.0f, 0.0f);
	}

    // Update is called once per frame
    void Update()
    {

		// Check to see if the image has gotten to its max size and if not, keep increasing the size
		if (!hitMaxSize && !(transform.localScale.x > maxSize))
        {
            transform.localScale = new Vector3((transform.localScale.x + (0.01f * pulseSpeed)), (transform.localScale.x + (0.01f * pulseSpeed)), (transform.localScale.x + (0.01f * pulseSpeed)));
        }
        else
        {
            hitMaxSize = true;
            hitMinSize = false;

			// If it has hit max size, start decreasing the size until the image hits minimum size
			if (!hitMinSize && !(transform.localScale.x < minSize))
            {
                transform.localScale = new Vector3(transform.localScale.x - (0.01f * pulseSpeed), transform.localScale.x - (0.01f * pulseSpeed), transform.localScale.x - (0.01f * pulseSpeed));
            }
            else
            {
                hitMaxSize = false;
                hitMinSize = true;
            }
        }
    }
}
