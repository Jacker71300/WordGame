﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteCharacter : MonoBehaviour {
	public GameObject image;

	private bool added = false;
	string fileName = "";

	// Use this for initialization
	void Start () {
		// Get the character the picture represents
		fileName = image.GetComponent<Image> ().sprite.name;
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

		// Reset the current guess file to remove residual characters
		fileDirectory.Substring (0, fileDirectory.Length - 24);
		fileDirectory += "/Assets/Vocab Lists/Guess.txt";
		System.IO.File.WriteAllText (fileDirectory, string.Empty);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Handles when the picture is clicked on
	public void changeChar(){
		// Determine whether or not to add or remove a character that has been clicked on
		if (added) {
			removeChar ();
		} else {
			addChar ();
		}

		added = !added;
	}

	// Handles adding a character
	public void addChar(){
		// Find the name of the character the picture represents
		fileName = image.GetComponent<Image> ().sprite.name;
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

		// Find the guess file and fetch the guess
		fileDirectory.Substring (0, fileDirectory.Length - 24);
		fileDirectory += "/Assets/Vocab Lists/Guess.txt";
		string currentGuess = System.IO.File.ReadAllText (fileDirectory);

		// Clear the file and append the new character onto the current guess, then write that back to the file
		System.IO.File.WriteAllText (fileDirectory, string.Empty);
		print (fileDirectory);
		print (fileName);
		System.IO.File.WriteAllText (fileDirectory, (currentGuess + fileName));
	}

	// Handles removing a character
	public void removeChar(){
		// Get the character the image represents
		string nameImage = image.GetComponent<Image> ().sprite.name;
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

		// Fetch the guess file
		fileDirectory.Substring (0, fileDirectory.Length - 24);
		fileDirectory += "/Assets/Vocab Lists/Guess.txt";
		string currentGuess = System.IO.File.ReadAllText (fileDirectory);

		// Split the current guess for processing
		char[] holder = currentGuess.ToCharArray ();

		// Replace the last instance of the character with a vertical line
		for(int i = holder.Length - 1; i >= 0; i--){
			if (holder [i] == nameImage.ToCharArray () [0]) {
				holder [i] = '|';
				break;
			}
		}

		// Remove the vertical line from the guess and store it in currentGuess
		currentGuess = "";

		for (int i = 0; i < holder.Length; i++) {
			if (holder [i] != '|')
				currentGuess += holder [i];
		}

		// Clear the file and rewrite the new guess
		System.IO.File.WriteAllText (fileDirectory, string.Empty);
		print (fileDirectory);
		print (fileName);
		System.IO.File.WriteAllText (fileDirectory, currentGuess);
	}
}
