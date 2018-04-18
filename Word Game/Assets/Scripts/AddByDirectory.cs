/*
 * J. Hoffman
 * Copies a file to the game directory for use in the game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddByDirectory : MonoBehaviour {

	public InputField input;

	private string fileName = "";
	private string directory = "";
	private ArrayList message = new ArrayList();

	// Use this for initialization
	void Start () {
		directory = System.IO.Directory.GetCurrentDirectory ();

		directory.Substring (0, directory.Length - 14 - 8);
		directory += "/Assets/Vocab Lists/";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Copies the file input in the IF
	public void CopyFile () {
		fileName = input.text;

		System.IO.File.Copy(fileName, directory + System.IO.Path.GetFileName(fileName));

		input.text = "";
	}
}
