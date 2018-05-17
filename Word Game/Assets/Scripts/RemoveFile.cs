/*
 * J. Hoffman
 * Removes a word list if selected
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveFile : MonoBehaviour {
	public Text dropbox = null;
	public string fileName = "Chapter 1";

	// Constantly poll for the fileName
	void Update(){
		fileName = dropbox.text;
	}

	// Delete the file specified
	public void Remove(){
		// Find the file name
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

		//fileDirectory.Substring (0, fileDirectory.Length - 10 - 8);
		fileDirectory += "/Assets/Resources/Vocab Lists/" + fileName + ".txt";

		print (fileDirectory);

		// Empty the file and delete it
		System.IO.File.WriteAllText (fileDirectory, string.Empty);

		System.IO.File.Delete(fileDirectory);
	}
}