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
	public Text text;

	private string guess = "";
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
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

		fileDirectory.Substring (0, fileDirectory.Length - 24);
		fileDirectory += "/Assets/Vocab Lists/Guess.txt";
		try{
			guess = System.IO.File.ReadAllLines(fileDirectory)[0];
			text.text = guess;
		}
		catch{
			guess = "";
			text.text = guess;
		}

		//print (guess);

		if(guess.ToUpper().Equals(currentWord.ToUpper())){
			WordSuccess();
		}
	}

	void WordSuccess(){
		
		while(letterPics.Count > 0){
			for(int i = letterPics.Count - 1; i >= 0; i--) {
				GameObject holder = letterPics[i] as GameObject;
				letterPics.RemoveAt(i);
				print ("destroy " + holder);
				DestroyImmediate (holder);
			}
		}
			
		try{
			CreateWord ();
		}
		catch{
			Win ();
		}
	}

	void Win(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ((int)(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex) - 1);
	}

	void CreateWord(){
		currentWord = (string) listWords [0];
		listWords.RemoveAt (0);
		currentWord = currentWord.ToLower ();

		char[] letters = shuffle(currentWord.ToCharArray ());

		// create the positions where the pictures will show up
		float[] positionsX = new float[letters.Length];
		float[] positionsY = new float[letters.Length];

		const float WIDTH = 686f;
		const float HEIGHT = 321f * 2f/3f;
		const float MAX_PER_LINE = 6;
		int numLetters = letters.Length;

		if (numLetters > MAX_PER_LINE) {
			for (int i = 0; i < (int)(numLetters / MAX_PER_LINE + .5); i++) {
				for (int holder = (int)(i * numLetters / MAX_PER_LINE); holder < numLetters; holder++) {
					positionsY [holder] = HEIGHT * (i + 1) / (int)(numLetters / MAX_PER_LINE + .5);
				}
			}
		} else {
			for (int i = 0; i < positionsY.Length; i++) {
				positionsY [i] = HEIGHT * 1 / 2;
			}
		}

		for (int i = 0; i < numLetters; i++) {

		}

		letterPics.Clear ();

		// create the pictures in the game
		for(int i = 0; i < letters.Length; i++){
			Transform holder = Instantiate (Letter, new Vector3 (100f * i + 100f, 75f), Quaternion.identity) as RectTransform;
			holder.SetParent (canvas);
			holder.name = "unity" + i;
			string filename = letters [i].ToString ().ToUpper ();
			holder.GetComponent<Image> ().sprite = Resources.Load<Sprite>(filename);
			//print (filename);
			letterPics.Add (GameObject.Find(holder.name));
			//print (letterPics[i]);
			//print (letters [i]);
		}


	}

	char[] shuffle(char[] charArray){
		char[] shuffled = new char[charArray.Length];
		int random;

		for (int i = charArray.Length; i >= 1; i--) {
			random = (int)Random.Range (1f, i + 1f) - 1;
			shuffled [i - 1] = charArray [random];
			charArray [random] = charArray [i - 1];
		}
		return shuffled;
	}
}
