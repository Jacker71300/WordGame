/*
 * J. Hoffman
 * Set a dynamic size to the background
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSize : MonoBehaviour {
	// fractions of the screen
	public float height = 1f;
	public float picHeight = 720f;
	public float width = 1f;
	public float picWidth = 1280f;
	public Transform transform;

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3 (Screen.width * width / picWidth * 3.25f, Screen.height * height / picHeight * 3.25f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
