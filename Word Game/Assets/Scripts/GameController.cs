using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	// Instance Variables
	public ArrayList listWords = new ArrayList();
	public ArrayList letterPics = new ArrayList();
	public Transform Letter = null;

	private int index;
	private string currentWord;
	// Use this for initialization
	void Start () {
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();
		string fileChoice;

		fileDirectory.Substring (0, fileDirectory.Length - 24);
		fileChoice = System.IO.File.ReadAllText(fileDirectory + "/Assets/Vocab Lists/Selection.txt");

		fileDirectory += "/Assets/Vocab Lists/" + fileChoice + ".txt";

		listWords.AddRange(System.IO.File.ReadAllLines (fileDirectory));

		for(int i = Random.Range(0, 101); i > 0; i --){
			int holder = (int)Random.Range (0.0f, listWords.Count);
			string word = (string) listWords[holder];
			listWords.RemoveAt(holder);
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
		currentWord = (string) listWords [0];
		listWords.RemoveAt (0);
		currentWord = currentWord.ToLower ();

		char[] letters = currentWord.ToCharArray ();


		for(int i = 0; i < letters.Length; i++){
			Instantiate (Letter, new Vector3 (100f * i, 200f), Quaternion.identity);
			print (letters [i]);
		}
	}
}
