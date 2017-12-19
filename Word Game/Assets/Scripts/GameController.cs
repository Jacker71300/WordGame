using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	// Instance Variables
	public ArrayList listWords = new ArrayList();

	private int index;
	// Use this for initialization
	void Start () {
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();
		string fileChoice;

		fileDirectory.Substring (0, fileDirectory.Length - 24);
		fileChoice = System.IO.File.ReadAllText(fileDirectory + "/Assets/Vocab Lists/Selection.txt");

		fileDirectory += "/Assets/Vocab Lists/" + fileChoice + ".txt";

		listWords.AddRange(System.IO.File.ReadAllLines (fileDirectory));

		for(int i = Random.Range(0, 101); i > 0; i --){
			string word = listWords.RemoveAt((int)Random.Range(0.0f, listWords.Count));
			listWords.Add(word);
		}
		CreateWord ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void WordSuccess(){

	}

	void CreateWord(){
		
	}
}
