using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteCharacter : MonoBehaviour {
	public GameObject image;

	private bool added = false;
	string fileName = "";
	// Use this for initialization
	void Start () {
		fileName = image.GetComponent<Image> ().sprite.name;
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

		fileDirectory.Substring (0, fileDirectory.Length - 24);
		fileDirectory += "/Assets/Vocab Lists/Guess.txt";
		System.IO.File.WriteAllText (fileDirectory, string.Empty);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeChar(){
		if (added) {
			removeChar ();
		} else {
			addChar ();
		}

		added = !added;
	}

	public void addChar(){
		fileName = image.GetComponent<Image> ().sprite.name;
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

		fileDirectory.Substring (0, fileDirectory.Length - 24);
		fileDirectory += "/Assets/Vocab Lists/Guess.txt";
		string currentGuess = System.IO.File.ReadAllText (fileDirectory);

		System.IO.File.WriteAllText (fileDirectory, string.Empty);
		print (fileDirectory);
		print (fileName);
		System.IO.File.WriteAllText (fileDirectory, (currentGuess + fileName));
	}

	public void removeChar(){
		string nameImage = image.GetComponent<Image> ().sprite.name;
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

		fileDirectory.Substring (0, fileDirectory.Length - 24);
		fileDirectory += "/Assets/Vocab Lists/Guess.txt";
		string currentGuess = System.IO.File.ReadAllText (fileDirectory);

		char[] holder = currentGuess.ToCharArray ();

		for(int i = holder.Length - 1; i >= 0; i--){
			//print (nameImage.ToCharArray ().Length);
			//print (i);
			if (holder [i] == nameImage.ToCharArray () [0])
				holder [i] = '|';
		}

		currentGuess = "";

		for (int i = 0; i < holder.Length; i++) {
			if (holder [i] != '|')
				currentGuess += holder [i];
		}

		System.IO.File.WriteAllText (fileDirectory, string.Empty);
		print (fileDirectory);
		print (fileName);
		System.IO.File.WriteAllText (fileDirectory, currentGuess);
	}
}
