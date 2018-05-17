using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFiles : MonoBehaviour {

	private string directory;

	// Use this for initialization
	void Start () {
		directory = System.IO.Directory.GetCurrentDirectory ();

		directory.Substring (0, directory.Length - 14 - 8);
		directory += "/Assets/Resources/TextFiles/CurrentWord.txt";

		try{
			print("test");
			System.IO.Directory.CreateDirectory(directory.Substring(0, directory.Length - "/CurrentWord.txt".Length));
			System.IO.Directory.CreateDirectory(directory.Substring(0, directory.Length - "/TextFiles/CurrentWord.txt".Length) + "/Vocab Lists");
			System.IO.File.Create(directory.Substring(0, directory.Length - "/CurrentWord.txt".Length) + "Guess.txt");
			System.IO.File.Create(directory.Substring(0, directory.Length - "/CurrentWord.txt".Length) + "Selection.txt");
			System.IO.File.Create (directory);
		}
		catch{
			try{
				print("caught one");
				System.IO.File.Create(directory.Substring(0, directory.Length - "/CurrentWord.txt".Length) + "Selection.txt");
				System.IO.File.Create (directory);
			}
			catch{
				try{
					print ("caught two");
					System.IO.File.Create (directory);
				}
				catch{}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
