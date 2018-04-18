/*
 * J. Hoffman
 * Sets the position for the dynamic changes in the current input text box in the Playable scene
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour {
	public Transform transform;
	public float heightMultiplier;
	public float widthMultiplier;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(Screen.width *widthMultiplier, Screen.height *heightMultiplier);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
