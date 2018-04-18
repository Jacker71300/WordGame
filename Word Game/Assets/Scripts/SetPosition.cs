/*
 * J. Hoffman
 * Sets the position for the dynamic changes in the current input text box in the Playable scene
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour {
	public Transform transform;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(Screen.width / 2, Screen.height * 4 / 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
