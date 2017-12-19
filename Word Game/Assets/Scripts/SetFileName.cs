using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFileName : MonoBehaviour {
	public Text dropbox = null;
	public string fileName = "Chapter 1";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		fileName = dropbox.text;
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

		fileDirectory.Substring (0, fileDirectory.Length - 21);
		fileDirectory += "/Assets/Vocab Lists/Selection.txt";
		System.IO.File.WriteAllText (fileDirectory, string.Empty);
		print (fileDirectory);
		print (fileName);
		System.IO.File.WriteAllText (fileDirectory, fileName);
	}
}
