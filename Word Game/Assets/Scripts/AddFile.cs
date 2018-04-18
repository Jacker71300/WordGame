/*
 * J. Hoffman
 * Adds a file to the game with words on it that the user inputs
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddFile : MonoBehaviour {
	public InputField fileBox = null;
	public InputField inputBox = null;
	public string fileName = "Chapter 1";
	public string fileInput = "hola";

	private int index = 0;
	private string[] words = new string[100];

	// Handles initialization
	void Start(){
		for (int i = 0; i < words.Length; i++) {
			words [i] = string.Empty;
		}
	}

	// Check for current inputs
	void Update(){
		fileName = fileBox.text;
		fileInput = inputBox.text;

		/*for (int i = 0; i < words.Length; i++) {
			print (words [i]);
		}*/
	}

	// Create the file when the save button is pressed and there are words in the list
	public void CreateFile(){
		if (index == 0 || fileBox.text.Equals ("") || fileBox.text.Equals (null)) {
		} else {
			// get file directory
			string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

			fileDirectory.Substring (0, fileDirectory.Length - 14 - 8);
			fileDirectory += "/Assets/Vocab Lists/" + fileName + ".txt";

			// create the file
			print (fileDirectory);
			System.IO.File.Create (fileDirectory).Close ();
			//print ("done");

			// write to the file
			string holderString = "";

			// create the string to write
			for (int i = 0; i < words.Length; i++) {
				if (words [i].Equals (string.Empty)) {
					break;
				} else {
					holderString += (words [i] + "\r\n");
				}

				words [i] = string.Empty;
			}

			index = 0;

			// write
			System.IO.File.WriteAllText (fileDirectory, holderString);
			fileBox.text = "";
			print (fileBox.text);
		}
	}

	// add a vocab word to the unfinished list
	public void AddToFile(){
		if (inputBox.text.Equals ("") || inputBox.text.Equals (null)) {
		} else {
			// get directory
			string fileDirectory = System.IO.Directory.GetCurrentDirectory ();
			fileDirectory.Substring (0, fileDirectory.Length - 14);

			// add word and increase index
			words [index] = fileInput;
			index++;

			inputBox.text = "";

			print (inputBox.text);
		}
	}
}