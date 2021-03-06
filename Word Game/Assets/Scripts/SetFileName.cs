﻿/*
 * J. Hoffman
 * Fetches current welected list name and stores it in a file for use in the Playable scene
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Used to select the current vocab list
public class SetFileName : MonoBehaviour {
	public Text dropbox = null;
	public string fileName = "Chapter 1";
	public Button button = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Write file name from the text box on the menu into a selection file
		fileName = dropbox.text;
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

		fileDirectory.Substring (0, fileDirectory.Length - 21);
		fileDirectory += "/Assets/Resources/TextFiles/Selection.txt";

		// Clear file of residual data and write the selected file name
		System.IO.File.WriteAllText (fileDirectory, string.Empty);
		//print (fileDirectory);
		//print (fileName);
		System.IO.File.WriteAllText (fileDirectory, fileName);

		if (fileName.ToUpper ().Equals ("")) {
			button.interactable = false;
		} else {
			button.interactable = true;
		}
	}
}
