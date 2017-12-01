using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Instance Variables
	public ArrayList listWords = new ArrayList();


	// Use this for initialization
	void Start () {
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

		fileDirectory.Substring (0, fileDirectory.Length - 24);
		fileDirectory += "/Assets/Vocab Lists/Chapter 1.txt";

		listWords.AddRange(System.IO.File.ReadAllLines (fileDirectory));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void WordSuccess(){

	}

	void CreateWord(){

	}
}
