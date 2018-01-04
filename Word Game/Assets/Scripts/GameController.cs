using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	// Instance Variables
	public ArrayList listWords = new ArrayList();
	public ArrayList letterPics = new ArrayList();
	public Transform Letter;
	public Transform canvas;

	private int currentIndex = 0;
	private string guess = "";
	private int index = 0;
	private string currentWord = "";
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
		if(guess.Equals(currentWord)){
			WordSuccess();
		}
	}

	void WordSuccess(){
		currentIndex++;
		try{
			CreateWord ();
		}
		catch{
			Win ();
		}
	}

	void Win(){

	}

	void CreateWord(){
		currentWord = (string) listWords [currentIndex];
		listWords.RemoveAt (currentIndex);
		currentWord = currentWord.ToLower ();

		char[] letters = currentWord.ToCharArray ();


		for(int i = 0; i < letters.Length; i++){
			Transform holder = Instantiate (Letter, new Vector3 (100f * i + 100f, 75f), Quaternion.identity) as RectTransform;
			holder.SetParent (canvas);
			string filename = letters [i].ToString ().ToUpper ();
			holder.GetComponent<Image> ().sprite = Resources.Load<Sprite>(filename);
			print (filename);
			letterPics.Add (holder);
			print (letters [i]);
		}
	}

	public void addChar(GameObject letterbox){
		string name = letterbox.GetComponent<Image> ().sprite.name;
		guess += name;
	}

	public void removeChar(GameObject letterbox){
		string name = letterbox.GetComponent<Image> ().sprite.name;
		char[] holder = guess.ToCharArray ();

		for(int i = holder.Length; i >= 0; i--){
			if (holder [i] == name.ToCharArray () [0])
				holder [i] = '|';
		}

		guess = "";

		for (int i = 0; i < holder.Length; i++) {
			if (holder [i] != '|')
				guess += holder [i];
		}
	}
}
