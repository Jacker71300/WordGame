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
		
		thisTransform.localScale.Set (0.0f, 0.0f, 0.0f);
	}

    // Update is called once per frame
    void Update()
    {

        if (!hitMaxSize && !(transform.localScale.x > maxSize))
        {
            transform.localScale = new Vector3((transform.localScale.x + (0.01f * pulseSpeed)), (transform.localScale.x + (0.01f * pulseSpeed)), (transform.localScale.x + (0.01f * pulseSpeed)));
        }
        else
        {
            hitMaxSize = true;
            hitMinSize = false;
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
