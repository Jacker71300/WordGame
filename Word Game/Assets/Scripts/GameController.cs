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
		}
		catch{
			guess = "";
		}

		print (guess);

		if(guess.ToUpper().Equals(currentWord.ToUpper())){
			WordSuccess();
		}
	}

	void WordSuccess(){
		currentIndex++;

		for(int i = 0; i < letterPics.Count; i++){
			GameObject holder = letterPics[i] as GameObject;
			letterPics.RemoveAt(i);
			DestroyImmediate(holder.gameObject);
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
			letterPics.Add (GameObject.Find(holder.name));
			print (letters [i]);
		}
	}
}
